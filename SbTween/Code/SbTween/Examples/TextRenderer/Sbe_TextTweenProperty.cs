using Sandbox;

namespace SbTween.Examples;

public sealed class Sbe_TextTweenProperty : Component
{
	[Property] public TextRenderer TR;
	[Property] public Color GlowText;

	protected override void OnStart()
	{
		TR.TweenFontSize( 52f, 2 ).SetLoops( -1, LoopType.YoYo ).Play();
		TR.TweenOutlineColor(GlowText, 0.8f).SetLoops(-1, LoopType.YoYo ).Play();
		TR.TweenFontWeight(600, 0.4f).SetLoops(-1, LoopType.YoYo ).Play();
	}


}
