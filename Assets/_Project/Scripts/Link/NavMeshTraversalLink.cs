using UnityEngine;

public class NavMeshTraversalLink : MonoBehaviour
{
    [SerializeField] private NavMeshLinkTraversalType _traversalType;

    public NavMeshLinkTraversalType TraversalType => _traversalType;

    public Vector3 FacingDirection => -transform.right;
}