using UnityEngine;
using UnityEngine.AI;

public class Character :
    MonoBehaviour,
    IDamageable,
    IHealable,
    IDirectionalMovable,
    IDirectionalRotatable,
    INavMeshMovable,
    INavMeshLinkTraversable,
    IMovementTarget
{
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _rotationSpeed = 1000f;

    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private float _woundedPercent = 0.3f;

    [SerializeField] private float _jumpSpeed = 5f;
    [SerializeField] private AnimationCurve _jumpCurve;

    [SerializeField] private float _climbSpeed = 2f;

    private DirectionalMover _directionalMover;
    private AgentMover _agentMover;

    private AgentJumper _jumper;
    private AgentClimber _climber;
    private AgentLinkTraverser _linkTraverser;

    private DirectionalRotator _rotator;
    private Health _health;

    private NavMeshAgent _agent;

    private Vector3 _targetPoint;

    private bool _hasTarget;
    private bool _isDamage;

    public Vector3 CurrentVelocity
    {
        get
        {
            if (_agentMover != null)
                return _agentMover.CurrentVelocity;

            if (_directionalMover != null)
                return _directionalMover.CurrentVelocity;

            return Vector3.zero;
        }
    }

    public Quaternion CurrentRotation
    {
        get
        {
            if (_rotator != null)
                return _rotator.CurrentRotation;

            return transform.rotation;
        }
    }

    public Vector3 Position => transform.position;

    public Vector3 TargetPoint => _targetPoint;

    public bool HasTarget => _hasTarget;

    public bool IsDead => _health.IsDead;

    public bool IsWounded => _health.IsWounded;

    public bool IsDamage => _isDamage;

    public int CurrentHealth => _health.CurrentHealth;

    public bool IsLinkTraversalInProcess => _linkTraverser != null && _linkTraverser.InProcess;

    public NavMeshLinkTraversalType CurrentLinkTraversalType
    {
        get
        {
            if (_linkTraverser == null)
                return NavMeshLinkTraversalType.None;

            return _linkTraverser.CurrentTraversalType;
        }
    }

    private void Awake()
    {
        InitializeHealth();
    }

    private void Update()
    {
        if (_health.IsDead)
            return;

        if (_directionalMover != null)
            _directionalMover.Update(Time.deltaTime);

        if (_agentMover != null && IsLinkTraversalInProcess == false)
        {
            _rotator.SetInputDirection(_agentMover.CurrentVelocity);
        }

        if (_rotator != null)
            _rotator.Update(Time.deltaTime);
    }

    private void InitializeHealth()
    {
        _health = new Health(_maxHealth, _woundedPercent);
    }

    public void InitializeDirectionalMovement()
    {
        _agent = null;
        _agentMover = null;

        _jumper = null;
        _climber = null;
        _linkTraverser = null;

        if (TryGetComponent(out CharacterController characterController))
        {
            _directionalMover = new CharacterControllerDirectionalMover(
                    characterController,
                    _moveSpeed);

            _rotator = new TransformDirectionalRotator(
                    transform,
                    _rotationSpeed);

            return;
        }

        if (TryGetComponent(out Rigidbody rigidbody))
        {
            _directionalMover = new RigidbodyDirectionalMover(rigidbody, _moveSpeed);

            _rotator = new RigidbodyDirectionalRotator(rigidbody, _rotationSpeed);

            return;
        }

        Debug.LogError("Не найден CharacterController или Rigidbody");
    }

    public void InitializeAgentMovement()
    {
        _directionalMover = null;

        if (TryGetComponent(out NavMeshAgent agent) == false)
        {
            Debug.LogError("Не найден NavMeshAgent");
            return;
        }

        _agent = agent;

        _agent.updateRotation = false;
        _agent.autoTraverseOffMeshLink = false;

        _agentMover = new AgentMover(_agent, _moveSpeed);

        _rotator = new TransformDirectionalRotator(transform, _rotationSpeed);

        _jumper = new AgentJumper(_agent, this, _jumpSpeed, _jumpCurve);

        _climber = new AgentClimber(_agent, this, _climbSpeed);

        _linkTraverser = new AgentLinkTraverser(_jumper, _climber, _rotator);
    }

    public void SetMoveDirection(Vector3 direction)
    {
        if (_health.IsDead)
            return;

        if (_directionalMover == null)
            return;

        _directionalMover.SetInputDirection(direction);
    }

    public void SetRotationDirection(Vector3 direction)
    {
        if (_health.IsDead)
            return;

        if (_rotator == null)
            return;

        _rotator.SetInputDirection(direction);
    }

    public void SetDestination(Vector3 position)
    {
        if (_health.IsDead)
            return;

        if (_agentMover == null)
            return;

        _agentMover.SetDestination(position);
    }

    public void StopMove()
    {
        if (_agentMover == null)
            return;

        _agentMover.Stop();
    }

    public void ResumeMove()
    {
        if (_health.IsDead)
            return;

        if (_agentMover == null)
            return;

        _agentMover.Resume();
    }

    public void ResetPath()
    {
        if (_agentMover == null)
            return;

        _agentMover.ResetPath();
    }

    public bool TryGetPath(Vector3 targetPosition, NavMeshPath pathToTarget)
    {
        if (_agent == null)
            return false;

        return NavMeshUtils.TryGetPath(_agent, targetPosition, pathToTarget);
    }

    public void SetTargetPoint(Vector3 targetPoint)
    {
        _targetPoint = targetPoint;
        _hasTarget = true;
    }

    public void ClearTarget()
    {
        _hasTarget = false;
    }

    public bool TryGetCurrentLink(out OffMeshLinkData linkData)
    {
        if (_agent != null && _agent.isOnOffMeshLink)
        {
            linkData = _agent.currentOffMeshLinkData;

            return true;
        }

        linkData = default;

        return false;
    }

    public void TraverseLink(OffMeshLinkData linkData)
    {
        if (_linkTraverser == null)
            return;

        _linkTraverser.Traverse(linkData);
    }

    public void TakeDamage(int damage)
    {
        _isDamage = true;

        _health.TakeDamage(damage);

        Debug.Log("Здоровье: " + _health.CurrentHealth);
    }

    public void ResetDamageFlag()
    {
        _isDamage = false;
    }

    public void Heal(int health)
    {
        if (_health.IsDead)
            return;

        _health.Heal(health);
    }
}