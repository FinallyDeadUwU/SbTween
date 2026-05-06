using Sandbox;
using Sandbox.Services;
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


	// COLOR
	[Property, Group( "Setup" ), ShowIf( nameof( IsVector ), true )] public Vector3 From { get; set; }
	[Property, Group( "Setup" ), ShowIf( nameof( IsVector ), true )] public Vector3 To { get; set; }

	[Property, Group( "Setup" ), ShowIf( nameof( Type ), TweenType.Tint )] public Color ColorFrom { get; set; } = Color.White;
	[Property, Group( "Setup" ), ShowIf( nameof( Type ), TweenType.Tint )] public Color ColorTo { get; set; } = Color.White;

	// SHAKE
	[Property, Group( "Setup" ), ShowIf( nameof( IsShake ), true )] public float Strength { get; set; } = 1.0f;

	// SPIRAL
	[Property, Group( "Setup" ), ShowIf( nameof(IsCircularOrSpiral ), true )] public Vector3 Axis { get; set; } = Vector3.Up * 100f;

	[Property, Group( "Setup" ), ShowIf( nameof( IsCircularOrSpiral ), true )] public float Speed { get; set; } = 1f;

	[Property, Group( "Setup" ), ShowIf( nameof( IsCircularOrSpiral ), true )] public float Frequency { get; set; } = 5f;

	[Property, Group( "Setup" ), ShowIf( nameof( IsCircularOrSpiral ), true )] public float Range { get; set; } = 5f;

	// In Circle
	[Property, Group( "Setup" ), ShowIf( nameof( Type ), TweenType.InCircle )] public bool Snapping { get; set; } = false;
	

	// SETTINGS
	[Property, Group( "Settings" )] public float Duration { get; set; } = 1.0f;
	[Property, Group( "Settings" )] public float Delay { get; set; } = 0.0f;

	[Property, Group( "Settings" )]
	[Title( "Loops (0 = Once, -1 = Infinite)" )]
	public int Loops { get; set; } = 0;

	[Property, Group( "Setup" )] public LoopType LoopMode { get; set; } = LoopType.Restart;

	[Property, Group( "Settings" )] public EaseType Easing { get; set; } = EaseType.Linear;
	[Property, Group( "Settings" )] public bool AutoPlay { get; set; } = true;
	[Property, Group( "Settings" )] public string TweenID { get; set; } = "";

	[Property, Group( "Settings" )]
	public bool UseCurve { get; set; } = false;

	[Property, Group( "Settings" ), ShowIf( nameof( UseCurve ), true )]
	public Curve TweenCurve { get; set; } = Curve.Linear;


	// EVENTS
	[Property, Group( "Events" )] public Action _OnStart { get; set; }
	[Property, Group( "Events" )] public Action _OnComplete { get; set; }
	[Property, Group( "Debug" )] public bool GizmoDebug { get; set; } = true;


	// Editor stuff.
	[Hide] public bool IsCircularOrSpiral => Type == TweenType.InCircle || Type == TweenType.Spiral;
	[Hide] public bool IsShake => Type == TweenType.ShakeScale || Type == TweenType.ShakeLocation || Type == TweenType.ShakeRotation;
	[Hide] public bool IsVector => Type == TweenType.Move || Type == TweenType.MoveLocal || Type == TweenType.Rotate || Type == TweenType.RotateLocal || Type == TweenType.Scale;

	private BaseTween _currentTween;
	private TweenSnapshot _initialState;
	private int _completedLoops = 0;
	private bool _isReversing = false;
	private Vector3 _incrementalFrom;
	private Vector3 _incrementalTo;
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
			// GIZMO TRANSFORM.
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
			.SetEase( Easing )
			.OnStart( () => _OnStart?.Invoke() );

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

				if ( !_isReversing && Loops != -1 )
					_completedLoops++;

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
		Vector3 startVal = (LoopMode == LoopType.Incremental && _isIncrementalStarted) ? _incrementalFrom : From;
		Vector3 endVal = (LoopMode == LoopType.Incremental && _isIncrementalStarted) ? _incrementalTo : To;
		Vector3 targetVal = reverse ? startVal : endVal;

		Color targetColor = reverse ? ColorFrom : ColorTo;
		float effectiveSpeed = reverse ? -Speed : Speed;

		var t = Type switch
		{
			TweenType.Move => GameObject.TweenMove( targetVal, Duration ),
			TweenType.MoveLocal => GameObject.TweenMoveLocal( targetVal, Duration ),
			TweenType.Rotate => GameObject.TweenRotate( Rotation.From( targetVal.x, targetVal.y, targetVal.z ), Duration ),
			TweenType.RotateLocal => GameObject.TweenRotateLocal( Rotation.From( targetVal.x, targetVal.y, targetVal.z ), Duration ),
			TweenType.Scale => GameObject.TweenScale( targetVal, Duration ),
			TweenType.Tint => Components.Get<ModelRenderer>()?.TweenTint( targetColor, Duration ),

			TweenType.ShakeLocation => GameObject.TweenShakeLocation( Duration, Strength ),
			TweenType.ShakeRotation => GameObject.TweenShakeRotation( Duration, Strength ),
			TweenType.ShakeScale => GameObject.TweenShakeScale( Duration, Strength ),

			TweenType.InCircle => GameObject.TweenInCircle( Duration, Axis, Range, Speed, Snapping ),
			TweenType.Spiral => GameObject.TweenSpiral( Duration, Axis, Speed, Frequency ),

			_ => null
		};

		if ( t == null ) return null;

		if ( UseCurve ) t.WithCurve( TweenCurve );
		else t.SetEase( Easing );

		t.Target = this.GameObject;
		t.SetDelay( Delay );
		t.LoopMode = LoopMode;

		if ( !string.IsNullOrEmpty( TweenID ) )
		{
			t.SetId( TweenID );
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
	Tint,
	ShakeLocation,
	ShakeRotation, 
	ShakeScale,
	Spiral,
	InCircle
}
