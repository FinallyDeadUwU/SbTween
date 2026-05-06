using Sandbox;
using Sandbox.UI;
using System;

namespace SbTween;

public static class TweenExtensions
{
	// Shortcuts (! this is really important otherwise you can't hookup tweeners to components)


	// TIMELINE
	public static void Pause( this Component self, string id = null )
	{
		if ( string.IsNullOrEmpty( id ) )
			TweenManager.Instance?.Pause( self.GameObject );
		else
			TweenManager.Instance?.Pause( id );
	}

	public static void Play( this Component self, string id = null )
	{
		if ( string.IsNullOrEmpty( id ) )
			TweenManager.Instance?.Play( self.GameObject );
		else
			TweenManager.Instance?.Play( id );
	}

	public static void KillTween( this GameObject self, string id )
	{
		if ( string.IsNullOrEmpty( id ) ) return;

		TweenManager.Instance?.KillTweenOnObject( self, id );
	}

	public static void KillAllTweens( this GameObject self )
	{
		TweenManager.Instance?.KillAllTweensOnObject( self );
	}


	// TWEENS
	public static BaseTween TweenMove( this Component self, Vector3 target, float duration ) => self.GameObject.TweenMove( target, duration );
	public static BaseTween TweenMoveLocal( this Component self, Vector3 target, float duration ) => self.GameObject.TweenMoveLocal( target, duration );
	public static BaseTween TweenRotateLocal( this Component self, Rotation target, float duration ) => self.GameObject.TweenRotateLocal( target, duration );
	public static BaseTween TweenRotate( this Component self, Rotation target, float duration ) => self.GameObject.TweenRotate( target, duration );
	public static BaseTween TweenScale( this Component self, Vector3 target, float duration ) => self.GameObject.TweenScale( target, duration );
	public static BaseTween TweenShakeLocation( this Component self, float duration, float strength = 10f ) => self.GameObject.TweenShakeLocation( duration, strength );
	public static BaseTween TweenShakeRotation( this Component self, float duration, float strength = 5f ) => self.GameObject.TweenShakeRotation( duration, strength );
	public static BaseTween TweenShakeScale( this Component self, float duration, float strength = 0.2f ) => self.GameObject.TweenShakeScale( duration, strength );
	public static BaseTween TweenFloat( this Component self, float start, float end, float duration, Action<float> setter ) => self.GameObject.TweenFloat( start, end, duration, setter );

	// 3D VECTOR
	public static BaseTween TweenMove( this GameObject obj, Vector3 target, float duration )
	{
		Vector3 start = obj.WorldPosition;
		var tween = new BaseTween( duration );
		tween.Target = obj;
		return TweenManager.Instance.AddTween( tween
			.OnStart( () => start = obj.WorldPosition )
			.OnUpdate( p => obj.WorldPosition = Vector3.Lerp( start, target, p ) ) );
	}

	public static BaseTween TweenMoveLocal( this GameObject obj, Vector3 target, float duration )
	{
		Vector3 start = obj.LocalPosition;
		var tween = new BaseTween( duration );
		tween.Target = obj;
		return TweenManager.Instance.AddTween( tween
			.OnStart( () => start = obj.LocalPosition )
			.OnUpdate( p => obj.LocalPosition = Vector3.Lerp( start, target, p ) ) );
	}

	// 3D ROTATION
	public static BaseTween TweenRotate( this GameObject obj, Rotation target, float duration )
	{
		Rotation start = obj.WorldRotation;
		var tween = new BaseTween( duration );
		tween.Target = obj;
		return TweenManager.Instance.AddTween( tween
			.OnStart( () => start = obj.WorldRotation )
			.OnUpdate( p => obj.WorldRotation = Rotation.Lerp( start, target, p ) ) );
	}

