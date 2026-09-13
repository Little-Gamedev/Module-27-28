using UnityEngine;

public class CharacterControllerDirectionalMover : DirectionalMover
{
    private const float _gravityForce = -9.81f;

    private readonly CharacterController _characterController;

    public CharacterControllerDirectionalMover(
        CharacterController characterController,
        float movementSpeed)
        : base(movementSpeed)
    {
        _characterController = characterController;
    }

    public override void Update(float deltaTime)
    {
        Vector3 velocity = CurrentVelocity;
        velocity.y = _gravityForce;

        _characterController.Move(
            velocity * deltaTime);
    }
}