using Sandbox;
using System;

namespace SbTween;

public static class AudioExtensions
{
	public static BaseTween TweenVolume( this SoundPointComponent sound, float targetVolume, float duration )
	{
		float startVolume = sound.Volume;
		var tween = new BaseTween( duration );
		tween.Target = sound.GameObject;

		return TweenManager.Instance.AddTween( tween
			.OnStart( () => startVolume = sound.Volume )
			.OnUpdate( p =>
			{
				if ( !sound.IsValid() ) return;
				sound.Volume = MathX.Lerp( startVolume, targetVolume, p );
			} )
		);
	}
	
	public static BaseTween TweenPitch( this SoundPointComponent sound, float targetPitch, float duration )
	{
		float startPitch = sound.Pitch;
		var tween = new BaseTween( duration );
		tween.Target = sound.GameObject;

		return TweenManager.Instance.AddTween( tween
			.OnStart( () => startPitch = sound.Pitch )
			.OnUpdate( p =>
			{
				if ( !sound.IsValid() ) return;
				sound.Pitch = MathX.Lerp( startPitch, targetPitch, p );
			} )
		);
	}
}
