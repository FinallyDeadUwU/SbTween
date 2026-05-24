using Sandbox;

namespace SbTween.Examples;

public sealed class Sbe_FlickerTest : Component
{

	[Property] public PointLight PL;
	[Property] public float MinBrightness;
	[Property] public float MaxBrightness;



	protected override void OnStart()
	{
		PL.TweenFlickerLight( MinBrightness, MaxBrightness, 1, 10 ).SetLoops(-1).Play();
	}

}
