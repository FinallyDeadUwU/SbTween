using Sandbox;
using SbTween;

namespace SbTween.Examples;

public sealed class SbeScreenTween : Component
{
	[Property] public ScreenPanel SP;

	protected override void OnStart()
	{
		SP.TweenOpacity(0,1).SetLoops( -1, LoopType.YoYo ).Play();
		SP.TweenSize(1.4f, 1).SetLoops( -1, LoopType.YoYo ).Play();
	}
}
