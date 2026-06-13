using Sandbox;

namespace SbTween;

public static class MiscExtensions
{
	// DECALS
	public static BaseTween TweenLifeTime( this Decal self, float target, float duration )
    {
       if ( !self.IsValid() ) return null;
       float start = self.LifeTime.ConstantValue; 
       return TweenManager.Instance.AddTween( new BaseTween( duration )
          .OnUpdate( p => self.LifeTime = MathX.Lerp( start, target, p ) ) );
    }

    public static BaseTween TweenSize( this Decal self, Vector2 target, float duration )
    {
       if ( !self.IsValid() ) return null;
       Vector2 start = self.Size;
       return TweenManager.Instance.AddTween( new BaseTween( duration )
          .OnUpdate( p => self.Size = Vector2.Lerp( start, target, p ) ) );
    }

    public static BaseTween TweenScale( this Decal self, float target, float duration )
    {
       if ( !self.IsValid() ) return null;
       float start = self.Scale.ConstantValue;
       return TweenManager.Instance.AddTween( new BaseTween( duration )
          .OnUpdate( p => self.Scale = MathX.Lerp( start, target, p ) ) );
    }

    public static BaseTween TweenRotation( this Decal self, float target, float duration )
    {
       if ( !self.IsValid() ) return null;
       float start = self.Rotation.ConstantValue;
       return TweenManager.Instance.AddTween( new BaseTween( duration )
          .OnUpdate( p => self.Rotation = MathX.Lerp( start, target, p ) ) );
    }

    public static BaseTween TweenDepth( this Decal self, float target, float duration )
    {
       if ( !self.IsValid() ) return null;
       float start = self.Depth;
       return TweenManager.Instance.AddTween( new BaseTween( duration )
          .OnUpdate( p => self.Depth = MathX.Lerp( start, target, p ) ) );
    }

    public static BaseTween TweenParallax( this Decal self, float target, float duration )
    {
       if ( !self.IsValid() ) return null;
       float start = self.Parallax.ConstantValue;
       return TweenManager.Instance.AddTween( new BaseTween( duration )
          .OnUpdate( p => self.Parallax = MathX.Lerp( start, target, p ) ) );
    }

    public static BaseTween TweenColorTint( this Decal self, Color target, float duration )
    {
       if ( !self.IsValid() ) return null;
       Color start = self.ColorTint.ConstantValue;
       return TweenManager.Instance.AddTween( new BaseTween( duration )
          .OnUpdate( p => self.ColorTint = Color.Lerp( start, target, p ) ) );
    }

    public static BaseTween TweenColorMix( this Decal self, float target, float duration )
    {
       if ( !self.IsValid() ) return null;
       float start = self.ColorMix.ConstantValue;
       return TweenManager.Instance.AddTween( new BaseTween( duration )
          .OnUpdate( p => self.ColorMix = MathX.Lerp( start, target, p ) ) );
    }
    
    // CUBEMAP FOG 

    public static BaseTween TweenBlur( this CubemapFog self, float target, float duration )
    {
       if ( !self.IsValid() ) return null;
       float start = self.Blur;
       return TweenManager.Instance.AddTween( new BaseTween( duration )
          .OnUpdate( p => self.Blur = MathX.Lerp( start, target, p ) ) );
    }

    public static BaseTween TweenStartDistance( this CubemapFog self, float target, float duration )
    {
       if ( !self.IsValid() ) return null;
       float start = self.StartDistance;
       return TweenManager.Instance.AddTween( new BaseTween( duration )
          .OnUpdate( p => self.StartDistance = MathX.Lerp( start, target, p ) ) );
    }

    public static BaseTween TweenEndDistance( this CubemapFog self, float target, float duration )
    {
       if ( !self.IsValid() ) return null;
       float start = self.EndDistance;
       return TweenManager.Instance.AddTween( new BaseTween( duration )
          .OnUpdate( p => self.EndDistance = MathX.Lerp( start, target, p ) ) );
    }

    public static BaseTween TweenFalloffExponent( this CubemapFog self, float target, float duration )
    {
       if ( !self.IsValid() ) return null;
       float start = self.FalloffExponent;
       return TweenManager.Instance.AddTween( new BaseTween( duration )
          .OnUpdate( p => self.FalloffExponent = MathX.Lerp( start, target, p ) ) );
    }

