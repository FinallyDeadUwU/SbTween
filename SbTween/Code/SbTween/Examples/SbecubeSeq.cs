using Sandbox;
using SbTween;

namespace SbTween.Examples;

public sealed class SbecubeSeq : Component
{
	[Property] public ModelRenderer MR;

	protected override void OnStart()
	{
		var exampleSeq = new TweenSequence()
			.Append( this.TweenMove( new Vector3( -257.631989f, -510.453766f, 181.270782f ), 1 ) )
			.Append( MR.TweenTint( new Color32( 0, 255, 0, 255 ), 0.5f ) )
			.Append( this.TweenMove( new Vector3( -257.631989f, -510.453766f, 37.8219452f ), 0.87f ) )
			.Append( this.TweenScale( new Vector3( 0.617f, 0.617f, 0.116f ), 0.5f ) )
			.Append( this.TweenScale( new Vector3( 0.617f, 0.617f, 0.617f ), 1 ) )
			.Append( MR.TweenTint( new Color32( 0, 255, 255, 255 ), 1 ) ).SetLoops(-1).SetDelay(3);

		exampleSeq.Play();
		
	}
}
