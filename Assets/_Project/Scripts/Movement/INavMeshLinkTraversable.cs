using UnityEngine.AI;

public interface INavMeshLinkTraversable
{
    bool IsLinkTraversalInProcess { get; }

    bool TryGetCurrentLink(out OffMeshLinkData linkData);

    void TraverseLink(OffMeshLinkData linkData);
}