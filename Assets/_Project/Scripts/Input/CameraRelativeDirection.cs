using UnityEngine;

public class CameraRelativeDirection
{
    private readonly Transform _cameraTransform;

    public CameraRelativeDirection(Transform cameraTransform)
    {
        _cameraTransform = cameraTransform;
    }

    public Vector3 GetDirection(Vector3 inputDirection)
    {
        Vector3 forward = _cameraTransform.forward;
        Vector3 right = _cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        return forward * inputDirection.z + right * inputDirection.x;
    }
}