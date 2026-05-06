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
			var activeScene = Game.ActiveScene;
			if ( activeScene == null ) return null;

			var found = activeScene.GetAllComponents<TweenManager>().FirstOrDefault();
			if ( found.IsValid() ) return found;

			var go = activeScene.CreateObject();
			go.Name = "SbTween_Manager";
			go.Flags = GameObjectFlags.NotSaved | GameObjectFlags.Hidden;
			_instance = go.Components.Create<TweenManager>();

			return _instance;
		}
	}

	private readonly List<BaseTween> _activeTweens = new();
	private readonly List<TweenSequence> _activeSequences = new();

	public T AddTween<T>( T tween ) where T : BaseTween
	{
		if ( tween == null ) return null;

		if ( !string.IsNullOrEmpty( tween.Id ) )
		{
			var existing = _activeTweens
						.Where( t => t.Id == tween.Id && t != tween )
						.ToList();

			foreach ( var t in existing )
			{
				t.Stop();
				Log.Warning( "[SbTween] - Tween (" + t.Target + ") won't be played because id: " + t.Id + ", already exists. Use different id for this tween." );
			}
		}

		if ( !_activeTweens.Contains( tween ) ) //If multiple same tweens are on the object it makes them faster and faster.
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

	// TIMELINE
	public void Pause( string id )
	{
		if ( string.IsNullOrEmpty( id ) ) return;
		var targets = _activeTweens.Where( t => t.Id == id ).ToList();
		foreach ( var t in targets ) t.Pause();
	}

	public void Pause( GameObject target )
	{
		if ( target == null ) return;
		var targets = _activeTweens.Where( t => t.Target == target ).ToList();
		foreach ( var t in targets ) t.Pause();
	}

	public void Play( string id )
	{
		if ( string.IsNullOrEmpty( id ) ) return;
		var targets = _activeTweens.Where( t => t.Id == id ).ToList();
		foreach ( var t in targets ) t.Play();
	}

	public void Play( GameObject target )
	{
		if ( target == null ) return;
		var targets = _activeTweens.Where( t => t.Target == target ).ToList();
		foreach ( var t in targets ) t.Play();
	}

	public void Stop( string id )
	{
		if ( string.IsNullOrEmpty( id ) ) return;
		var targets = _activeTweens.Where( t => t.Id == id ).ToList();
		foreach ( var t in targets ) t.Stop();
	}

	public void Stop( GameObject target )
	{
		if ( target == null ) return;
		var targets = _activeTweens.Where( t => t.Target == target ).ToList();
		foreach ( var t in targets ) t.Stop();
	}

	public void KillTweenOnObject( GameObject target, string id )
	{
		if ( !target.IsValid() || string.IsNullOrEmpty( id ) ) return;

		var toKill = _activeTweens
			.Where( t => t.Target == target && t.Id == id )
			.ToList();

		foreach ( var tween in toKill )
		{
			tween.Kill();
			_activeTweens.Remove( tween );
		}
	}

	public void KillAllTweensOnObject( GameObject target )
	{
		if ( !target.IsValid() ) return;

		var toKill = _activeTweens
			.Where( t => t.Target == target )
			.ToList();

		foreach ( var tween in toKill )
		{
			tween.Kill();
			_activeTweens.Remove( tween );
		}
	}

	//THANKS ENZO (damien9709) for fixing this!
	public static bool IsInstanceValid()
	{
		return _instance != null;
	}
}
