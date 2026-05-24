using Sandbox;
using System;

namespace SbTween;

public static class PostProcessingExtensions
{
	// ── FilmGrain ──────────────────────────────────────────────────────────

	public static BaseTween TweenIntensity( this FilmGrain pp, float target, float duration )
	{
		if ( !pp.IsValid() ) return null;
		float start = pp.Intensity;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = pp.Intensity )
			.OnUpdate( p => pp.Intensity = MathX.Lerp( start, target, p ) ) );
	}

	public static BaseTween TweenResponse( this FilmGrain pp, float target, float duration )
	{
		if ( !pp.IsValid() ) return null;
		float start = pp.Response;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = pp.Response )
			.OnUpdate( p => pp.Response = MathX.Lerp( start, target, p ) ) );
	}

	// ── Bloom ──────────────────────────────────────────────────────────────

	public static BaseTween TweenStrength( this Bloom pp, float target, float duration )
	{
		if ( !pp.IsValid() ) return null;
		float start = pp.Strength;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = pp.Strength )
			.OnUpdate( p => pp.Strength = MathX.Lerp( start, target, p ) ) );
	}

	public static BaseTween TweenThreshold( this Bloom pp, float target, float duration )
	{
		if ( !pp.IsValid() ) return null;
		float start = pp.Threshold;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = pp.Threshold )
			.OnUpdate( p => pp.Threshold = MathX.Lerp( start, target, p ) ) );
	}

	public static BaseTween TweenGamma( this Bloom pp, float target, float duration )
	{
		if ( !pp.IsValid() ) return null;
		float start = pp.Gamma;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = pp.Gamma )
			.OnUpdate( p => pp.Gamma = MathX.Lerp( start, target, p ) ) );
	}

	public static BaseTween TweenTint( this Bloom pp, Color target, float duration )
	{
		if ( !pp.IsValid() ) return null;
		Color start = pp.Tint;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = pp.Tint )
			.OnUpdate( p => pp.Tint = Color.Lerp( start, target, p ) ) );
	}

	// ── Blur ──────────────────────────────────────────────────────────────

	public static BaseTween TweenSize( this Blur pp, float target, float duration )
	{
		if ( !pp.IsValid() ) return null;
		float start = pp.Size;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = pp.Size )
			.OnUpdate( p => pp.Size = MathX.Lerp( start, target, p ) ) );
	}

	// ── ChromaticAberration ────────────────────────────────────────────────

	public static BaseTween TweenScale( this ChromaticAberration pp, float target, float duration )
	{
		if ( !pp.IsValid() ) return null;
		float start = pp.Scale;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = pp.Scale )
			.OnUpdate( p => pp.Scale = MathX.Lerp( start, target, p ) ) );
	}

	public static BaseTween TweenOffset( this ChromaticAberration pp, Vector3 target, float duration )
	{
		if ( !pp.IsValid() ) return null;
		Vector3 start = pp.Offset;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = pp.Offset )
			.OnUpdate( p => pp.Offset = Vector3.Lerp( start, target, p ) ) );
	}

	// ── ColorAdjustments ──────────────────────────────────────────────────

	public static BaseTween TweenBlend( this ColorAdjustments pp, float target, float duration )
	{
		if ( !pp.IsValid() ) return null;
		float start = pp.Blend;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = pp.Blend )
			.OnUpdate( p => pp.Blend = MathX.Lerp( start, target, p ) ) );
	}

	public static BaseTween TweenSaturation( this ColorAdjustments pp, float target, float duration )
	{
		if ( !pp.IsValid() ) return null;
		float start = pp.Saturation;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = pp.Saturation )
			.OnUpdate( p => pp.Saturation = MathX.Lerp( start, target, p ) ) );
	}

	public static BaseTween TweenHueRotate( this ColorAdjustments pp, float target, float duration )
	{
		if ( !pp.IsValid() ) return null;
		float start = pp.HueRotate;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = pp.HueRotate )
			.OnUpdate( p => pp.HueRotate = MathX.Lerp( start, target, p ) ) );
	}

	public static BaseTween TweenBrightness( this ColorAdjustments pp, float target, float duration )
	{
		if ( !pp.IsValid() ) return null;
		float start = pp.Brightness;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = pp.Brightness )
			.OnUpdate( p => pp.Brightness = MathX.Lerp( start, target, p ) ) );
	}

	public static BaseTween TweenContrast( this ColorAdjustments pp, float target, float duration )
	{
		if ( !pp.IsValid() ) return null;
		float start = pp.Contrast;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = pp.Contrast )
			.OnUpdate( p => pp.Contrast = MathX.Lerp( start, target, p ) ) );
	}

	// ── Vignette ───────────────────────────────────────────────────────────

	public static BaseTween TweenIntensity( this Vignette pp, float target, float duration )
	{
		if ( !pp.IsValid() ) return null;
		float start = pp.Intensity;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = pp.Intensity )
			.OnUpdate( p => pp.Intensity = MathX.Lerp( start, target, p ) ) );
	}

	public static BaseTween TweenSmoothness( this Vignette pp, float target, float duration )
	{
		if ( !pp.IsValid() ) return null;
		float start = pp.Smoothness;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = pp.Smoothness )
			.OnUpdate( p => pp.Smoothness = MathX.Lerp( start, target, p ) ) );
	}

	public static BaseTween TweenRoundness( this Vignette pp, float target, float duration )
	{
		if ( !pp.IsValid() ) return null;
		float start = pp.Roundness;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = pp.Roundness )
			.OnUpdate( p => pp.Roundness = MathX.Lerp( start, target, p ) ) );
	}

	public static BaseTween TweenColor( this Vignette pp, Color target, float duration )
	{
		if ( !pp.IsValid() ) return null;
		Color start = pp.Color;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = pp.Color )
			.OnUpdate( p => pp.Color = Color.Lerp( start, target, p ) ) );
	}

	public static BaseTween TweenCenter( this Vignette pp, Vector2 target, float duration )
	{
		if ( !pp.IsValid() ) return null;
		Vector2 start = pp.Center;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = pp.Center )
			.OnUpdate( p => pp.Center = Vector2.Lerp( start, target, p ) ) );
	}

	// ── DepthOfField ───────────────────────────────────────────────────────

	public static BaseTween TweenBlurSize( this DepthOfField pp, float target, float duration )
	{
		if ( !pp.IsValid() ) return null;
		float start = pp.BlurSize;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = pp.BlurSize )
			.OnUpdate( p => pp.BlurSize = MathX.Lerp( start, target, p ) ) );
	}

	public static BaseTween TweenFocalDistance( this DepthOfField pp, float target, float duration )
	{
		if ( !pp.IsValid() ) return null;
		float start = pp.FocalDistance;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = pp.FocalDistance )
			.OnUpdate( p => pp.FocalDistance = MathX.Lerp( start, target, p ) ) );
	}

	public static BaseTween TweenFocusRange( this DepthOfField pp, float target, float duration )
	{
		if ( !pp.IsValid() ) return null;
		float start = pp.FocusRange;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = pp.FocusRange )
			.OnUpdate( p => pp.FocusRange = MathX.Lerp( start, target, p ) ) );
	}

	// ── Sharpen ───────────────────────────────────────────────────────────

	public static BaseTween TweenSharpen( this Sharpen pp, float target, float duration )
	{
		if ( !pp.IsValid() ) return null;
		float start = pp.Scale;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = pp.Scale )
			.OnUpdate( p => pp.Scale = MathX.Lerp( start, target, p ) ) );
	}
	public static BaseTween TweenTexelSize( this Sharpen pp, float target, float duration )
	{
		if ( !pp.IsValid() ) return null;
		float start = pp.TexelSize;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = pp.TexelSize )
			.OnUpdate( p => pp.TexelSize = MathX.Lerp( start, target, p ) ) );
	}

	// ── Pixelate ──────────────────────────────────────────────────────────

	public static BaseTween TweenScale( this Pixelate pp, float target, float duration )
	{
		if ( !pp.IsValid() ) return null;
		float start = pp.Scale;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = pp.Scale )
			.OnUpdate( p => pp.Scale = MathX.Lerp( start, target, p ) ) );
	}
}
