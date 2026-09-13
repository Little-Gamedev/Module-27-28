using UnityEngine;
using UnityEngine.AI;

public interface INavMeshMovable : ITransformPosition
{
    Vector3 CurrentVelocity { get; }

    void SetDestination(Vector3 position);

    void StopMove();

    void ResumeMove();

    void ResetPath();

    bool TryGetPath(Vector3 targetPosition, NavMeshPath pathToTarget);
}