    public static BaseTween TweenHeightWidth( this CubemapFog self, float target, float duration )
    {
       if ( !self.IsValid() ) return null;
       float start = self.HeightWidth;
       return TweenManager.Instance.AddTween( new BaseTween( duration )
          .OnUpdate( p => self.HeightWidth = MathX.Lerp( start, target, p ) ) );
    }

    public static BaseTween TweenHeightStart( this CubemapFog self, float target, float duration )
    {
       if ( !self.IsValid() ) return null;
       float start = self.HeightStart;
       return TweenManager.Instance.AddTween( new BaseTween( duration )
          .OnUpdate( p => self.HeightStart = MathX.Lerp( start, target, p ) ) );
    }

    public static BaseTween TweenHeightExponent( this CubemapFog self, float target, float duration )
    {
       if ( !self.IsValid() ) return null;
       float start = self.HeightExponent;
       return TweenManager.Instance.AddTween( new BaseTween( duration )
          .OnUpdate( p => self.HeightExponent = MathX.Lerp( start, target, p ) ) );
    }

    public static BaseTween TweenTint( this CubemapFog self, Color target, float duration )
    {
       if ( !self.IsValid() ) return null;
       Color start = self.Tint;
       return TweenManager.Instance.AddTween( new BaseTween( duration )
          .OnUpdate( p => self.Tint = Color.Lerp( start, target, p ) ) );
    }
    
    // GRADIENT FOG

    public static BaseTween TweenStartDistance( this GradientFog self, float target, float duration )
    {
       if ( !self.IsValid() ) return null;
       float start = self.StartDistance;
       return TweenManager.Instance.AddTween( new BaseTween( duration )
          .OnUpdate( p => self.StartDistance = MathX.Lerp( start, target, p ) ) );
    }

    public static BaseTween TweenEndDistance( this GradientFog self, float target, float duration )
    {
       if ( !self.IsValid() ) return null;
       float start = self.EndDistance;
       return TweenManager.Instance.AddTween( new BaseTween( duration )
          .OnUpdate( p => self.EndDistance = MathX.Lerp( start, target, p ) ) );
    }

    public static BaseTween TweenFalloffExponent( this GradientFog self, float target, float duration )
    {
       if ( !self.IsValid() ) return null;
       float start = self.FalloffExponent;
       return TweenManager.Instance.AddTween( new BaseTween( duration )
          .OnUpdate( p => self.FalloffExponent = MathX.Lerp( start, target, p ) ) );
    }

    public static BaseTween TweenColor( this GradientFog self, Color target, float duration )
    {
       if ( !self.IsValid() ) return null;
       Color start = self.Color;
       return TweenManager.Instance.AddTween( new BaseTween( duration )
          .OnUpdate( p => self.Color = Color.Lerp( start, target, p ) ) );
    }

    public static BaseTween TweenHeight( this GradientFog self, float target, float duration )
    {
       if ( !self.IsValid() ) return null;
       float start = self.Height;
       return TweenManager.Instance.AddTween( new BaseTween( duration )
          .OnUpdate( p => self.Height = MathX.Lerp( start, target, p ) ) );
    }

    public static BaseTween TweenVerticalFalloffExponent( this GradientFog self, float target, float duration )
    {
       if ( !self.IsValid() ) return null;
       float start = self.VerticalFalloffExponent;
       return TweenManager.Instance.AddTween( new BaseTween( duration )
          .OnUpdate( p => self.VerticalFalloffExponent = MathX.Lerp( start, target, p ) ) );
    }
    
    // VOLUMETRIC FOG

    public static BaseTween TweenStrength( this VolumetricFogVolume self, float target, float duration )
    {
	    if ( !self.IsValid() ) return null;
	    float start = self.Strength;
	    return TweenManager.Instance.AddTween( new BaseTween( duration )
		    .OnUpdate( p => self.Strength = MathX.Lerp( start, target, p ) ) );
    }

    public static BaseTween TweenFalloffExponent( this VolumetricFogVolume self, float target, float duration )
    {
	    if ( !self.IsValid() ) return null;
	    float start = self.FalloffExponent;
	    return TweenManager.Instance.AddTween( new BaseTween( duration )
		    .OnUpdate( p => self.FalloffExponent = MathX.Lerp( start, target, p ) ) );
    }

    public static BaseTween TweenColor( this VolumetricFogVolume self, Color target, float duration )
    {
	    if ( !self.IsValid() ) return null;
	    Color start = self.Color;
	    return TweenManager.Instance.AddTween( new BaseTween( duration )
		    .OnUpdate( p => self.Color = Color.Lerp( start, target, p ) ) );
    }
}
