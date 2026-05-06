using Sandbox;
using SbTween;

namespace SbTween.Examples;

public sealed class SbeTLS : Component
{
	protected override void OnStart()
	{
		this.TweenShakeLocation( 0.6f, 10 ).SetLoops( -1, LoopType.YoYo );
	}
}
