using Sandbox;

namespace SbTween.Examples;

public sealed class SbeCubeInCircle : Component
{

	[Property] public float range = 20;
	[Property] public float speed = 5; // speed is basically percent of the circle. if you do 0.3 the circle won't be full. if you do 1 the circle will full rotate 360.
	[Property] public bool snapping = false;
	[Property] public float delay;
	[Property] public Vector3 axis; //X left/right, Y Up/Down, Z left/right (but if you combine it with X or Y, it will rotate at side

	protected override void OnStart()
	{
		GameObject.TweenInCircle( 1, axis, range, speed, snapping ).SetLoops(-1,LoopType.Restart).SetDelay( delay ).Play();
	}
	
}
