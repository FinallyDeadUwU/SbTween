using Sandbox;
using SbTween;

namespace SbTween.Examples;

public sealed class SbecubeTS : Component
{
	protected override void OnStart()
	{
		this.TweenScale( new Vector3( 0.5f, 1f, 0.5f ),0.5f ).SetLoops(-1,true).SetEase(EaseType.InBounce).Play();
	}
}
