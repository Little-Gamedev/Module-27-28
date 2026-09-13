using UnityEngine;

public class CameraRaycaster
{
    private readonly Camera _camera;
    private readonly LayerMask _clickableLayers;

    public CameraRaycaster(Camera camera, LayerMask clickableLayers)
    {
        _camera = camera;
        _clickableLayers = clickableLayers;
    }

    public bool TryGetHitPoint(Vector3 screenPosition, out Vector3 hitPoint)
    {
        hitPoint = Vector3.zero;

        if (_camera == null)
            return false;

        Ray ray = _camera.ScreenPointToRay(screenPosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _clickableLayers))
        {
            hitPoint = hit.point;
            return true;
        }

        return false;
    }
}