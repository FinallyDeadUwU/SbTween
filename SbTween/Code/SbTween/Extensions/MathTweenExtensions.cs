using Sandbox;
using System;

namespace SbTween;

public static class MathTweenExtensions
{
	public static BaseTween TweenInCircle( this GameObject obj, float duration, Vector3 axis, float range, float speed, bool snapping = false )
	{
		Vector3 centerPos = obj.WorldPosition;
		var tween = new BaseTween( duration );
		tween.Target = obj;

		Vector3 normal = axis.Normal;
		Vector3 v1 = Vector3.Cross( normal, MathF.Abs( normal.z ) < 0.9f ? Vector3.Up : Vector3.Forward ).Normal;
		Vector3 v2 = Vector3.Cross( normal, v1 ).Normal;

		return TweenManager.Instance.AddTween( tween
			.OnUpdate( p =>
			{
				if ( !obj.IsValid() ) return;

				float angleDegrees = p * 360f * speed;
				float angleRadians = angleDegrees * (MathF.PI / 180f);

				float cos = MathF.Cos( angleRadians ) * range;
				float sin = MathF.Sin( angleRadians ) * range;

				Vector3 rotatedOffset = (v1 * cos) + (v2 * sin);
				obj.WorldPosition = centerPos + rotatedOffset;
			} )
		);
	}

	public static BaseTween TweenSpiral( this GameObject obj, float duration, Vector3 axis, float speed, float frequency )
	{
		Vector3 startPos = obj.WorldPosition;
		var tween = new BaseTween( duration );
		tween.Target = obj;

		return TweenManager.Instance.AddTween( tween
			.OnStart( () => startPos = obj.WorldPosition )
			.OnUpdate( p =>
			{
				if ( !obj.IsValid() ) return;

				float angle = p * MathF.PI * 2f * frequency;

				float currentRadius = p * speed;

				float x = MathF.Cos( angle ) * currentRadius;
				float y = MathF.Sin( angle ) * currentRadius;

				Vector3 axisOffset = axis * p;

				Vector3 circleOffset = new Vector3( x, y, 0 );

				obj.WorldPosition = startPos + axisOffset + circleOffset;
			} )
		);
	}
	
	public static BaseTween TweenPunchFloat( this GameObject obj, float v, float amplitude, float duration, int vibrations = 5, float elasticity = 1f, Action<float> setter = null )
	{
		var tween = new BaseTween( duration );
		tween.Target = obj;

		return TweenManager.Instance.AddTween( tween
			.OnUpdate( p =>
			{
				if ( !obj.IsValid() ) return;
				if ( p >= 1.0f )
				{
					setter?.Invoke( v );
					return;
				}
				
				float decay = MathF.Pow( 1f - p, elasticity * 3f );

				float omega = vibrations * MathF.PI * 2f;
				float oscillation = MathF.Sin( p * omega );

				float currentOffset = amplitude * oscillation * decay;

				setter?.Invoke( v + currentOffset );
			} )
			.OnComplete( () => setter?.Invoke( v ) )
		);
	}
	
	public static BaseTween TweenShakeFloat( this GameObject obj, float baseline, float strength, float duration, Action<float> setter = null )
	{
		var tween = new BaseTween( duration );
		tween.Target = obj;

		return TweenManager.Instance.AddTween( tween
			.OnUpdate( p =>
			{
				if ( !obj.IsValid() ) return;
				if ( p >= 1.0f )
				{
					setter?.Invoke( baseline );
					return;
				}

				float currentStrength = strength * (1.0f - p);
             
				float randomOffset = Game.Random.Float( -currentStrength, currentStrength );

				setter?.Invoke( baseline + randomOffset );
			} )
			.OnComplete( () => setter?.Invoke( baseline ) )
		);
	}
}
