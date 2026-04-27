using Sandbox;
using System;
using System.Collections.Generic;

namespace SbTween;

public class TweenSequence
{
	private List<BaseTween> _queue = new();
	private List<TweenSnapshot> _snapshots = new();
	private bool _hasCaptured = false;
	private int _currentIndex = 0;

	public float Delay { get; private set; } = 0;
	private float _delayElapsed = 0;

	public int Loops { get; private set; } = 0;
	private int _loopsDone = 0;

	public bool IsFinished { get; private set; }
	public bool IsPaused { get; private set; } = true;

	public TweenSequence Append( BaseTween tween )
	{
		tween.Pause();
		_queue.Add( tween );
		return this;
	}

	public TweenSequence SetDelay( float seconds ) { Delay = seconds; return this; }
	public TweenSequence SetLoops( int loops ) { Loops = loops; return this; }

	public void Play()
	{
		if ( !_hasCaptured )
		{
			foreach ( var t in _queue )
			{
				if ( t.Target.IsValid() )
				{
					var snp = new TweenSnapshot();
					snp.Capture( t.Target );
					_snapshots.Add( snp );
				}
			}
			_hasCaptured = true;
		}

		IsPaused = false;
		IsFinished = false;
		_currentIndex = 0;
		_loopsDone = 0;
		_delayElapsed = 0;

		TweenManager.Instance.AddSequence( this );
	}

	public void Update()
	{
		if ( IsFinished || IsPaused || _queue.Count == 0 ) return;

		if ( _delayElapsed < Delay )
		{
			_delayElapsed += RealTime.Delta;
			return;
		}

		float dt = RealTime.Delta;

		while ( dt > 0 && _currentIndex < _queue.Count )
		{
			var current = _queue[_currentIndex];
			if ( current.IsPaused ) current.Play();

			float timeNeeded = current.Duration - current.Elapsed;
			float timeToApply = Math.Min( dt, timeNeeded );

			current.Update( timeToApply );
			dt -= timeToApply;

			if ( current.IsFinished )
			{
				_currentIndex++;

				if ( _currentIndex >= _queue.Count )
				{
					if ( Loops == -1 || _loopsDone < Loops )
					{
						_loopsDone++;
						ResetSequence();
						break;
					}
					else
					{
						IsFinished = true;
						break;
					}
				}
			}
		}
	}

	private void ResetSequence()
	{
		_currentIndex = 0;
		_delayElapsed = 0;

		foreach ( var snp in _snapshots )
		{
			snp.Restore();
		}

		foreach ( var t in _queue )
		{
			t.Reset();
		}
	}
}
