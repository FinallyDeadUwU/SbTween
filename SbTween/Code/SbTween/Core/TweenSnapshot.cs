using Sandbox;

public class TweenSnapshot
{
	public Vector3 LocalPosition;
	public Rotation LocalRotation;
	public Vector3 LocalScale;
	public Color Tint;
	private ModelRenderer _renderer;
	private GameObject _target;

	public void Capture( GameObject obj )
	{
		_target = obj;
		LocalPosition = obj.LocalPosition;
		LocalRotation = obj.LocalRotation;
		LocalScale = obj.LocalScale;
		_renderer = obj.Components.Get<ModelRenderer>();
		if ( _renderer.IsValid() ) Tint = _renderer.Tint;
	}

	public void Restore()
	{
		if ( !_target.IsValid() ) return;
		_target.LocalPosition = LocalPosition;
		_target.LocalRotation = LocalRotation;
		_target.LocalScale = LocalScale;
		if ( _renderer.IsValid() ) _renderer.Tint = Tint;
	}
}
