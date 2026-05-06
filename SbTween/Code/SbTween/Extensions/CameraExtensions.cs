using Sandbox;

namespace SbTween;

public static class CameraExtensions
{
	public static BaseTween TweenFieldOfView( this CameraComponent self, float to, float duration )
	{
		float from = self.FieldOfView;
		var tween = new BaseTween( duration );
		tween.Target = self.GameObject;

		return TweenManager.Instance.AddTween( tween
			.OnUpdate( p =>
			{
				if ( !self.IsValid() ) return;
				self.FieldOfView = from.LerpTo( to, p );
			} )
		);
	}
	
	public static BaseTween TweenZNear( this CameraComponent self, float to, float duration )
	{
		float from = self.ZNear;
		var tween = new BaseTween( duration );
		tween.Target = self.GameObject;

		return TweenManager.Instance.AddTween( tween
			.OnUpdate( p =>
			{
				if ( !self.IsValid() ) return;
				self.ZNear = from.LerpTo( to, p );
			} )
		);
	}

	public static BaseTween TweenZFar( this CameraComponent self, float to, float duration )
	{
		float from = self.ZFar;
		var tween = new BaseTween( duration );
		tween.Target = self.GameObject;

		return TweenManager.Instance.AddTween( tween
			.OnUpdate( p =>
			{
				if ( !self.IsValid() ) return;
				self.ZFar = from.LerpTo( to, p );
			} )
		);
	}

	public static BaseTween TweenBackgroundColor( this CameraComponent self, Color to, float duration )
	{
		Color from = self.BackgroundColor;
		var tween = new BaseTween( duration );
		tween.Target = self.GameObject;

		return TweenManager.Instance.AddTween( tween
			.OnUpdate( p =>
			{
				if ( !self.IsValid() ) return;
				self.BackgroundColor = Color.Lerp( from, to, p );
			} )
		);
	}

	public static BaseTween TweenOrthoHeight( this CameraComponent self, float to, float duration )
	{
		float from = self.OrthographicHeight;
		var tween = new BaseTween( duration );
		tween.Target = self.GameObject;

		return TweenManager.Instance.AddTween( tween
			.OnUpdate( p =>
			{
				if ( !self.IsValid() ) return;
				self.OrthographicHeight = from.LerpTo( to, p );
			} )
		);
	}
}
