using Sandbox;
using Sandbox.UI;
using System;

namespace SbTween;

public static class LightExtensions
{

	public static BaseTween TweenLightColor( this Light Light, Color target, float duration )
	{
		Color start = Light.LightColor;
		var tween = new BaseTween( duration );
		tween.Target = Light.GameObject;
		return TweenManager.Instance.AddTween( tween
			.OnStart( () => start = Light.LightColor )
			.OnUpdate( p => Light.LightColor = Color.Lerp( start, target, p ) ) );
	}

	public static BaseTween TweenRadius( this SpotLight light, float target, float duration )
	{
		if ( !light.IsValid() ) return null;

		float start = light.Radius;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = light.Radius )
			.OnUpdate( p => light.Radius = MathX.Lerp( start, target, p ) ) );
	}

	public static BaseTween TweenConeOuter( this SpotLight light, float target, float duration )
	{
		if ( !light.IsValid() ) return null;

		float start = light.ConeOuter;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = light.ConeOuter )
			.OnUpdate( p => light.ConeOuter = MathX.Lerp( start, target, p ) ) );
	}

	public static BaseTween TweenInnerCone( this SpotLight light, float target, float duration )
	{
		if ( !light.IsValid() ) return null;

		float start = light.ConeInner;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = light.ConeInner )
			.OnUpdate( p => light.ConeInner = MathX.Lerp( start, target, p ) ) );
	}

	public static BaseTween TweenAttenuation( this PointLight light, float target, float duration )
	{
		if ( !light.IsValid() ) return null;

		float start = light.Attenuation;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = light.Attenuation )
			.OnUpdate( p => light.Attenuation = MathX.Lerp( start, target, p ) ) );
	}

	public static BaseTween TweenAttenuation( this SpotLight light, float target, float duration )
	{
		if ( !light.IsValid() ) return null;

		float start = light.Attenuation;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = light.Attenuation )
			.OnUpdate( p => light.Attenuation = MathX.Lerp( start, target, p ) ) );
	}

	//FLICKERING LIGHT
	public static BaseTween TweenFlickerLight( this PointLight light, float minBrightness, float maxBrightness, float duration, float speed = 10f )
	{
		if ( !light.IsValid() ) return null;

		float time = 0f;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnUpdate( _ =>
			{
				time += Time.Delta * speed;
				float noise = MathF.Sin( time * 1.3f ) * MathF.Sin( time * 2.7f ) * MathF.Sin( time * 0.9f );
				float t = (noise + 1f) * 0.5f;
				light.Attenuation = MathX.Lerp( minBrightness, maxBrightness, t );
			} ) );
	}

	public static BaseTween TweenFlickerLight( this SpotLight light, float minBrightness, float maxBrightness, float duration, float speed = 10f )
	{
		if ( !light.IsValid() ) return null;

		float time = 0f;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnUpdate( _ =>
			{
				time += Time.Delta * speed;
				float noise = MathF.Sin( time * 1.3f ) * MathF.Sin( time * 2.7f ) * MathF.Sin( time * 0.9f );
				float t = (noise + 1f) * 0.5f;
				light.Attenuation = MathX.Lerp( minBrightness, maxBrightness, t );
			} ) );
	}

	//FLICKERING Color

	public static BaseTween TweenFlickerColor( this PointLight light, Color colorA, Color colorB, float duration, float speed = 10f )
	{
		if ( !light.IsValid() ) return null;

		float time = 0f;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnUpdate( _ =>
			{
				time += Time.Delta * speed;
				float noise = MathF.Sin( time * 1.3f ) * MathF.Sin( time * 2.7f ) * MathF.Sin( time * 0.9f );
				float t = (noise + 1f) * 0.5f;
				light.LightColor = Color.Lerp( colorA, colorB, t );
			} ) );
	}

	public static BaseTween TweenFlickerColor( this SpotLight light, Color colorA, Color colorB, float duration, float speed = 10f )
	{
		if ( !light.IsValid() ) return null;

		float time = 0f;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnUpdate( _ =>
			{
				time += Time.Delta * speed;
				float noise = MathF.Sin( time * 1.3f ) * MathF.Sin( time * 2.7f ) * MathF.Sin( time * 0.9f );
				float t = (noise + 1f) * 0.5f;
				light.LightColor = Color.Lerp( colorA, colorB, t );
			} ) );
	}

}
