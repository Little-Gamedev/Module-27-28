using UnityEngine;

public class RigidbodyDirectionalMover : DirectionalMover
{
    private readonly Rigidbody _rigidbody;

    public RigidbodyDirectionalMover(Rigidbody rigidbody, float movementSpeed) : base(movementSpeed)
    {
        _rigidbody = rigidbody;
    }

    public override void Update(float deltaTime)
    {
        Vector3 velocity = CurrentVelocity;

        velocity.y = _rigidbody.linearVelocity.y;

        _rigidbody.linearVelocity = velocity;
    }
}