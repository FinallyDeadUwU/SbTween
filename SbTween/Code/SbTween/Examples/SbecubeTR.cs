using Sandbox;
using SbTween;


namespace SbTween.Examples;

public sealed class SbecubeTR : Component
{
	[Property] public EaseType easingType;

	protected override void OnStart()
	{
		this.TweenRotate(Rotation.From(0,180,0), 1).SetEase( easingType ).SetLoops(-1).Play();
	}
}
