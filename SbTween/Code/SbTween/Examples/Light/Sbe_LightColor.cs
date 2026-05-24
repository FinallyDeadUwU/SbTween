using Sandbox;

namespace SbTween.Examples;

public sealed class Sbe_LightColor : Component
{

	[Property] public PointLight PL;
	[Property] public Color newColor;


	protected override void OnStart()
	{
		PL.TweenLightColor( newColor, 1 ).SetLoops( -1, LoopType.YoYo ).Play();
	}

}
