using UnityEngine;

public interface IMovementTarget
{
    Vector3 TargetPoint { get; }
    bool HasTarget { get; }

    void SetTargetPoint(Vector3 targetPoint);
    void ClearTarget();
}