using Sandbox;
using System;

namespace SbTween;

public static class SbTweenDooMethods
{
	// ── Light ──────────────────────────────────────────────────────────────

	[Doo.Method( "Tween Light Color", CategoryName = "SbTween/Light" )]
	public static void TweenLightColor( Light light, Color target, float duration )
		=> light.TweenLightColor( target, duration );

	[Doo.Method( "Tween Light Brightness (PointLight)", CategoryName = "SbTween/Light" )]
	public static void TweenPointLightBrightness( PointLight light, float target, float duration )
		=> light.TweenAttenuation( target, duration );

	[Doo.Method( "Tween Light Brightness (SpotLight)", CategoryName = "SbTween/Light" )]
	public static void TweenSpotLightBrightness( SpotLight light, float target, float duration )
		=> light.TweenAttenuation( target, duration );

	[Doo.Method( "Tween Radius (PointLight)", CategoryName = "SbTween/Light" )]
	public static void TweenPointLightRadius( PointLight light, float target, float duration )
		=> light.TweenRadius( target, duration );

	[Doo.Method( "Tween Radius (SpotLight)", CategoryName = "SbTween/Light" )]
	public static void TweenSpotLightRadius( SpotLight light, float target, float duration )
		=> light.TweenRadius( target, duration );

	[Doo.Method( "Tween Attenuation (PointLight)", CategoryName = "SbTween/Light" )]
	public static void TweenPointLightAttenuation( PointLight light, float target, float duration )
		=> light.TweenAttenuation( target, duration );

	[Doo.Method( "Tween Attenuation (SpotLight)", CategoryName = "SbTween/Light" )]
	public static void TweenSpotLightAttenuation( SpotLight light, float target, float duration )
		=> light.TweenAttenuation( target, duration );

	[Doo.Method( "Flicker Brightness (PointLight)", CategoryName = "SbTween/Light" )]
	public static void FlickerPointLightBrightness( PointLight light, float min, float max, float duration, float speed = 10f )
		=> light.TweenFlickerLight( min, max, duration, speed );

	[Doo.Method( "Flicker Brightness (SpotLight)", CategoryName = "SbTween/Light" )]
	public static void FlickerSpotLightBrightness( SpotLight light, float min, float max, float duration, float speed = 10f )
		=> light.TweenFlickerLight( min, max, duration, speed );

	[Doo.Method( "Flicker Color (PointLight)", CategoryName = "SbTween/Light" )]
	public static void FlickerPointLightColor( PointLight light, Color colorA, Color colorB, float duration, float speed = 10f )
		=> light.TweenFlickerColor( colorA, colorB, duration, speed );

	[Doo.Method( "Flicker Color (SpotLight)", CategoryName = "SbTween/Light" )]
	public static void FlickerSpotLightColor( SpotLight light, Color colorA, Color colorB, float duration, float speed = 10f )
		=> light.TweenFlickerColor( colorA, colorB, duration, speed );

	// ── Post Processing ────────────────────────────────────────────────────

	[Doo.Method( "Tween Bloom Strength", CategoryName = "SbTween/Post Processing" )]
	public static void TweenBloomStrength( Bloom bloom, float target, float duration )
		=> bloom.TweenStrength( target, duration );

	[Doo.Method( "Tween Bloom Threshold", CategoryName = "SbTween/Post Processing" )]
	public static void TweenBloomThreshold( Bloom bloom, float target, float duration )
		=> bloom.TweenThreshold( target, duration );

	[Doo.Method( "Tween Bloom Gamma", CategoryName = "SbTween/Post Processing" )]
	public static void TweenBloomGamma( Bloom bloom, float target, float duration )
		=> bloom.TweenGamma( target, duration );

	[Doo.Method( "Tween Bloom Tint", CategoryName = "SbTween/Post Processing" )]
	public static void TweenBloomTint( Bloom bloom, Color target, float duration )
		=> bloom.TweenTint( target, duration );

	[Doo.Method( "Tween Vignette Intensity", CategoryName = "SbTween/Post Processing" )]
	public static void TweenVignetteIntensity( Vignette vignette, float target, float duration )
		=> vignette.TweenIntensity( target, duration );

	[Doo.Method( "Tween Vignette Color", CategoryName = "SbTween/Post Processing" )]
	public static void TweenVignetteColor( Vignette vignette, Color target, float duration )
		=> vignette.TweenColor( target, duration );

	[Doo.Method( "Tween Vignette Smoothness", CategoryName = "SbTween/Post Processing" )]
	public static void TweenVignetteSmoothness( Vignette vignette, float target, float duration )
		=> vignette.TweenSmoothness( target, duration );

	[Doo.Method( "Tween Vignette Roundness", CategoryName = "SbTween/Post Processing" )]
	public static void TweenVignetteRoundness( Vignette vignette, float target, float duration )
		=> vignette.TweenRoundness( target, duration );

	[Doo.Method( "Tween ChromaticAberration Scale", CategoryName = "SbTween/Post Processing" )]
	public static void TweenChromaScale( ChromaticAberration ca, float target, float duration )
		=> ca.TweenScale( target, duration );

