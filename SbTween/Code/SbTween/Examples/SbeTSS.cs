using Sandbox;
using SbTween;

namespace SbTween.Examples;

public sealed class SbeTSS : Component
{
	protected override void OnStart()
	{
		this.TweenShakeScale( 0.6f, 0.3f ).SetLoops( -1, true );
	}
}
