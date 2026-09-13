using UnityEngine;

public abstract class DirectionalRotator
{
    private readonly float _rotationSpeed;

    private Vector3 _currentDirection;

    public abstract Quaternion CurrentRotation { get; }

    public DirectionalRotator(float rotationSpeed)
    {
        _rotationSpeed = rotationSpeed;
    }

    public void SetInputDirection(Vector3 direction)
    {
        _currentDirection = direction;
    }

    public void Update(float deltaTime)
    {
        if (_currentDirection.magnitude < 0.05f)
            return;

        Quaternion lookRotation = Quaternion.LookRotation(_currentDirection.normalized);

        float step = _rotationSpeed * deltaTime;

        Quaternion rotation = Quaternion.RotateTowards(CurrentRotation, lookRotation, step);

        ApplyRotation(rotation);
    }

    protected abstract void ApplyRotation(Quaternion rotation);
}