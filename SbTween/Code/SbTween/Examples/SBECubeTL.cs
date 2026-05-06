using Sandbox;
using SbTween;

namespace SbTween.Examples;

public sealed class SBECubeTL : Component
{
	[Property] public Vector3 vectorUP;

	protected override void OnStart()
	{
		this.TweenMove( vectorUP, 3 ).SetEase( EaseType.Linear ).SetLoops(-1, LoopType.YoYo ).Play();
	}
	
}
