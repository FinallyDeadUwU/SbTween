using Sandbox;
using SbTween;

namespace SbTween.Examples;

public sealed class SbeTRS : Component
{
	protected override void OnStart()
	{
		this.TweenShakeRotation( 0.6f, 5 ).SetLoops( -1, LoopType.YoYo );
	}
}
