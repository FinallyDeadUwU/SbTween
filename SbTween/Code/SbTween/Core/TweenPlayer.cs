using Sandbox;
using System;

namespace SbTween;

[Title( "SbTween Player" )]
[Category( "Tweening" )]
[Icon( "play_arrow" )]
public sealed class SbTweenPlayer : Component, Component.ExecuteInEditor
{
    // BUTTONS
    [Group( "Buttons" ), Button( "Play", "play_arrow" )]
    public void PlayButton() => Play();

    [Group( "Buttons" ), Button( "Stop", "stop" )]
    public void StopButton() => Stop();

    // SETUP
    [Property, Group( "Setup" )] public TweenType Type { get; set; } = TweenType.Move;

    // VECTORS & TRANSFORMS
    [Property, Group( "Setup" ), ShowIf( nameof( IsVector ), true )] public Vector3 From { get; set; }
    [Property, Group( "Setup" ), ShowIf( nameof( IsVector ), true )] public Vector3 To { get; set; }

    [Property, Group( "Setup" ), ShowIf( nameof( IsVector2D ), true )] public Vector2 From2D { get; set; }
    [Property, Group( "Setup" ), ShowIf( nameof( IsVector2D ), true )] public Vector2 To2D { get; set; }

    // RENDER / TINT
    [Property, Group( "Setup" ), ShowIf( nameof( Type ), TweenType.Tint )] public Color ColorFrom { get; set; } = Color.White;
    [Property, Group( "Setup" ), ShowIf( nameof( Type ), TweenType.Tint )] public Color ColorTo { get; set; } = Color.White;

    // SHAKE JUICE
    [Property, Group( "Setup" ), ShowIf( nameof( IsShake ), true )] public float Strength { get; set; } = 1.0f;

    // MATH / PROCEDURAL
    [Property, Group( "Setup" ), ShowIf( nameof( IsCircularOrSpiral ), true )] public Vector3 Axis { get; set; } = Vector3.Up * 100f;
    [Property, Group( "Setup" ), ShowIf( nameof( IsCircularOrSpiral ), true )] public float Speed { get; set; } = 1f;
    [Property, Group( "Setup" ), ShowIf( nameof( IsCircularOrSpiral ), true )] public float Frequency { get; set; } = 5f;
    [Property, Group( "Setup" ), ShowIf( nameof( IsCircularOrSpiral ), true )] public float Range { get; set; } = 5f;

    // IN CIRCLE SNAPPING
    [Property, Group( "Setup" ), ShowIf( nameof( Type ), TweenType.InCircle )] public bool Snapping { get; set; } = false;

    // SETTINGS
    [Property, Group( "Settings" )] public float Duration { get; set; } = 1.0f;
    [Property, Group( "Settings" )] public float Delay { get; set; } = 0.0f;

    [Property, Group( "Settings" )]
    [Title( "Loops (0 = Once, -1 = Infinite)" )]
    public int Loops { get; set; } = 0;

    [Property, Group( "Settings" )] public LoopType LoopMode { get; set; } = LoopType.Restart;
    [Property, Group( "Settings" )] public EaseType Easing { get; set; } = EaseType.Linear;
    [Property, Group( "Settings" )] public bool AutoPlay { get; set; } = true;
    [Property, Group( "Settings" )] public string TweenID { get; set; } = "";

    [Property, Group( "Settings" )] public bool UseCurve { get; set; } = false;
    [Property, Group( "Settings" ), ShowIf( nameof( UseCurve ), true )] public Curve TweenCurve { get; set; } = Curve.Linear;

    // EVENTS
    [Property, Group( "Events" )] public Action _OnStart { get; set; }
    [Property, Group( "Events" )] public Action _OnComplete { get; set; }
    [Property, Group( "Debug" )] public bool GizmoDebug { get; set; } = true;

    // REFLECTION LOOKUPS FOR EDITOR SHOWIFs
    [Hide] public bool IsCircularOrSpiral => Type == TweenType.InCircle || Type == TweenType.Spiral;
    [Hide] public bool IsShake => Type == TweenType.ShakeScale || Type == TweenType.ShakeLocation || Type == TweenType.ShakeRotation;
    [Hide] public bool IsVector => Type == TweenType.Move || Type == TweenType.MoveLocal || Type == TweenType.Rotate || Type == TweenType.RotateLocal || Type == TweenType.Scale;
    [Hide] public bool IsVector2D => Type == TweenType.Move2D || Type == TweenType.MoveLocal2D;

    private BaseTween _currentTween;
    private TweenSnapshot _initialState;
    private int _completedLoops = 0;
    private bool _isReversing = false;

