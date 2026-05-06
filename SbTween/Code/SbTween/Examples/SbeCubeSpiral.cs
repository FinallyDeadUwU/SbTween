using Sandbox;

namespace SbTween.Examples;

public sealed class SbeCubeSpiral : Component
{
	[Property] public Vector3 axis;
	[Property] public float speed;
	[Property] public float frequency;

	protected override void OnStart()
	{
		GameObject.TweenSpiral( 4, axis, speed, frequency ).SetLoops(-1, LoopType.YoYo ).Play();
	}
}
