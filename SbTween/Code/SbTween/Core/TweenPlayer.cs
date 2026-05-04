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

	[Property, Group( "Setup" ), HideIf( nameof( Type ), TweenType.Tint )] public Vector3 From { get; set; }
	[Property, Group( "Setup" ), HideIf( nameof( Type ), TweenType.Tint )] public Vector3 To { get; set; }

	[Property, Group( "Setup" ), ShowIf( nameof( Type ), TweenType.Tint )] public Color ColorFrom { get; set; } = Color.White;
	[Property, Group( "Setup" ), ShowIf( nameof( Type ), TweenType.Tint )] public Color ColorTo { get; set; } = Color.White;

	[Property, Group( "Setup" ), ShowIf( nameof( Type ), TweenType.ShakeLocation)] public float SLStrength { get; set; } = 1.0f;
	[Property, Group( "Setup" ), ShowIf( nameof( Type ), TweenType.ShakeRotation)] public float SRStrength { get; set; } = 1.0f;
	[Property, Group( "Setup" ), ShowIf( nameof( Type ), TweenType.ShakeScale)] public float SSStrength { get; set; } = 1.0f;


	// SETTINGS
	[Property, Group( "Settings" )] public float Duration { get; set; } = 1.0f;
	[Property, Group( "Settings" )] public float Delay { get; set; } = 0.0f;

	[Property, Group( "Settings" )]
	[Title( "Loops (0 = Once, -1 = Infinite)" )]
	public int Loops { get; set; } = 0;

	[Property, Group( "Settings" )] public bool Yoyo { get; set; } = false;

	[Property, Group( "Settings" )] public EaseType Easing { get; set; } = EaseType.Linear;
	[Property, Group( "Settings" )] public bool AutoPlay { get; set; } = true;

	[Property, Group( "Settings" )]
	public bool UseCurve { get; set; } = false;

	[Property, Group( "Settings" ), ShowIf( nameof( UseCurve ), true )]
	public Curve TweenCurve { get; set; } = Curve.Linear;


	// EVENTS
	[Property, Group( "Events" )] public Action _OnStart { get; set; }
	[Property, Group( "Events" )] public Action _OnComplete { get; set; }
	[Property, Group( "Debug" )] public bool GizmoDebug { get; set; } = true;


	private BaseTween _currentTween;
	private TweenSnapshot _initialState;
	private int _completedLoops = 0;
	private bool _isReversing = false;

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

		ResetToState( !_isReversing );

		GameObject.Transform.ClearInterpolation();

		_currentTween = CreateTweenInstance( _isReversing );

		_currentTween
			.SetDelay( Delay )
			.SetEase( Easing )
			.OnStart( () => {
				_OnStart?.Invoke();
			} )
			.OnComplete( () => HandleCompletion() );

		_currentTween.Play();
	}

	public void Stop()
	{
		StopInternal();
		_completedLoops = 0;
		_isReversing = false;

		if ( _initialState != null )
		{
			_initialState.Restore();
		}
		else
		{
			ResetToState( true );
		}
	}

	private void StopInternal()
	{
		_currentTween?.Stop();
		_currentTween = null;
	}

	private void HandleCompletion()
	{
		_OnComplete?.Invoke();

		if ( Yoyo )
		{
			_isReversing = !_isReversing;
			if ( !_isReversing && Loops != -1 ) _completedLoops++;

			if ( Loops == -1 || _completedLoops < Loops || _isReversing )
			{
				Play();
			}
		}
		else
		{
			if ( Loops == -1 || _completedLoops < Loops )
			{
				if ( Loops != -1 ) _completedLoops++;
				_isReversing = false;
				Play();
			}
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
		Vector3 targetVal = reverse ? From : To;
		Color targetColor = reverse ? ColorFrom : ColorTo;

		var t = Type switch
		{
			TweenType.Move => GameObject.TweenMove( targetVal, Duration ),
			TweenType.MoveLocal => GameObject.TweenMoveLocal( targetVal, Duration ),
			TweenType.Rotate => GameObject.TweenRotate( Rotation.From( targetVal.x, targetVal.y, targetVal.z ), Duration ),
			TweenType.RotateLocal => GameObject.TweenRotateLocal( Rotation.From( targetVal.x, targetVal.y, targetVal.z ), Duration ),
			TweenType.Scale => GameObject.TweenScale( targetVal, Duration ),
			TweenType.Tint => Components.Get<ModelRenderer>()?.TweenTint( targetColor, Duration ),

			TweenType.ShakeLocation => GameObject.TweenShakeLocation( Duration, SLStrength ),
			TweenType.ShakeRotation => GameObject.TweenShakeRotation( Duration, SRStrength ),
			TweenType.ShakeScale => GameObject.TweenShakeScale( Duration, SSStrength ),

			_ => null
		};

		//Tween failed.
		if ( t == null ) return null;

		if ( UseCurve )
		{
			t.WithCurve( TweenCurve );
		}
		else
		{
			t.SetEase( Easing );
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
	ShakeScale
}
