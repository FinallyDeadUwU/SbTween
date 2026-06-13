using Sandbox;
using Sandbox.UI;
using System;
using System.Collections.Generic;

namespace SbTween;

public static class SbTweenActionGraphMethods
{
    // UI TWEENS

    [ActionGraphNode( "sbtween.ui.size" ), Category( "SbTween/UI" )]
    public static void TweenUISize( 
        ScreenPanel screenPanel, float target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !screenPanel.IsValid() ) return;
       var tween = screenPanel.TweenSize( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.ui.opacity" ), Category( "SbTween/UI" )]
    public static void TweenUIOpacity( 
        ScreenPanel screenPanel, float target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !screenPanel.IsValid() ) return;
       var tween = screenPanel.TweenOpacity( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    // POST PROCESSING TWEENS

    [ActionGraphNode( "sbtween.post.filmgrain.intensity" ), Category( "SbTween/Post Processing" )]
    public static void TweenFilmGrainIntensity( 
        FilmGrain pp, float target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !pp.IsValid() ) return;
       var tween = pp.TweenIntensity( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.post.filmgrain.response" ), Category( "SbTween/Post Processing" )]
    public static void TweenFilmGrainResponse( 
        FilmGrain pp, float target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !pp.IsValid() ) return;
       var tween = pp.TweenResponse( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.post.bloom.strength" ), Category( "SbTween/Post Processing" )]
    public static void TweenBloomStrength( 
        Bloom pp, float target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !pp.IsValid() ) return;
       var tween = pp.TweenStrength( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.post.bloom.threshold" ), Category( "SbTween/Post Processing" )]
    public static void TweenBloomThreshold( 
        Bloom pp, float target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !pp.IsValid() ) return;
       var tween = pp.TweenThreshold( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.post.bloom.gamma" ), Category( "SbTween/Post Processing" )]
    public static void TweenBloomGamma( 
        Bloom pp, float target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !pp.IsValid() ) return;
       var tween = pp.TweenGamma( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.post.bloom.tint" ), Category( "SbTween/Post Processing" )]
    public static void TweenBloomTint( 
        Bloom pp, Color target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !pp.IsValid() ) return;
       var tween = pp.TweenTint( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.post.blur.size" ), Category( "SbTween/Post Processing" )]
    public static void TweenBlurSize( 
        Blur pp, float target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !pp.IsValid() ) return;
       var tween = pp.TweenSize( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.post.chroma.scale" ), Category( "SbTween/Post Processing" )]
    public static void TweenChromaScale( 
        ChromaticAberration pp, float target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !pp.IsValid() ) return;
       var tween = pp.TweenScale( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.post.chroma.offset" ), Category( "SbTween/Post Processing" )]
    public static void TweenChromaOffset( 
        ChromaticAberration pp, Vector3 target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !pp.IsValid() ) return;
       var tween = pp.TweenOffset( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.post.color.blend" ), Category( "SbTween/Post Processing" )]
    public static void TweenColorBlend( 
        ColorAdjustments pp, float target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !pp.IsValid() ) return;
       var tween = pp.TweenBlend( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.post.color.saturation" ), Category( "SbTween/Post Processing" )]
    public static void TweenColorSaturation( 
        ColorAdjustments pp, float target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !pp.IsValid() ) return;
       var tween = pp.TweenSaturation( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.post.color.huerotate" ), Category( "SbTween/Post Processing" )]
    public static void TweenColorHueRotate( 
        ColorAdjustments pp, float target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !pp.IsValid() ) return;
       var tween = pp.TweenHueRotate( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.post.color.brightness" ), Category( "SbTween/Post Processing" )]
    public static void TweenColorBrightness( 
        ColorAdjustments pp, float target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !pp.IsValid() ) return;
       var tween = pp.TweenBrightness( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.post.color.contrast" ), Category( "SbTween/Post Processing" )]
    public static void TweenColorContrast( 
        ColorAdjustments pp, float target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !pp.IsValid() ) return;
       var tween = pp.TweenContrast( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.post.vignette.intensity" ), Category( "SbTween/Post Processing" )]
    public static void TweenVignetteIntensity( 
        Vignette pp, float target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !pp.IsValid() ) return;
       var tween = pp.TweenIntensity( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.post.vignette.smoothness" ), Category( "SbTween/Post Processing" )]
    public static void TweenVignetteSmoothness( 
        Vignette pp, float target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !pp.IsValid() ) return;
       var tween = pp.TweenSmoothness( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.post.vignette.roundness" ), Category( "SbTween/Post Processing" )]
    public static void TweenVignetteRoundness( 
        Vignette pp, float target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !pp.IsValid() ) return;
       var tween = pp.TweenRoundness( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.post.vignette.color" ), Category( "SbTween/Post Processing" )]
    public static void TweenVignetteColor( 
        Vignette pp, Color target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !pp.IsValid() ) return;
       var tween = pp.TweenColor( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.post.vignette.center" ), Category( "SbTween/Post Processing" )]
    public static void TweenVignetteCenter( 
        Vignette pp, Vector2 target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !pp.IsValid() ) return;
       var tween = pp.TweenCenter( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.post.dof.blursize" ), Category( "SbTween/Post Processing" )]
    public static void TweenDOFBlurSize( 
        DepthOfField pp, float target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !pp.IsValid() ) return;
       var tween = pp.TweenBlurSize( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.post.dof.focaldistance" ), Category( "SbTween/Post Processing" )]
    public static void TweenDOFFocalDistance( 
        DepthOfField pp, float target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !pp.IsValid() ) return;
       var tween = pp.TweenFocalDistance( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.post.dof.focusrange" ), Category( "SbTween/Post Processing" )]
    public static void TweenDOFFocusRange( 
        DepthOfField pp, float target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !pp.IsValid() ) return;
       var tween = pp.TweenFocusRange( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.post.sharpen.scale" ), Category( "SbTween/Post Processing" )]
    public static void TweenSharpenScale( 
        Sharpen pp, float target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !pp.IsValid() ) return;
       var tween = pp.TweenSharpen( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.post.sharpen.texelsize" ), Category( "SbTween/Post Processing" )]
    public static void TweenSharpenTexelSize( 
        Sharpen pp, float target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !pp.IsValid() ) return;
       var tween = pp.TweenTexelSize( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.post.pixelate.scale" ), Category( "SbTween/Post Processing" )]
    public static void TweenPixelateScale( 
        Pixelate pp, float target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !pp.IsValid() ) return;
       var tween = pp.TweenScale( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    // PATH TWEENS

    [ActionGraphNode( "sbtween.movement.path" ), Category( "SbTween/Movement" )]
    public static void TweenPath( 
        GameObject obj, List<Vector3> points, float duration, bool lookAhead = false, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !obj.IsValid() ) return;
       var tween = obj.TweenPath( points, duration, lookAhead );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.movement.pathcurve" ), Category( "SbTween/Movement" )]
    public static void TweenPathCurve( 
        GameObject obj, List<Vector3> points, float duration, bool lookAhead = false, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !obj.IsValid() ) return;
       var tween = obj.TweenPathCurve( points, duration, lookAhead );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    // MATH TWEENS & JUICE
    
    [ActionGraphNode( "sbtween.math.incircle" ), Category( "SbTween/Math" )]
    public static void TweenInCircle( 
        GameObject obj, float duration, Vector3 axis, float range, float speed, bool snapping = false, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !obj.IsValid() ) return;
       var tween = obj.TweenInCircle( duration, axis, range, speed, snapping );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.math.spiral" ), Category( "SbTween/Math" )]
    public static void TweenSpiral( 
        GameObject obj, float duration, Vector3 axis, float speed, float frequency, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !obj.IsValid() ) return;
       var tween = obj.TweenSpiral( duration, axis, speed, frequency );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.juice.punchfloat" ), Category( "SbTween/Juice" )]
    public static void TweenPunchFloat( 
        GameObject obj, float baseline, float amplitude, float duration, int vibrations = 5, float elasticity = 1f, string id = null,
        Action<float> onUpdateProperty = null, Action onStart = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !obj.IsValid() ) return;
       var tween = obj.TweenPunchFloat( baseline, amplitude, duration, vibrations, elasticity, onUpdateProperty );
       
       if ( !string.IsNullOrEmpty( id ) ) tween.SetId( id );
       
       if ( onStart != null )    tween.OnStart( onStart );
       if ( onLoop != null )     tween.OnLoop( onLoop );
       if ( onComplete != null ) tween.OnComplete( onComplete );

       tween.Play();
    }
    
    [ActionGraphNode( "sbtween.juice.shakefloat" ), Category( "SbTween/Juice" )]
    public static void TweenShakeFloat( 
	    GameObject obj, float baseline, float strength, float duration, string id = null,
	    Action<float> onUpdateProperty = null, Action onStart = null, Action onLoop = null, Action onComplete = null )
    {
	    if ( !obj.IsValid() ) return;
   
	    var tween = obj.TweenShakeFloat( baseline, strength, duration, onUpdateProperty );
   
	    if ( !string.IsNullOrEmpty( id ) ) 
		    tween.SetId( id );
	    else
		    tween.SetId( "ShakeFloat" );
   
	    if ( onStart != null )    tween.OnStart( onStart );
	    if ( onLoop != null )     tween.OnLoop( onLoop );
	    if ( onComplete != null ) tween.OnComplete( onComplete );

	    tween.Play();
    }

    // BASIC TRANSFORMS

    [ActionGraphNode( "sbtween.transform.move" ), Category( "SbTween/Transforms" )]
    public static void TweenMove( 
        GameObject obj, Vector3 target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
        if ( !obj.IsValid() ) return;
        var tween = obj.TweenMove( target, duration );
        ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.transform.movelocal" ), Category( "SbTween/Transforms" )]
    public static void TweenMoveLocal( 
        GameObject obj, Vector3 target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !obj.IsValid() ) return;
       var tween = obj.TweenMoveLocal( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.transform.rotate" ), Category( "SbTween/Transforms" )]
    public static void TweenRotate( 
        GameObject obj, Rotation target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !obj.IsValid() ) return;
       var tween = obj.TweenRotate( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.transform.rotatelocal" ), Category( "SbTween/Transforms" )]
    public static void TweenRotateLocal( 
        GameObject obj, Rotation target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !obj.IsValid() ) return;
       var tween = obj.TweenRotateLocal( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.transform.scale" ), Category( "SbTween/Transforms" )]
    public static void TweenScale( 
        GameObject obj, Vector3 target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !obj.IsValid() ) return;
       var tween = obj.TweenScale( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.transform.move2d" ), Category( "SbTween/Transforms" )]
    public static void TweenMove2D( 
        GameObject obj, Vector2 target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !obj.IsValid() ) return;
       var tween = obj.TweenMove2D( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.transform.movelocal2d" ), Category( "SbTween/Transforms" )]
    public static void TweenMoveLocal2D( 
        GameObject obj, Vector2 target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !obj.IsValid() ) return;
       var tween = obj.TweenMoveLocal2D( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    // RENDERER TWEENS

    [ActionGraphNode( "sbtween.render.tint" ), Category( "SbTween/Render" )]
    public static void TweenTint( 
        ModelRenderer mr, Color target, float duration, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !mr.IsValid() ) return;
       var tween = mr.TweenTint( target, duration );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    // FLOAT TWEEN

    [ActionGraphNode( "sbtween.generic.float" ), Category( "SbTween/Generic" )]
    public static void TweenFloat( 
        GameObject obj, float start, float end, float duration, Action<float> setter, string id = null,
        EaseType ease = EaseType.Linear, float delay = 0f, int loops = 0, LoopType loopMode = LoopType.Restart,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !obj.IsValid() ) return;
       var tween = obj.TweenFloat( start, end, duration, setter );
       ExecuteGraphTween( tween, id, ease, delay, loops, loopMode, onStart, onUpdate, onLoop, onComplete );
    }

    // SHAKER TWEENS

    [ActionGraphNode( "sbtween.juice.shakelocation" ), Category( "SbTween/Juice" )]
    public static void TweenShakeLocation( 
        GameObject obj, float duration, float strength = 10f, string id = null,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !obj.IsValid() ) return;
       var tween = obj.TweenShakeLocation( duration, strength );
       ExecuteGraphTween( tween, id, EaseType.Linear, 0f, 0, LoopType.Restart, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.juice.shakerotation" ), Category( "SbTween/Juice" )]
    public static void TweenShakeRotation( 
        GameObject obj, float duration, float strength = 5f, string id = null,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !obj.IsValid() ) return;
       var tween = obj.TweenShakeRotation( duration, strength );
       ExecuteGraphTween( tween, id, EaseType.Linear, 0f, 0, LoopType.Restart, onStart, onUpdate, onLoop, onComplete );
    }

    [ActionGraphNode( "sbtween.juice.shakescale" ), Category( "SbTween/Juice" )]
    public static void TweenShakeScale( 
        GameObject obj, float duration, float strength = 0.2f, string id = null,
        Action onStart = null, Action<float> onUpdate = null, Action onLoop = null, Action onComplete = null )
    {
       if ( !obj.IsValid() ) return;
       var tween = obj.TweenShakeScale( duration, strength );
       ExecuteGraphTween( tween, id, EaseType.Linear, 0f, 0, LoopType.Restart, onStart, onUpdate, onLoop, onComplete );
    }

    // ==========================================
    // INTERNAL LIFECYCLE ENGINE DRIVER
    // ==========================================

    private static void ExecuteGraphTween( 
        BaseTween tween, string id, EaseType ease, float delay, int loops, LoopType loopMode,
        Action onStart, Action<float> onUpdate, Action onLoop, Action onComplete )
    {
        if ( tween == null ) return;

        // 1. Core settings configuration
        tween.SetDelay( delay )
             .SetLoops( loops, loopMode )
             .SetEase( ease );

        if ( !string.IsNullOrEmpty( id ) ) 
        {
           tween.SetId( id );
        }
        
        tween.OnStart( onStart );
        tween.OnLoop( onLoop );
        tween.OnComplete( onComplete );
        tween.OnUpdate( onUpdate );
        tween.Play();
    }
}