    private Vector3 _incrementalFrom;
    private Vector3 _incrementalTo;
    private Vector2 _incrementalFrom2D;
    private Vector2 _incrementalTo2D;
    private bool _isIncrementalStarted = false;

    protected override void OnStart()
    {
       if ( Game.IsPlaying && AutoPlay )
       {
          Play();
       }
    }

    protected override void OnUpdate()
    {
       if ( Game.IsPlaying ) return;
       if ( _currentTween == null ) return;

       if ( !_currentTween.IsFinished && !_currentTween.IsPaused )
       {
          GameObject.Transform.Local = GameObject.Transform.Local;
       }
    }

    protected override void DrawGizmos()
    {
       if ( !GizmoDebug || !Gizmo.IsSelected ) return;
       if ( Type != TweenType.Move && Type != TweenType.MoveLocal ) return;

       using ( Gizmo.Scope() )
       {
          Gizmo.Transform = new Transform().WithPosition( 0 ).WithRotation( Rotation.Identity ).WithScale( 1 );
          float sphereRadius = 6f;

          Gizmo.Draw.Color = Color.Green;
          Gizmo.Draw.SolidSphere( From, sphereRadius );
          Gizmo.Draw.Text( "FROM", new Transform( From + Vector3.Up * 10f ) );

          Gizmo.Draw.Color = Color.Red;
          Gizmo.Draw.SolidSphere( To, sphereRadius );
          Gizmo.Draw.Text( "TO", new Transform( To + Vector3.Up * 10f ) );

          Gizmo.Draw.Color = Color.Yellow.WithAlpha( 0.4f );
          Gizmo.Draw.Line( From, To );

          var mid = (From + To) / 2f;
          var dir = (To - From).Normal;
          if ( dir.Length > 0.1f )
          {
             Gizmo.Draw.Arrow( mid, mid + dir * 15f, 10f, 5f );
          }
       }
    }

    public void Play()
    {
       StopInternal();

       if ( _initialState == null )
       {
          _initialState = new TweenSnapshot();
          _initialState.Capture( GameObject );
       }

       if ( LoopMode == LoopType.Incremental && !IsCircularOrSpiral )
       {
          if ( !_isIncrementalStarted )
          {
             _incrementalFrom = From;
             _incrementalTo = To;
             _incrementalFrom2D = From2D;
             _incrementalTo2D = To2D;
             _isIncrementalStarted = true;
          }
       }
       else
       {
          _isIncrementalStarted = false;
       }

       if ( !IsCircularOrSpiral && LoopMode != LoopType.Incremental )
       {
          ResetToState( !_isReversing );
       }

       GameObject.Transform.ClearInterpolation();

       _currentTween = CreateTweenInstance( _isReversing );
       if ( _currentTween == null ) return;

       _currentTween
          .SetDelay( Delay )
          .OnStart( () => _OnStart?.Invoke() );

       if ( UseCurve ) 
          _currentTween.WithCurve( TweenCurve );
       else 
          _currentTween.SetEase( Easing );

       if ( !string.IsNullOrEmpty( TweenID ) )
       {
          _currentTween.SetId( TweenID );
       }

       if ( LoopMode == LoopType.Incremental && !IsCircularOrSpiral )
       {
          _currentTween.OnComplete( () => HandleCompletion() );
       }
       else
       {
          _currentTween.SetLoops( Loops, LoopMode );
          _currentTween.OnComplete( () => _OnComplete?.Invoke() );
       }

       _currentTween.Play();
    }

    public void Stop()
    {
       StopInternal();
       _completedLoops = 0;
       _isReversing = false;
       _isIncrementalStarted = false;

       if ( _initialState != null )
       {
          _initialState.Restore();
       }
       _initialState = null;
    }

    private void StopInternal()
    {
       _currentTween?.Stop();
       _currentTween = null;
    }

    private void HandleCompletion()
    {
       _OnComplete?.Invoke();
       bool hasMoreLoops = Loops == -1 || _completedLoops < Loops;

       switch ( LoopMode )
       {
          case LoopType.YoYo:
             _isReversing = !_isReversing;
             if ( !_isReversing && Loops != -1 ) _completedLoops++;

             if ( hasMoreLoops || _isReversing )
             {
                Play();
             }
             break;

          case LoopType.Incremental:
             if ( hasMoreLoops )
             {
                if ( Loops != -1 ) _completedLoops++;
                if ( IsVector )
                {
                   var delta = _incrementalTo - _incrementalFrom;
                   _incrementalFrom = _incrementalTo;
                   _incrementalTo += delta;
                }
                else if ( IsVector2D )
                {
                   var delta2D = _incrementalTo2D - _incrementalFrom2D;
                   _incrementalFrom2D = _incrementalTo2D;
                   _incrementalTo2D += delta2D;
                }
                _isReversing = false;
                Play();
             }
             break;

          case LoopType.Restart:
             if ( hasMoreLoops )
             {
                if ( Loops != -1 ) _completedLoops++;
                _isReversing = false;
                Play();
             }
             break;
       }
    }