	public static BaseTween TweenRotateLocal( this GameObject obj, Rotation target, float duration )
	{
		Rotation start = obj.LocalRotation;
		var tween = new BaseTween( duration );
		tween.Target = obj;
		return TweenManager.Instance.AddTween( tween
			.OnStart( () => start = obj.LocalRotation )
			.OnUpdate( p => obj.LocalRotation = Rotation.Lerp( start, target, p ) ) );
	}

	// 3D SCALE
	public static BaseTween TweenScale( this GameObject obj, Vector3 target, float duration )
	{
		Vector3 start = obj.LocalScale;
		var tween = new BaseTween( duration );
		tween.Target = obj;
		return TweenManager.Instance.AddTween( tween
			.OnStart( () => start = obj.LocalScale )
			.OnUpdate( p => obj.LocalScale = Vector3.Lerp( start, target, p ) ) );
	}

	// RENDER
	public static BaseTween TweenTint( this ModelRenderer mr, Color target, float duration )
	{
		Color start = mr.Tint;
		var tween = new BaseTween( duration );
		tween.Target = mr.GameObject;
		return TweenManager.Instance.AddTween( tween
			.OnStart( () => start = mr.Tint )
			.OnUpdate( p => mr.Tint = Color.Lerp( start, target, p ) ) );
	}

	// FLOAT TWEEN
	public static BaseTween TweenFloat( this GameObject obj, float start, float end, float duration, Action<float> setter )
	{
		var tween = new BaseTween( duration );
		tween.Target = obj;
		return TweenManager.Instance.AddTween( tween
			.OnUpdate( p => setter?.Invoke( MathX.Lerp( start, end, p ) ) ) );
	}

	// SHAKERS
	public static BaseTween TweenShakeLocation( this GameObject obj, float duration, float strength = 10f )
	{
		Vector3 startPos = obj.WorldPosition;
		var tween = new BaseTween( duration );
		tween.Target = obj;
		return TweenManager.Instance.AddTween( tween
			.OnStart( () => startPos = obj.WorldPosition )
			.OnUpdate( p => {
				if ( !obj.IsValid() ) return;
				var randomDir = new Vector3( Random.Shared.Float( -1, 1 ), Random.Shared.Float( -1, 1 ), Random.Shared.Float( -1, 1 ) );
				obj.WorldPosition = startPos + (randomDir * strength * (1 - p));
			} )
			.OnComplete( () => { if ( obj.IsValid() ) obj.WorldPosition = startPos; } ) );
	}

	public static BaseTween TweenShakeRotation( this GameObject obj, float duration, float strength = 5f )
	{
		Rotation startRot = obj.WorldRotation;
		var tween = new BaseTween( duration );
		tween.Target = obj;
		return TweenManager.Instance.AddTween( tween
			.OnStart( () => startRot = obj.WorldRotation )
			.OnUpdate( p => {
				if ( !obj.IsValid() ) return;
				var randomAngles = new Angles( Random.Shared.Float( -1, 1 ), Random.Shared.Float( -1, 1 ), Random.Shared.Float( -1, 1 ) );
				obj.WorldRotation = startRot * Rotation.From( randomAngles * strength * (1 - p) );
			} )
			.OnComplete( () => { if ( obj.IsValid() ) obj.WorldRotation = startRot; } ) );
	}

	public static BaseTween TweenShakeScale( this GameObject obj, float duration, float strength = 0.2f )
	{
		Vector3 startScale = obj.LocalScale;
		var tween = new BaseTween( duration );
		tween.Target = obj;
		return TweenManager.Instance.AddTween( tween
			.OnStart( () => startScale = obj.LocalScale )
			.OnUpdate( p => {
				if ( !obj.IsValid() ) return;
				var randomScale = new Vector3( Random.Shared.Float( -1, 1 ), Random.Shared.Float( -1, 1 ), Random.Shared.Float( -1, 1 ) );
				obj.LocalScale = startScale + (randomScale * strength * (1 - p));
			} )
			.OnComplete( () => { if ( obj.IsValid() ) obj.LocalScale = startScale; } ) );
	}
}
