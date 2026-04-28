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
	public GameObject Target { get; set; }

	// Looping 
	public int Loops { get; private set; } = 0; // 0 = once, -1 = infinite
	private int _loopsDone = 0;
	public bool IsYoyo { get; private set; } // if true, flips direction every loop

	// State 
	public bool IsFinished { get; private set; }
	public bool IsPaused { get; private set; }
	public bool IsReversed { get; private set; }

	// Events
	private Action _onStart;
	private Action _onComplete;
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
	public void Stop()
	{
		IsFinished = true;
		IsPaused = true;

		if ( TweenManager.Instance.IsValid() )
		{
			TweenManager.Instance.RemoveTween( this );
		}
	}

	public void Update( float deltaTime )
	{
		if ( IsFinished || IsPaused ) return;

		if ( !_hasStarted )
		{
			_onStart?.Invoke();
			_hasStarted = true;
		}

		if ( Elapsed == 0 && !IsReversed && _loopsDone == 0 )
		{
			_onStart?.Invoke();
		}

		if ( IsReversed )
			Elapsed -= deltaTime;
		else
			Elapsed += deltaTime;

		float progress = Math.Clamp( Elapsed / Duration, 0, 1 );

		_onUpdate?.Invoke( Easing.Apply( Ease, progress ) );

		if ( (!IsReversed && progress >= 1.0f) || (IsReversed && progress <= 0f) )
		{
			if ( Loops == -1 || _loopsDone < Loops )
			{
				_loopsDone++;

				if ( IsYoyo )
				{
					IsReversed = !IsReversed;
				}
				else
				{
					Elapsed = 0;
				}
			}
			else
			{
				IsFinished = true;
				_onComplete?.Invoke();
			}
		}
	}

	// Chaining Method
	public BaseTween SetEase( EaseType ease ) { Ease = ease; return this; }
	public BaseTween SetLoops( int loops, bool yoyo = false ) { Loops = loops; IsYoyo = yoyo; return this; }
	public BaseTween OnStart( Action a ) { _onStart = a; return this; }
	public BaseTween OnUpdate( Action<float> a ) { _onUpdate = a; return this; }
	public BaseTween OnComplete( Action a ) { _onComplete = a; return this; }

	// Playback 
	public void Pause() => IsPaused = true;
	public void Play()
	{
		IsPaused = false;
		IsFinished = false;

		if ( TweenManager.Instance.IsValid() )
		{
			TweenManager.Instance.AddTween( this );
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
	}
}