    private void ResetToState( bool useFrom )
    {
       if ( Type == TweenType.Tint )
       {
          var mr = Components.Get<ModelRenderer>();
          if ( mr.IsValid() ) mr.Tint = useFrom ? ColorFrom : ColorTo;
       }
       else if ( IsVector2D )
       {
          var val2D = useFrom ? From2D : To2D;
          switch ( Type )
          {
             case TweenType.Move2D: 
                GameObject.WorldPosition = new Vector3( val2D.x, val2D.y, GameObject.WorldPosition.z ); 
                break;
             case TweenType.MoveLocal2D: 
                GameObject.LocalPosition = new Vector3( val2D.x, val2D.y, GameObject.LocalPosition.z ); 
                break;
          }
       }
       else
       {
          var val = useFrom ? From : To;
          switch ( Type )
          {
             case TweenType.Move: GameObject.WorldPosition = val; break;
             case TweenType.MoveLocal: GameObject.LocalPosition = val; break;
             case TweenType.Scale: GameObject.LocalScale = val; break;
             case TweenType.Rotate: GameObject.WorldRotation = Rotation.From( val.x, val.y, val.z ); break;
             case TweenType.RotateLocal: GameObject.LocalRotation = Rotation.From( val.x, val.y, val.z ); break;
          }
       }
    }

    private BaseTween CreateTweenInstance( bool reverse )
    {
       // Calculate explicit dimensional targets contextually
       Vector3 startVal = (LoopMode == LoopType.Incremental && _isIncrementalStarted) ? _incrementalFrom : From;
       Vector3 endVal = (LoopMode == LoopType.Incremental && _isIncrementalStarted) ? _incrementalTo : To;
       Vector3 targetVal = reverse ? startVal : endVal;

       Vector2 startVal2D = (LoopMode == LoopType.Incremental && _isIncrementalStarted) ? _incrementalFrom2D : From2D;
       Vector2 endVal2D = (LoopMode == LoopType.Incremental && _isIncrementalStarted) ? _incrementalTo2D : To2D;
       Vector2 targetVal2D = reverse ? startVal2D : endVal2D;

       Color targetColor = reverse ? ColorFrom : ColorTo;

       var t = Type switch
       {
          TweenType.Move => GameObject.TweenMove( targetVal, Duration ),
          TweenType.MoveLocal => GameObject.TweenMoveLocal( targetVal, Duration ),
          TweenType.Rotate => GameObject.TweenRotate( Rotation.From( targetVal.x, targetVal.y, targetVal.z ), Duration ),
          TweenType.RotateLocal => GameObject.TweenRotateLocal( Rotation.From( targetVal.x, targetVal.y, targetVal.z ), Duration ),
          TweenType.Scale => GameObject.TweenScale( targetVal, Duration ),
          TweenType.Move2D => GameObject.TweenMove2D( targetVal2D, Duration ),
          TweenType.MoveLocal2D => GameObject.TweenMoveLocal2D( targetVal2D, Duration ),
          
          TweenType.Tint => Components.Get<ModelRenderer>()?.TweenTint( targetColor, Duration ),

          TweenType.ShakeLocation => GameObject.TweenShakeLocation( Duration, Strength ),
          TweenType.ShakeRotation => GameObject.TweenShakeRotation( Duration, Strength ),
          TweenType.ShakeScale => GameObject.TweenShakeScale( Duration, Strength ),

          TweenType.InCircle => GameObject.TweenInCircle( Duration, Axis, Range, Speed, Snapping ),
          TweenType.Spiral => GameObject.TweenSpiral( Duration, Axis, Speed, Frequency ),

          _ => null
       };

       if ( t != null )
       {
          t.Target = this.GameObject;
          t.LoopMode = LoopMode;
       }

       return t;
    }
}

public enum TweenType
{
    Move,
    MoveLocal,
    Rotate,
    RotateLocal,
    Scale,
    Move2D,
    MoveLocal2D,
    Tint,
    ShakeLocation,
    ShakeRotation, 
    ShakeScale,
    Spiral,
    InCircle
}
