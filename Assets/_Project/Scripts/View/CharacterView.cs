using UnityEngine;

public class CharacterView : MonoBehaviour
{
    private readonly int IsRunningKey = Animator.StringToHash("isRunning");

    private readonly int IsJumpingKey = Animator.StringToHash("isJumping");

    private readonly int IsClimbingKey = Animator.StringToHash("isClimbing");

    private readonly int IsDeadTriggerKey = Animator.StringToHash("isDeadTrigger");

    private readonly int IsDamageTriggerKey = Animator.StringToHash("isDamageTrigger");

    [SerializeField] private Animator _animator;
    [SerializeField] private Character _character;

    private bool _isDeadAnimationActive;

    private void Update()
    {
        if (_character.IsDead)
        {
            if (_isDeadAnimationActive == false)
                StartDead();

            return;
        }

        UpdateWoundedState();

        if (_character.IsDamage)
            StartDamage();

        UpdateMovementAnimation();
    }

    private void UpdateMovementAnimation()
    {
        NavMeshLinkTraversalType traversalType = _character.CurrentLinkTraversalType;

        if (traversalType == NavMeshLinkTraversalType.Jump)
        {
            StartJumping();
            return;
        }

        if (traversalType == NavMeshLinkTraversalType.Climb)
        {
            StartClimbing();
            return;
        }

        StopJumping();
        StopClimbing();

        if (_character.CurrentVelocity.magnitude > 0.05f)
            StartRunning();
        else
            StopRunning();
    }

    private void UpdateWoundedState()
    {
        if (_character.IsWounded)
            _animator.SetLayerWeight(1, 1f);
        else
            _animator.SetLayerWeight(1, 0f);
    }

    private void StartRunning()
    {
        _animator.SetBool(IsRunningKey, true);
    }

    private void StopRunning()
    {
        _animator.SetBool(IsRunningKey, false);
    }

    private void StartJumping()
    {
        StopRunning();
        StopClimbing();

        _animator.SetBool(IsJumpingKey, true);
    }

    private void StopJumping()
    {
        _animator.SetBool(IsJumpingKey, false);
    }

    private void StartClimbing()
    {
        StopRunning();
        StopJumping();

        _animator.SetBool(IsClimbingKey, true);
    }

    private void StopClimbing()
    {
        _animator.SetBool(IsClimbingKey, false);
    }

    private void StartDead()
    {
        _isDeadAnimationActive = true;

        _animator.SetTrigger(IsDeadTriggerKey);
    }

    private void StartDamage()
    {
        _animator.SetTrigger(IsDamageTriggerKey);

        _character.ResetDamageFlag();
    }
}