using Sandbox;
using SbTween;

namespace SbTween.Examples;

public sealed class SbeNetworkTest : Component
{
	[Property] public Vector3 location;


	[Rpc.Broadcast]
	protected override void OnStart()
	{
		if ( !IsProxy )
		{
			this.TweenMove( location, 1 ).SetEase( EaseType.Linear ).SetLoops( -1, true ).Play();
		}
	}
}
