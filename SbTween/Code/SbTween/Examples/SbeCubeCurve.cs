using Sandbox;

namespace SbTween.Examples;

public sealed class SbeCubeCurve : Component
{
	[Property] public Vector3 targetPosition;
	[Property] public Curve TweenCurve;

	protected override void OnStart()
	{
		this.TweenMove( targetPosition, 5 ).WithCurve( TweenCurve ).SetLoops(-1).Play();
	}
}
