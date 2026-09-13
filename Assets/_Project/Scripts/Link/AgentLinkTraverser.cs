using UnityEngine;
using UnityEngine.AI;

public class AgentLinkTraverser
{
    private readonly AgentJumper _jumper;
    private readonly AgentClimber _climber;

    private readonly DirectionalRotator _rotator;

    public AgentLinkTraverser(AgentJumper jumper, AgentClimber climber, DirectionalRotator rotator)
    {
        _jumper = jumper;
        _climber = climber;
        _rotator = rotator;
    }

    public bool InProcess => _jumper.InProcess || _climber.InProcess;

    public NavMeshLinkTraversalType CurrentTraversalType
    {
        get
        {
            if (_jumper.InProcess)
                return NavMeshLinkTraversalType.Jump;

            if (_climber.InProcess)
                return NavMeshLinkTraversalType.Climb;

            return NavMeshLinkTraversalType.None;
        }
    }

    public void Traverse(OffMeshLinkData linkData)
    {
        if (InProcess)
            return;

        Component linkOwner = linkData.owner as Component;

        if (linkOwner == null)
        {
            Debug.LogError("У NavMeshLink не найден owner.");

            return;
        }

        if (linkOwner.TryGetComponent(out NavMeshTraversalLink traversalLink) == false)
        {
            Debug.LogError("На NavMeshLink отсутствует NavMeshTraversalLink.");

            return;
        }

        switch (traversalLink.TraversalType)
        {
            case NavMeshLinkTraversalType.Jump:
                TraverseJump(linkData);
                break;

            case NavMeshLinkTraversalType.Climb:
                TraverseClimb(linkData, traversalLink);
                break;
        }
    }

    private void TraverseJump(OffMeshLinkData linkData)
    {
        Vector3 direction = linkData.endPos - linkData.startPos;

        direction.y = 0f;

        _rotator.SetInputDirection(direction);

        _jumper.Jump(linkData);
    }

    private void TraverseClimb(OffMeshLinkData linkData, NavMeshTraversalLink traversalLink)
    {
        Vector3 facingDirection = traversalLink.FacingDirection;

        facingDirection.y = 0f;

        _rotator.SetInputDirection(facingDirection);

        _climber.Climb(linkData);
    }
}