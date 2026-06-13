using Sandbox;
using SbTween;

namespace SbTween.Examples;

public sealed class SbeDooTest : Component
{
	[Property] public Doo DooTweening;

	protected override void OnStart()
	{
		RunDoo( DooTweening );
	}
}
