using Sandbox;
using SbTween;


namespace SbTween.Examples;

public sealed class SbeFloatTest : Component
{
	[Property] public HighlightOutline HO;

	protected override void OnStart()
	{
		this.GameObject.TweenFloat( 0.18f, 0.46f, 0.5f, ( val ) => HO.Width = val ).SetEase(EaseType.Linear).SetLoops(-1, true);
	}
}
