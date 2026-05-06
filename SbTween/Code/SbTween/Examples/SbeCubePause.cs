using Sandbox;
using SbTween;

public sealed class SbeCubePause : Component
{
	[Property] public Vector3 location;
	[Property] public Rotation rotation;

	[Property] public string ID;
	[Property] public bool pauseByID;


	bool paused;
	protected override void OnStart()
	{
		this.TweenMove( location, 1 ).SetLoops( -1, LoopType.YoYo ).Play();
		this.TweenRotate(rotation,0.56f).SetLoops( -1, LoopType.YoYo ).SetId( ID ).Play();
	}

	protected override void OnUpdate()
	{
		if ( Input.Pressed( "Use" ) && pauseByID )
		{
			paused = !paused;

			if ( paused )
			{
				this.Pause( ID );
			}
			else
			{
				this.Play( ID );
			}
		}
		else if(Input.Pressed("Voice") && !pauseByID )
		{
			paused = !paused;

			if ( paused )
			{
				this.Pause();
			}
			else
			{
				this.Play();
			}
		}
	}
}
