using UnityEngine;

public class KeyboardDirectionalRotationController : Controller
{
    private readonly IDirectionalRotatable _rotatable;
    private readonly CameraRelativeDirection _cameraRelativeDirection;

    public KeyboardDirectionalRotationController(  IDirectionalRotatable rotatable, CameraRelativeDirection cameraRelativeDirection)
    {
        _rotatable = rotatable;
        _cameraRelativeDirection = cameraRelativeDirection;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        Vector3 inputDirection = new Vector3(   Input.GetAxisRaw("Horizontal"),  0f,  Input.GetAxisRaw("Vertical"));

        Vector3 rotationDirection = _cameraRelativeDirection.GetDirection(inputDirection);

        _rotatable.SetRotationDirection(rotationDirection);
    }

    public override void Disable()
    {
        base.Disable();

        _rotatable.SetRotationDirection(Vector3.zero);
    }
}