	[Doo.Method( "Tween DepthOfField Focal Distance", CategoryName = "SbTween/Post Processing" )]
	public static void TweenDOFFocalDistance( DepthOfField dof, float target, float duration )
		=> dof.TweenFocalDistance( target, duration );

	[Doo.Method( "Tween DepthOfField Blur Size", CategoryName = "SbTween/Post Processing" )]
	public static void TweenDOFBlurSize( DepthOfField dof, float target, float duration )
		=> dof.TweenBlurSize( target, duration );

	[Doo.Method( "Tween DepthOfField Focus Range", CategoryName = "SbTween/Post Processing" )]
	public static void TweenDOFFocusRange( DepthOfField dof, float target, float duration )
		=> dof.TweenFocusRange( target, duration );

	[Doo.Method( "Tween FilmGrain Intensity", CategoryName = "SbTween/Post Processing" )]
	public static void TweenFilmGrainIntensity( FilmGrain fg, float target, float duration )
		=> fg.TweenIntensity( target, duration );

	[Doo.Method( "Tween FilmGrain Response", CategoryName = "SbTween/Post Processing" )]
	public static void TweenFilmGrainResponse( FilmGrain fg, float target, float duration )
		=> fg.TweenResponse( target, duration );

	[Doo.Method( "Tween ColorAdjustments Saturation", CategoryName = "SbTween/Post Processing" )]
	public static void TweenSaturation( ColorAdjustments ca, float target, float duration )
		=> ca.TweenSaturation( target, duration );

	[Doo.Method( "Tween ColorAdjustments Brightness", CategoryName = "SbTween/Post Processing" )]
	public static void TweenBrightness( ColorAdjustments ca, float target, float duration )
		=> ca.TweenBrightness( target, duration );

	[Doo.Method( "Tween ColorAdjustments Contrast", CategoryName = "SbTween/Post Processing" )]
	public static void TweenContrast( ColorAdjustments ca, float target, float duration )
		=> ca.TweenContrast( target, duration );

	[Doo.Method( "Tween ColorAdjustments Blend", CategoryName = "SbTween/Post Processing" )]
	public static void TweenBlend( ColorAdjustments ca, float target, float duration )
		=> ca.TweenBlend( target, duration );

	[Doo.Method( "Tween ColorAdjustments HueRotate", CategoryName = "SbTween/Post Processing" )]
	public static void TweenHueRotate( ColorAdjustments ca, float target, float duration )
		=> ca.TweenHueRotate( target, duration );

	[Doo.Method( "Tween Blur Size", CategoryName = "SbTween/Post Processing" )]
	public static void TweenBlurSize( Blur blur, float target, float duration )
		=> blur.TweenSize( target, duration );

	// ── Text ───────────────────────────────────────────────────────────────

	[Doo.Method( "Typewriter", CategoryName = "SbTween/Text" )]
	public static void Typewriter( TextRenderer text, string fullText, float duration )
		=> text.Typewriter( fullText, duration );

	[Doo.Method( "Typewriter With Cursor", CategoryName = "SbTween/Text" )]
	public static void TypewriterWithCursor( TextRenderer text, string fullText, float duration, string cursor = "|" )
		=> text.TypewriterWithCursor( fullText, duration, cursor );

	[Doo.Method( "Tween Scale", CategoryName = "SbTween/Text" )]
	public static void TweenTextScale( TextRenderer text, float target, float duration )
		=> text.TweenScale( target, duration );

	[Doo.Method( "Tween Color", CategoryName = "SbTween/Text" )]
	public static void TweenTextColor( TextRenderer text, Color target, float duration )
		=> text.TweenColor( target, duration );

	[Doo.Method( "Tween Font Size", CategoryName = "SbTween/Text" )]
	public static void TweenFontSize( TextRenderer text, float target, float duration )
		=> text.TweenFontSize( target, duration );

	[Doo.Method( "Tween Font Weight", CategoryName = "SbTween/Text" )]
	public static void TweenFontWeight( TextRenderer text, int target, float duration )
		=> text.TweenFontWeight( target, duration );

	[Doo.Method( "Tween Outline Color", CategoryName = "SbTween/Text" )]
	public static void TweenOutlineColor( TextRenderer text, Color target, float duration )
		=> text.TweenOutlineColor( target, duration );

	[Doo.Method( "Tween Shadow Color", CategoryName = "SbTween/Text" )]
	public static void TweenShadowColor( TextRenderer text, Color target, float duration )
		=> text.TweenShadowColor( target, duration );

	[Doo.Method( "Tween Line Height", CategoryName = "SbTween/Text" )]
	public static void TweenLineHeight( TextRenderer text, float target, float duration )
		=> text.TweenLineHeight( target, duration );

	[Doo.Method( "Tween Letter Spacing", CategoryName = "SbTween/Text" )]
	public static void TweenLetterSpacing( TextRenderer text, float target, float duration )
		=> text.TweenLetterSpacing( target, duration );

	[Doo.Method( "Tween Word Spacing", CategoryName = "SbTween/Text" )]
	public static void TweenWordSpacing( TextRenderer text, float target, float duration )
		=> text.TweenWordSpacing( target, duration );
}
