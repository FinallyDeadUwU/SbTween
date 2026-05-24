using Sandbox;
using System;

namespace SbTween;

public static class TextRendererExtensions
{

	public static BaseTween TweenColor( this TextRenderer text, Color target, float duration )
	{
		if ( !text.IsValid() ) return null;

		Color start = text.Color;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = text.Color )
			.OnUpdate( p => text.Color = Color.Lerp( start, target, p ) ) );
	}

	public static BaseTween TweenFontSize( this TextRenderer text, float target, float duration )
	{
		if ( !text.IsValid() ) return null;

		float start = text.FontSize;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = text.FontSize )
			.OnUpdate( p => text.FontSize = MathX.Lerp( start, target, p ) ) );
	}

	public static BaseTween TweenFontWeight( this TextRenderer text, int target, float duration )
	{
		if ( !text.IsValid() ) return null;

		int start = text.FontWeight;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = text.FontWeight )
			.OnUpdate( p => text.FontWeight = (int)MathX.Lerp( start, target, p ) ) );
	}

	public static BaseTween TweenFogStrength( this TextRenderer text, float target, float duration )
	{
		if ( !text.IsValid() ) return null;

		float start = text.FogStrength;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = text.FogStrength )
			.OnUpdate( p => text.FogStrength = MathX.Lerp( start, target, p ) ) );
	}

	// ── Scale Tween ────────────────────────────────────────────────────────

	public static BaseTween TweenScale( this TextRenderer text, float target, float duration )
	{
		if ( !text.IsValid() ) return null;

		float start = text.Scale;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = text.Scale )
			.OnUpdate( p => text.Scale = MathX.Lerp( start, target, p ) ) );
	}

	// ── Typewriter ─────────────────────────────────────────────────────────

	public static BaseTween Typewriter( this TextRenderer text, string fullText, float duration )
	{
		if ( !text.IsValid() ) return null;

		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => text.Text = string.Empty )
			.OnUpdate( p =>
			{
				int charCount = (int)MathX.Lerp( 0, fullText.Length, p );
				text.Text = fullText[..charCount];
			} ) );
	}

	public static BaseTween TypewriterWithCursor( this TextRenderer text, string fullText, float duration, string cursor = "|" )
	{
		if ( !text.IsValid() ) return null;

		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => text.Text = cursor )
			.OnUpdate( p =>
			{
				int charCount = (int)MathX.Lerp( 0, fullText.Length, p );
				text.Text = fullText[..charCount] + cursor;
			} )
			.OnComplete( () => text.Text = fullText ) );
	}

	// TEXT SCOPES
	public static BaseTween TweenLineHeight( this TextRenderer text, float target, float duration )
	{
		if ( !text.IsValid() ) return null;

		float start = text.TextScope.LineHeight;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = text.TextScope.LineHeight )
			.OnUpdate( p =>
			{
				var scope = text.TextScope;
				scope.LineHeight = MathX.Lerp( start, target, p );
				text.TextScope = scope;
			} ) );
	}

	public static BaseTween TweenLetterSpacing( this TextRenderer text, float target, float duration )
	{
		if ( !text.IsValid() ) return null;

		float start = text.TextScope.LetterSpacing;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = text.TextScope.LetterSpacing )
			.OnUpdate( p =>
			{
				var scope = text.TextScope;
				scope.LetterSpacing = MathX.Lerp( start, target, p );
				text.TextScope = scope;
			} ) );
	}

	public static BaseTween TweenWordSpacing( this TextRenderer text, float target, float duration )
	{
		if ( !text.IsValid() ) return null;

		float start = text.TextScope.WordSpacing;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = text.TextScope.WordSpacing )
			.OnUpdate( p =>
			{
				var scope = text.TextScope;
				scope.WordSpacing = MathX.Lerp( start, target, p );
				text.TextScope = scope;
			} ) );
	}

	public static BaseTween TweenOutlineColor( this TextRenderer text, Color target, float duration )
	{
		if ( !text.IsValid() ) return null;

		Color start = text.TextScope.Outline.Color;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = text.TextScope.Outline.Color )
			.OnUpdate( p =>
			{
				var scope = text.TextScope;
				scope.Outline.Color = Color.Lerp( start, target, p );
				text.TextScope = scope;
			} ) );
	}

	public static BaseTween TweenShadowColor( this TextRenderer text, Color target, float duration )
	{
		if ( !text.IsValid() ) return null;

		Color start = text.TextScope.Shadow.Color;
		return TweenManager.Instance.AddTween( new BaseTween( duration )
			.OnStart( () => start = text.TextScope.Shadow.Color )
			.OnUpdate( p =>
			{
				var scope = text.TextScope;
				scope.Shadow.Color = Color.Lerp( start, target, p );
				text.TextScope = scope;
			} ) );
	}
}
