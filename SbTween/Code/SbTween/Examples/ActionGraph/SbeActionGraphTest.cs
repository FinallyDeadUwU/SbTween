using System;
using Sandbox;
using SbTween;

namespace SbTween.Examples;


public sealed class SbeActionGraphTest : Component
{
	[Property] public Action actionTest;

	protected override void OnStart()
	{
		actionTest.Invoke();
	}

	public void RestartAction()
	{
		actionTest.Invoke();
	}
}
