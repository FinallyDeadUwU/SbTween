using Sandbox;
using System.Collections.Generic;
using System.Linq;

namespace SbTween;

public sealed class TweenManager : Component, Component.ExecuteInEditor
{
	private static TweenManager _instance;
	public static TweenManager Instance
	{
		get
		{
			if ( IsInstanceValid() == false )
			{
				var activeScene = Game.ActiveScene;
				if ( activeScene == null ) return null;

				var found = activeScene.GetAllComponents<TweenManager>().FirstOrDefault();
				if ( found.IsValid() ) return found;

				var go = activeScene.CreateObject();
				go.Name = "SbTween_Manager";
				go.Flags = GameObjectFlags.NotSaved | GameObjectFlags.Hidden;
				_instance = go.Components.Create<TweenManager>();
			}

			return _instance;
		}
	}

	private readonly List<BaseTween> _activeTweens = new();
	private readonly List<TweenSequence> _activeSequences = new();

	public T AddTween<T>( T tween ) where T : BaseTween
	{
		if ( tween == null ) return null;
		_activeTweens.Add( tween );
		return tween;
	}
	public void RemoveTween( BaseTween tween )
	{
		if ( tween == null ) return;
		if ( _activeTweens.Contains( tween ) )
		{
			_activeTweens.Remove( tween );
		}
	}

	public void AddSequence( TweenSequence seq )
	{
		if ( !_activeSequences.Contains( seq ) )
			_activeSequences.Add( seq );
	}

	protected override void OnUpdate()
	{
		if ( _activeTweens.Count == 0 && _activeSequences.Count == 0 ) return;

		float dt = RealTime.Delta;
		bool isAnyTweenMoving = false;

		// --- Tweens ---
		for ( int i = _activeTweens.Count - 1; i >= 0; i-- )
		{
			var tween = _activeTweens[i];
			if ( tween == null || tween.IsFinished )
			{
				_activeTweens.RemoveAt( i );
				continue;
			}

			if ( !tween.IsPaused )
			{
				tween.Update( dt );
				isAnyTweenMoving = true;
			}
		}

		// --- Sequences ---
		for ( int i = _activeSequences.Count - 1; i >= 0; i-- )
		{
			var seq = _activeSequences[i];
			if ( seq == null || seq.IsFinished )
			{
				_activeSequences.RemoveAt( i );
				continue;
			}
			seq.Update();
			isAnyTweenMoving = true;
		}

		if ( isAnyTweenMoving && !Game.IsPlaying )
		{
			foreach ( var tween in _activeTweens )
			{
				if ( tween.Target.IsValid() )
				{
					tween.Target.Transform.Local = tween.Target.Transform.Local;
					break;
				}
			}
		}
	}

	//THANKS ENZO (damien9709) for fixing this!
	public static bool IsInstanceValid()
	{
		return _instance != null;
	}
}
