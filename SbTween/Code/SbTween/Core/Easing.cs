using System;

namespace SbTween;

public enum EaseType
{
	Linear,
	InQuad,
	OutQuad,
	InOutQuad,
	InCubic,
	OutCubic,
	InElastic,
	OutElastic,
	InBounce,
	OutBounce
}

public static class Easing
{
	public static float Apply( EaseType type, float t )
	{
		return type switch
		{
			EaseType.Linear => t,
			EaseType.InQuad => t * t,
			EaseType.OutQuad => t * (2 - t),
			EaseType.InOutQuad => t < 0.5f ? 2 * t * t : -1 + (4 - 2 * t) * t,
			EaseType.InCubic => t * t * t,
			EaseType.OutCubic => 1 - MathF.Pow( 1 - t, 3 ),

			// Elastic
			EaseType.InElastic => -MathF.Pow( 2, 10 * t - 10 ) * MathF.Sin( (t * 10 - 10.75f) * ((2 * MathF.PI) / 3) ),
			EaseType.OutElastic => MathF.Pow( 2, -10 * t ) * MathF.Sin( (t * 10 - 0.75f) * ((2 * MathF.PI) / 3) ) + 1,

			// Bounce
			EaseType.InBounce => 1 - Apply( EaseType.OutBounce, 1 - t ),
			EaseType.OutBounce => OutBounce( t ),

			_ => t
		};
	}

	private static float OutBounce( float t ) // shoutout my boy Robert Penner, he smart.
	{
		const float n1 = 7.5625f;
		const float d1 = 2.75f;

		if ( t < 1 / d1 ) return n1 * t * t;
		if ( t < 2 / d1 ) return n1 * (t -= 1.5f / d1) * t + 0.75f;
		if ( t < 2.5f / d1 ) return n1 * (t -= 2.25f / d1) * t + 0.9375f;
		return n1 * (t -= 2.625f / d1) * t + 0.984375f;
	}
}
