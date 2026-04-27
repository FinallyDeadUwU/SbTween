using Sandbox;
using System.Collections.Generic;
using System.Linq;

namespace SbTween;

public sealed class TweenManager : Component
{
	private static TweenManager _instance;
	public static TweenManager Instance
	{
		get
		{
			if ( _instance.IsValid() ) return _instance;
			_instance = Game.ActiveScene.GetAllComponents<TweenManager>().FirstOrDefault();
			if ( _instance.IsValid() ) return _instance;

			var go = new GameObject( true, "SbTween_Manager" );
			_instance = go.Components.Create<TweenManager>();
			go.Flags = GameObjectFlags.NotSaved | GameObjectFlags.Hidden;
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

	public void AddSequence( TweenSequence seq )
	{
		if ( !_activeSequences.Contains( seq ) )
			_activeSequences.Add( seq );
	}

	protected override void OnUpdate()
	{
		if ( _activeTweens.Count == 0 ) return;

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
				tween.Update( RealTime.Delta );
			}
		}

		for ( int i = _activeSequences.Count - 1; i >= 0; i-- )
		{
			var seq = _activeSequences[i];
			if ( seq == null || seq.IsFinished )
			{
				_activeSequences.RemoveAt( i );
				continue;
			}
			seq.Update();
		}
	}
}
