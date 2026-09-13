using UnityEngine;

public class KeyboardDirectionalMoveController : Controller
{
    private readonly IDirectionalMovable _movable;
    private readonly CameraRelativeDirection _cameraRelativeDirection;

    public KeyboardDirectionalMoveController(IDirectionalMovable movable, CameraRelativeDirection cameraRelativeDirection)
    {
        _movable = movable;
        _cameraRelativeDirection = cameraRelativeDirection;
    }

    protected override void UpdateLogic(float deltaTime)
    {
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        Vector3 moveDirection = _cameraRelativeDirection.GetDirection(inputDirection);

        _movable.SetMoveDirection(moveDirection);
    }

    public override void Disable()
    {
        base.Disable();

        _movable.SetMoveDirection(Vector3.zero);
    }
}