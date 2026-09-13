using UnityEngine;

public abstract class DirectionalMover
{
    private readonly float _movementSpeed;

    private Vector3 _currentDirection;

    public Vector3 CurrentVelocity => _currentDirection.normalized * _movementSpeed;

    public DirectionalMover(float movementSpeed)
    {
        _movementSpeed = movementSpeed;
    }

    public void SetInputDirection(Vector3 direction)
    {
        _currentDirection = direction;
    }

    public abstract void Update(float deltaTime);
}