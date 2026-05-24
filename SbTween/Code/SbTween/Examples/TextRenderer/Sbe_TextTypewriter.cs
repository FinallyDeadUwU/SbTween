using Sandbox;

namespace SbTween.Examples;

public sealed class Sbe_TextTypewriter : Component
{
	[Property] public TextRenderer TR;
	[Property] public string Say;
	[Property] public bool useCursor;


	protected override void OnStart()
	{
		if ( useCursor )
		{

			TR.TypewriterWithCursor( Say, 3, "|" ).SetLoops( -1, LoopType.YoYo ).Play();
		}
		else
		{
			TR.Typewriter( Say, 1 ).SetLoops( -1, LoopType.YoYo ).Play();
		}
	}


}
