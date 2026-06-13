using Sandbox;
using System;

namespace SbTween;

public class BaseTween
{
    // Core Settings 
    public float Duration { get; set; }
    public float Elapsed { get; private set; }
    public float Delay { get; private set; }
    public EaseType Ease { get; set; } = EaseType.Linear;
    public Func<float, float> TimingFunction { get; set; }
    public GameObject Target { get; set; }
    public string Id { get; set; }


    // Looping 
    public LoopType LoopMode { get; set; } = LoopType.Restart;
    public int Loops { get; private set; } = 0; // 0 = once, -1 = infinity.
    private int _loopsDone = 0;

    // State 
    public bool IsFinished { get; private set; }
    public bool IsPaused { get; private set; }
    public bool IsReversed { get; private set; }

    // Events
    private Action _onStart;
    private Action _onComplete;
    private Action _onLoop;
    private Action<float> _onUpdate;

    private bool _hasStarted = false;

    public BaseTween( float duration )
    {
       Duration = duration;
    }

    public BaseTween SetDelay( float seconds )
    {
       Delay = seconds;
       return this;
    }

    public BaseTween SetId( string id )
    {
       Id = id;
       return this;
    }
    protected float GetEasedProgress( float p )
    {
       return TimingFunction != null ? TimingFunction( p ) : p;
    }

    public void Update( float deltaTime )
    {
       if ( IsFinished || IsPaused ) return;

       if ( Delay > 0 )
       {
          Delay -= deltaTime;
          return;
       }

       if ( !_hasStarted )
       {
          _onStart?.Invoke();
          _hasStarted = true;
       }

       if ( IsReversed )
          Elapsed -= deltaTime;
       else
          Elapsed += deltaTime;

       // Calculate un-clamped progress to detect precise boundaries safely
       float rawProgress = Elapsed / Duration;
       float progress = Math.Clamp( rawProgress, 0f, 1.0f );
       float finalProgress = TimingFunction != null ? TimingFunction( progress ) : Easing.Apply( Ease, progress );

       if ( LoopMode == LoopType.Incremental )
       {
          _onUpdate?.Invoke( finalProgress + _loopsDone );
       }
       else
       {
          _onUpdate?.Invoke( finalProgress );
       }

       // Boundary detection checking against raw values to prevent precision lockups
       if ( (!IsReversed && rawProgress >= 1.0f) || (IsReversed && rawProgress <= 0f) )
       {
          if ( Loops == -1 || _loopsDone < Loops )
          {
             _loopsDone++;
             _onLoop?.Invoke();

             if ( LoopMode == LoopType.YoYo )
             {
                IsReversed = !IsReversed;
                // Snap Elapsed to the exact boundaries so the next frame increments cleanly
                Elapsed = IsReversed ? Duration : 0f;
             }
             else
             {
                Elapsed = 0f;
             }
          }
          else
          {
             IsFinished = true;
             _onComplete?.Invoke();
             
             // Auto-remove from manager if active
             if ( TweenManager.Current is { } Tweener )
             {
                Tweener.RemoveTween( this );
             }
          }
       }
    }

    // Chaining Method
    public BaseTween SetEase( EaseType ease ) { Ease = ease; return this; }
    public BaseTween SetLoops( int loops, LoopType type = LoopType.Restart )
    {
       Loops = loops;
       LoopMode = type;
       return this;
    }

    public BaseTween OnStart( Action a ) { _onStart = a; return this; }
    public BaseTween OnUpdate( Action<float> a ) 
    { 
	    if ( a == null ) return this;
   
	    _onUpdate = _onUpdate == null ? a : (Action<float>)Delegate.Combine(_onUpdate, a); 
	    return this; 
    }
    public BaseTween OnComplete( Action a ) { _onComplete = a; return this; }
    public BaseTween OnLoop( Action a ) { _onLoop = a; return this; }

    public BaseTween WithCurve( Curve curve )
    {
       TimingFunction = t => curve.Evaluate( t );
       return this;
    }

    // Playback 
    public void Pause() => IsPaused = true;
    public void Play()
    {
       IsPaused = false;
       IsFinished = false;

       if ( TweenManager.Current is { } Tweener )
       {
          Tweener.AddTween( this );
       }
    }
    public void Kill() => IsFinished = true;
    public void Reverse() => IsReversed = !IsReversed;
    public void Reset()
    {
       Elapsed = 0;
       IsFinished = false;
       IsPaused = true;
       _hasStarted = false;
       _loopsDone = 0;
    }

    public void Stop()
    {
       IsFinished = true;
       IsPaused = true;

       if ( TweenManager.Current is { } Tweener )
       {
          Tweener.RemoveTween( this );
       }
    }
}



public enum LoopType
{
    Restart,    // 0 to 1, 0 -> 1
    YoYo,       // 0 to 1 to 0
    Incremental // 0 to 1, then 1 -> 2, then 2 -> 3 etc etc.
}
