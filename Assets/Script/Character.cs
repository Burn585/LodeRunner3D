using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SwitchAnimations))]
[RequireComponent(typeof(SwitchSound))]

public class Character : MonoBehaviour
{
    [SerializeField] private SwitchAnimations _switchAnimations;
    [SerializeField] private SwitchSound _switchSound;
    [SerializeField] private DetectionStair _detectionStair;
    [SerializeField] private EnemyKilling _enemyKilling;
    [SerializeField] private DetectionZoneEndGame _detectionZoneEndGame;
    [SerializeField] private float _movementSpeed = 5f;

    private Rigidbody _rigidbody;
    private StateMachine _stateMachine;
    private RunState _runState;
    private IdleState _idleState;
    private ClimbState _climbState;
    private FallState _fallState;
    private DieState _dieState;
    private WinState _winState;
    private bool _isMoveStair;
    private Vector3 _stairPosition;
    private bool _isDead = false;
    private bool _isGrounded;
    private CheckGround _checkGround = new CheckGround();

    public Rigidbody Rigidbody => _rigidbody;
    public RunState RunState => _runState;
    public IdleState IdleState => _idleState;
    public ClimbState ClimbState => _climbState;
    public FallState FallState => _fallState;
    public DieState DieState => _dieState;
    public WinState WinState => _winState;
    public float MovementSpeed => _movementSpeed;
    public bool IsMoveStair => _isMoveStair;
    public Vector3 StairPosition => _stairPosition;
    public bool IsDead => _isDead;
    public bool IsGrounded => _isGrounded;

    private void Awake()
    {
        _stateMachine = new StateMachine();
        _runState = new RunState(this, _stateMachine);
        _idleState = new IdleState(this, _stateMachine);
        _climbState = new ClimbState(this, _stateMachine);
        _fallState = new FallState(this, _stateMachine);
        _dieState = new DieState(this, _stateMachine);
        _winState = new WinState(this, _stateMachine);
    }

    private void OnEnable()
    {
        _detectionStair.EnterZoneStair += EnterZoneStair;
        _detectionStair.ExitZoneStair += ExitZoneStair;
        _enemyKilling.CollisionEnemy += Die;
        _detectionZoneEndGame.EnterZoneEndGame += EnterZoneEndGame;
    }

    private void OnDisable()
    {
        _detectionStair.EnterZoneStair -= EnterZoneStair;
        _detectionStair.ExitZoneStair -= ExitZoneStair;
        _enemyKilling.CollisionEnemy -= Die;
        _detectionZoneEndGame.EnterZoneEndGame -= EnterZoneEndGame;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _switchAnimations.enabled = true;
        _switchSound.enabled = true;
        _stateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        _stateMachine.CurrentState.HandleInput();
        _stateMachine.CurrentState.Transition();
        _stateMachine.CurrentState.LogicUpdate();

        _isGrounded = _checkGround.Try(transform.position);
    }

    private void EnterZoneStair(Vector3 stair)
    {
        _isMoveStair = true;
        _stairPosition = stair;
        _rigidbody.useGravity = false;
        _rigidbody.velocity = Vector3.zero;
    }

    private void ExitZoneStair()
    {
        _isMoveStair = false;
        _rigidbody.useGravity = true;
    }

    private void Die()
    {
        _isDead = true;
        _stateMachine.ChangeState(DieState);
    }

    private void EnterZoneEndGame()
    {
        _stateMachine.ChangeState(WinState);
    }
}
