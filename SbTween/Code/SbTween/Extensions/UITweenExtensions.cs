using Sandbox;
using Sandbox.UI;
using System;

namespace SbTween;

public static class UITweenExtensions
{
	public static BaseTween TweenSize( this ScreenPanel screenPanel, float target, float duration )
	{
		if ( !screenPanel.IsValid() ) return null;

		float start = screenPanel.Scale;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnUpdate( p => screenPanel.Scale = MathX.Lerp( start, target, p ) ) );
	}

	public static BaseTween TweenOpacity( this ScreenPanel screenPanel, float target, float duration )
	{
		if ( !screenPanel.IsValid() ) return null;

		float start = screenPanel.Opacity;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnUpdate( p => screenPanel.Opacity = MathX.Lerp( start, target, p ) ) );
	}
}
