using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    [SerializeField] private CharacterControlType _controlType;

    [SerializeField] private Character _character;

    [SerializeField] private Camera _camera;

    [SerializeField] private LayerMask _clickableLayers;

    [SerializeField] private float _navMeshSearchDistance = 0.1f;
    [SerializeField] private float _stopDistance = 0.2f;

    private Controller _characterController;

    private void Awake()
    {
        InitializeController();

        _characterController.Enable();
    }

    private void Update()
    {
        _characterController.Update(Time.deltaTime);
    }

    private void InitializeController()
    {
        switch (_controlType)
        {
            case CharacterControlType.Keyboard:
                {
                    _character.InitializeDirectionalMovement();

                    CameraRelativeDirection cameraRelativeDirection = new CameraRelativeDirection(_camera.transform);

                    _characterController = new CompositeController(new KeyboardDirectionalMoveController(_character, cameraRelativeDirection),

                            new KeyboardDirectionalRotationController(_character, cameraRelativeDirection));

                    break;
                }

            case CharacterControlType.ClickToMove:
                {
                    _character.InitializeAgentMovement();

                    CameraRaycaster cameraRaycaster =
                        new CameraRaycaster(
                            _camera,
                            _clickableLayers);

                    _characterController = new ClickToMoveCharacterController(
                        _character,
                        _character,
                        _character,
                        _character,
                        cameraRaycaster,
                        _navMeshSearchDistance,
                        _stopDistance);

                    break;
                }
        }
    }
}