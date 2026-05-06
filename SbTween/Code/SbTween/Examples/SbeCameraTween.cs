using Sandbox;
using SbTween;

public sealed class SbeCameraTween : Component
{
	[Property] public bool FOV;
	[Property] public bool ZNear;
	[Property] public bool ZFar;
	[Property] public bool BG_color;
	[Property] public bool Orthographic;

	[Property] public Color color;
	[Property] public CameraComponent Camera;
	[Property] public ModelRenderer myPreview;

	protected override void OnStart()
	{
		if ( FOV )
		{
			Camera.TweenFieldOfView( 40, 4 ).SetLoops( -1, LoopType.YoYo ).Play();
		}
		if ( ZNear )
		{
			Camera.TweenZNear( 40, 4 ).SetLoops( -1, LoopType.YoYo ).Play();
		}
		if ( ZFar )
		{
			Camera.TweenZFar( 40, 4 ).SetLoops( -1, LoopType.YoYo ).Play();
		}
		if ( BG_color )
		{
			Camera.TweenBackgroundColor( color, 1 ).SetLoops( -1, LoopType.YoYo ).Play();
		}
		if ( Orthographic )
		{
			Camera.TweenOrthoHeight( 720, 1 ).SetLoops( -1, LoopType.YoYo ).Play();
		}
	}
}
