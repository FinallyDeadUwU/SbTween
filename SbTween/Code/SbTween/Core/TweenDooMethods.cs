using Sandbox;
using Sandbox.UI;
using System;
using System.Collections.Generic;

namespace SbTween;

public static class SbTweenDooMethods
{
    // UI TWEENS

    [Doo.Method( "Tween UI Size", CategoryName = "SbTween/UI" )]
    public static void TweenUISize( ScreenPanel screenPanel, float target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !screenPanel.IsValid() ) return;
        var tween = screenPanel.TweenSize( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween UI Opacity", CategoryName = "SbTween/UI" )]
    public static void TweenUIOpacity( ScreenPanel screenPanel, float target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !screenPanel.IsValid() ) return;
        var tween = screenPanel.TweenOpacity( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    // POST PROCESSING TWEENS

    [Doo.Method( "Tween FilmGrain Intensity", CategoryName = "SbTween/Post Processing" )]
    public static void TweenFilmGrainIntensity( FilmGrain fg, float target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !fg.IsValid() ) return;
        var tween = fg.TweenIntensity( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween FilmGrain Response", CategoryName = "SbTween/Post Processing" )]
    public static void TweenFilmGrainResponse( FilmGrain fg, float target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !fg.IsValid() ) return;
        var tween = fg.TweenResponse( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Bloom Strength", CategoryName = "SbTween/Post Processing" )]
    public static void TweenBloomStrength( Bloom bloom, float target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !bloom.IsValid() ) return;
        var tween = bloom.TweenStrength( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Bloom Threshold", CategoryName = "SbTween/Post Processing" )]
    public static void TweenBloomThreshold( Bloom bloom, float target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !bloom.IsValid() ) return;
        var tween = bloom.TweenThreshold( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Bloom Gamma", CategoryName = "SbTween/Post Processing" )]
    public static void TweenBloomGamma( Bloom bloom, float target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !bloom.IsValid() ) return;
        var tween = bloom.TweenGamma( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Bloom Tint", CategoryName = "SbTween/Post Processing" )]
    public static void TweenBloomTint( Bloom bloom, Color target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !bloom.IsValid() ) return;
        var tween = bloom.TweenTint( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Blur Size", CategoryName = "SbTween/Post Processing" )]
    public static void TweenBlurSize( Blur blur, float target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !blur.IsValid() ) return;
        var tween = blur.TweenSize( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween ChromaticAberration Scale", CategoryName = "SbTween/Post Processing" )]
    public static void TweenChromaScale( ChromaticAberration ca, float target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !ca.IsValid() ) return;
        var tween = ca.TweenScale( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween ChromaticAberration Offset", CategoryName = "SbTween/Post Processing" )]
    public static void TweenChromaOffset( ChromaticAberration ca, Vector3 target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !ca.IsValid() ) return;
        var tween = ca.TweenOffset( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween ColorAdjustments Blend", CategoryName = "SbTween/Post Processing" )]
    public static void TweenBlend( ColorAdjustments ca, float target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !ca.IsValid() ) return;
        var tween = ca.TweenBlend( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween ColorAdjustments Saturation", CategoryName = "SbTween/Post Processing" )]
    public static void TweenSaturation( ColorAdjustments ca, float target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !ca.IsValid() ) return;
        var tween = ca.TweenSaturation( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween ColorAdjustments HueRotate", CategoryName = "SbTween/Post Processing" )]
    public static void TweenHueRotate( ColorAdjustments ca, float target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !ca.IsValid() ) return;
        var tween = ca.TweenHueRotate( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween ColorAdjustments Brightness", CategoryName = "SbTween/Post Processing" )]
    public static void TweenBrightness( ColorAdjustments ca, float target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !ca.IsValid() ) return;
        var tween = ca.TweenBrightness( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween ColorAdjustments Contrast", CategoryName = "SbTween/Post Processing" )]
    public static void TweenContrast( ColorAdjustments ca, float target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !ca.IsValid() ) return;
        var tween = ca.TweenContrast( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Vignette Intensity", CategoryName = "SbTween/Post Processing" )]
    public static void TweenVignetteIntensity( Vignette vignette, float target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !vignette.IsValid() ) return;
        var tween = vignette.TweenIntensity( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Vignette Smoothness", CategoryName = "SbTween/Post Processing" )]
    public static void TweenVignetteSmoothness( Vignette vignette, float target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !vignette.IsValid() ) return;
        var tween = vignette.TweenSmoothness( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Vignette Roundness", CategoryName = "SbTween/Post Processing" )]
    public static void TweenVignetteRoundness( Vignette vignette, float target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !vignette.IsValid() ) return;
        var tween = vignette.TweenRoundness( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Vignette Color", CategoryName = "SbTween/Post Processing" )]
    public static void TweenVignetteColor( Vignette vignette, Color target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !vignette.IsValid() ) return;
        var tween = vignette.TweenColor( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Vignette Center", CategoryName = "SbTween/Post Processing" )]
    public static void TweenVignetteCenter( Vignette vignette, Vector2 target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !vignette.IsValid() ) return;
        var tween = vignette.TweenCenter( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween DepthOfField Blur Size", CategoryName = "SbTween/Post Processing" )]
    public static void TweenDOFBlurSize( DepthOfField dof, float target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !dof.IsValid() ) return;
        var tween = dof.TweenBlurSize( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween DepthOfField Focal Distance", CategoryName = "SbTween/Post Processing" )]
    public static void TweenDOFFocalDistance( DepthOfField dof, float target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !dof.IsValid() ) return;
        var tween = dof.TweenFocalDistance( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween DepthOfField Focus Range", CategoryName = "SbTween/Post Processing" )]
    public static void TweenDOFFocusRange( DepthOfField dof, float target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !dof.IsValid() ) return;
        var tween = dof.TweenFocusRange( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Sharpen Scale", CategoryName = "SbTween/Post Processing" )]
    public static void TweenSharpenScale( Sharpen pp, float target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !pp.IsValid() ) return;
        var tween = pp.TweenSharpen( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Sharpen Texel Size", CategoryName = "SbTween/Post Processing" )]
    public static void TweenSharpenTexelSize( Sharpen pp, float target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !pp.IsValid() ) return;
        var tween = pp.TweenTexelSize( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Pixelate Scale", CategoryName = "SbTween/Post Processing" )]
    public static void TweenPixelateScale( Pixelate pp, float target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !pp.IsValid() ) return;
        var tween = pp.TweenScale( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    // MOVEMENT & PATH TWEENS

    [Doo.Method( "Tween Follow Linear Path", CategoryName = "SbTween/Movement" )]
    public static void TweenPath( GameObject obj, List<Vector3> points, float duration = 1f, bool lookAhead = false, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !obj.IsValid() ) return;
        var tween = obj.TweenPath( points, duration, lookAhead );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Follow Curved Path", CategoryName = "SbTween/Movement" )]
    public static void TweenPathCurve( GameObject obj, List<Vector3> points, float duration = 1f, bool lookAhead = false, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !obj.IsValid() ) return;
        var tween = obj.TweenPathCurve( points, duration, lookAhead );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    // MATH & JUICE TWEENS

    [Doo.Method( "Tween Move In Circle", CategoryName = "SbTween/Math" )]
    public static void TweenInCircle( GameObject obj, float duration = 1f, Vector3 axis = default, float range = 10f, float speed = 1f, bool snapping = false, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !obj.IsValid() ) return;
        var tween = obj.TweenInCircle( duration, axis, range, speed, snapping );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Move In Spiral", CategoryName = "SbTween/Math" )]
    public static void TweenSpiral( GameObject obj, float duration = 1f, Vector3 axis = default, float speed = 1f, float frequency = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !obj.IsValid() ) return;
        var tween = obj.TweenSpiral( duration, axis, speed, frequency );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Punch Value (Float)", CategoryName = "SbTween/Juice" )]
    public static void TweenPunchFloat( GameObject obj, float baseline, float amplitude, float duration = 1f, int vibrations = 5, float elasticity = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart, Action<float> onUpdateProperty = null )
    {
        if ( !obj.IsValid() ) return;
        var tween = obj.TweenPunchFloat( baseline, amplitude, duration, vibrations, elasticity, onUpdateProperty );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    // BASIC TRANSFORMS

    [Doo.Method( "Tween Move Position", CategoryName = "SbTween/Transforms" )]
    public static void TweenMove( GameObject obj, Vector3 target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !obj.IsValid() ) return;
        var tween = obj.TweenMove( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Move Local Position", CategoryName = "SbTween/Transforms" )]
    public static void TweenMoveLocal( GameObject obj, Vector3 target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !obj.IsValid() ) return;
        var tween = obj.TweenMoveLocal( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Rotate Orientation", CategoryName = "SbTween/Transforms" )]
    public static void TweenRotate( GameObject obj, Rotation target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !obj.IsValid() ) return;
        var tween = obj.TweenRotate( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Rotate Local Orientation", CategoryName = "SbTween/Transforms" )]
    public static void TweenRotateLocal( GameObject obj, Rotation target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !obj.IsValid() ) return;
        var tween = obj.TweenRotateLocal( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Local Scale", CategoryName = "SbTween/Transforms" )]
    public static void TweenScale( GameObject obj, Vector3 target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !obj.IsValid() ) return;
        var tween = obj.TweenScale( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Move Position 2D", CategoryName = "SbTween/Transforms" )]
    public static void TweenMove2D( GameObject obj, Vector2 target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !obj.IsValid() ) return;
        var tween = obj.TweenMove2D( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Move Local Position 2D", CategoryName = "SbTween/Transforms" )]
    public static void TweenMoveLocal2D( GameObject obj, Vector2 target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !obj.IsValid() ) return;
        var tween = obj.TweenMoveLocal2D( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    // RENDERER TWEENS

    [Doo.Method( "Tween Renderer Tint Color", CategoryName = "SbTween/Render" )]
    public static void TweenTint( ModelRenderer mr, Color target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !mr.IsValid() ) return;
        var tween = mr.TweenTint( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    // FLOAT TWEEN
    [Doo.Method( "Tween Generic Value (Float)", CategoryName = "SbTween/Generic" )]
    public static void TweenFloat( GameObject obj, float start, float end, float duration = 1f, Action<float> setter = null, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !obj.IsValid() ) return;
        var tween = obj.TweenFloat( start, end, duration, setter );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }
    
    [Doo.Method( "Tween Shake Value (Float)", CategoryName = "SbTween/Generic" )]
    public static void TweenShakeFloat( GameObject obj, float baseline, float strength, float duration = 1f, Action<float> setter = null, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
	    if ( !obj.IsValid() ) return;
	    var tween = obj.TweenShakeFloat( baseline, strength, duration, setter );
	    SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    // SHAKER TWEENS

    [Doo.Method( "Tween Shake Location", CategoryName = "SbTween/Juice" )]
    public static void TweenShakeLocation( GameObject obj, float duration = 1f, float strength = 10f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !obj.IsValid() ) return;
        var tween = obj.TweenShakeLocation( duration, strength );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Shake Rotation", CategoryName = "SbTween/Juice" )]
    public static void TweenShakeRotation( GameObject obj, float duration = 1f, float strength = 5f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !obj.IsValid() ) return;
        var tween = obj.TweenShakeRotation( duration, strength );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Shake Scale", CategoryName = "SbTween/Juice" )]
    public static void TweenShakeScale( GameObject obj, float duration = 1f, float strength = 0.2f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !obj.IsValid() ) return;
        var tween = obj.TweenShakeScale( duration, strength );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    // TEXT TWEENS

    [Doo.Method( "Typewriter", CategoryName = "SbTween/Text" )]
    public static void Typewriter( TextRenderer text, string fullText, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !text.IsValid() ) return;
        var tween = text.Typewriter( fullText, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Typewriter With Cursor", CategoryName = "SbTween/Text" )]
    public static void TypewriterWithCursor( TextRenderer text, string fullText, float duration = 1f, string cursor = "|", string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !text.IsValid() ) return;
        var tween = text.TypewriterWithCursor( fullText, duration, cursor );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Scale", CategoryName = "SbTween/Text" )]
    public static void TweenTextScale( TextRenderer text, float target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !text.IsValid() ) return;
        var tween = text.TweenScale( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Color", CategoryName = "SbTween/Text" )]
    public static void TweenTextColor( TextRenderer text, Color target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !text.IsValid() ) return;
        var tween = text.TweenColor( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Font Size", CategoryName = "SbTween/Text" )]
    public static void TweenFontSize( TextRenderer text, float target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !text.IsValid() ) return;
        var tween = text.TweenFontSize( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    [Doo.Method( "Tween Font Weight", CategoryName = "SbTween/Text" )]
    public static void TweenFontWeight( TextRenderer text, int target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
        if ( !text.IsValid() ) return;
        var tween = text.TweenFontWeight( target, duration );
        SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }
    
    //AUDIO
    [Doo.Method( "Tween Sound Volume", CategoryName = "SbTween/Audio" )]
    public static void TweenVolumeDoo( SoundPointComponent sound, float target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
	    if ( !sound.IsValid() ) return;
	    var tween = sound.TweenVolume( target, duration );
        
	    tween.SetDelay( delay )
		    .SetLoops( loops, (LoopType)Math.Clamp( loopType, 0, 2 ) )
		    .SetEase( (EaseType)Math.Clamp( ease, 0, 9 ) );
	    SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }
    
    [Doo.Method( "Tween Sound Pitch", CategoryName = "SbTween/Audio" )]
    public static void TweenPitchDoo( SoundPointComponent sound, float target, float duration = 1f, string id = "", int ease = (int)EaseType.OutCubic, float delay = 0f, int loops = 0, int loopType = (int)LoopType.Restart )
    {
	    if ( !sound.IsValid() ) return;
	    var tween = sound.TweenPitch( target, duration );
	    SetupTween( tween, id, (EaseType)Math.Clamp( ease, 0, 9 ), delay, loops, (LoopType)Math.Clamp( loopType, 0, 2 ) );
    }

    // TWEEN SETUP

    private static void SetupTween(
       BaseTween tween,
       string id,
       EaseType ease,
       float delay,
       int loops,
       LoopType loopMode,
       Action onStart = null, //no actions for doo, until facepunch fixes json serization. sorry. :/
       Action<float> onUpdate = null,
       Action onLoop = null,
       Action onComplete = null)
    {
       if ( tween == null ) return;

       tween.SetDelay( delay )
          .SetLoops( loops, loopMode )
          .SetEase( ease );

       if ( !string.IsNullOrEmpty( id ) )
       {
	       tween.SetId( id );
       }
       else
       {
	       tween.SetId( tween.GetType().Name );
       }

       if ( onStart != null )    tween.OnStart( onStart );
       if ( onUpdate != null )   tween.OnUpdate( onUpdate );
       if ( onLoop != null )     tween.OnLoop( onLoop );
       if ( onComplete != null ) tween.OnComplete( onComplete );

       tween.Play();
    }
}
