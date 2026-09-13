using UnityEngine;
using UnityEngine.AI;

public class ClickToMoveCharacterController : Controller
{
    private readonly INavMeshMovable _movable;
    private readonly IMovementTarget _movementTarget;
    private readonly INavMeshLinkTraversable _linkTraversable;
    private readonly IDirectionalRotatable _rotatable;

    private readonly CameraRaycaster _cameraRaycaster;

    private readonly float _navMeshSearchDistance;
    private readonly float _stopDistance;


    private readonly NavMeshPath _pathToTarget = new NavMeshPath();

    public ClickToMoveCharacterController(
     INavMeshMovable movable,
     IMovementTarget movementTarget,
     INavMeshLinkTraversable linkTraversable,
     IDirectionalRotatable rotatable,
     CameraRaycaster cameraRaycaster,
     float navMeshSearchDistance,
     float stopDistance)
    {
        _movable = movable;
        _movementTarget = movementTarget;

        _linkTraversable = linkTraversable;
        _rotatable = rotatable;

        _cameraRaycaster = cameraRaycaster;

        _navMeshSearchDistance = navMeshSearchDistance;

        _stopDistance = stopDistance;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        if (TryTraverseLink())
            return;

        TrySetNewTarget();

        UpdateMovement();
    }

    private void TrySetNewTarget()
    {
        if (Input.GetMouseButtonDown(0) == false)
            return;

        if (_cameraRaycaster.TryGetHitPoint(Input.mousePosition, out Vector3 hitPoint) == false)
            return;

        if (NavMesh.SamplePosition(hitPoint, out NavMeshHit navMeshHit, _navMeshSearchDistance, NavMesh.AllAreas) == false)
            return;

        Vector3 targetPoint = navMeshHit.position;

        if (_movable.TryGetPath(targetPoint, _pathToTarget) == false)
            return;

        if (_pathToTarget.status != NavMeshPathStatus.PathComplete)
            return;

        _movable.ResetPath();

        _movable.ResumeMove();
        _movable.SetDestination(targetPoint);

        _movementTarget.SetTargetPoint(targetPoint);
    }

    private void UpdateMovement()
    {
        if (_movementTarget.HasTarget == false)
            return;

        if (_movable.TryGetPath(_movementTarget.TargetPoint, _pathToTarget) == false)
        {
            StopMovement();
            return;
        }

        if (_pathToTarget.status != NavMeshPathStatus.PathComplete)
        {
            StopMovement();
            return;
        }

        float distanceToTarget = NavMeshUtils.GetPathLength(_pathToTarget);

        if (distanceToTarget > _stopDistance)
            return;

        StopMovement();
    }

    private void StopMovement()
    {
        _movable.StopMove();

        _movementTarget.ClearTarget();
    }

    public override void Disable()
    {
        base.Disable();

        StopMovement();
    }

    private bool TryTraverseLink()
    {
        if (_linkTraversable.TryGetCurrentLink(out OffMeshLinkData linkData) == false)
            return false;

        if (_linkTraversable.IsLinkTraversalInProcess == false)
        {
            Vector3 direction = linkData.endPos - linkData.startPos;

            direction.y = 0f;

            _rotatable.SetRotationDirection(direction);

            _linkTraversable.TraverseLink(linkData);
        }

        return true;
    }
}