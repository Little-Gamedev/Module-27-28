using UnityEngine;

public class TransformDirectionalRotator : DirectionalRotator
{
    private readonly Transform _transform;

    public override Quaternion CurrentRotation => _transform.rotation;

    public TransformDirectionalRotator(Transform transform, float rotationSpeed) : base(rotationSpeed)
    {
        _transform = transform;
    }

    protected override void ApplyRotation(Quaternion rotation)
    {
        _transform.rotation = rotation;
    }
}