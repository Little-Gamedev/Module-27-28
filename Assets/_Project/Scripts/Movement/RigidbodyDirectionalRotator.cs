using UnityEngine;

public class RigidbodyDirectionalRotator : DirectionalRotator
{
    private readonly Rigidbody _rigidbody;

    public override Quaternion CurrentRotation => _rigidbody.rotation;

    public RigidbodyDirectionalRotator(Rigidbody rigidbody, float rotationSpeed) : base(rotationSpeed)
    {
        _rigidbody = rigidbody;
    }

    protected override void ApplyRotation(Quaternion rotation)
    {
        _rigidbody.MoveRotation(rotation);
    }
}