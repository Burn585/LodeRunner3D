using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Character : MonoBehaviour
{
    [SerializeField] private SwitchAnimations _switchAnimations;

    public Rigidbody _rigidbody;
    public StateMachine StateMachine;

    public RunState RunState;
    public IdleState IdleState;
    public ClimbState ClimbState;
    public AttackState AttackState;
    public FallState FallState;
    public CrawlState CrawlState;
    public DieState DieState;
    public WinState WinState;

    private float _movementSpeed = 5f;
    private bool _isMoveStair;
    private Vector3 _stairPosition;
    private bool _isGrounded;

    public float MovementSpeed => _movementSpeed;
    public bool IsMoveStair => _isMoveStair;
    public Vector3 StairPosition => _stairPosition;
    public bool IsGrounded => _isGrounded;

    private void Awake()
    {
        StateMachine = new StateMachine();
        RunState = new RunState(this, StateMachine);
        IdleState = new IdleState(this, StateMachine);
        ClimbState = new ClimbState(this, StateMachine);
        AttackState = new AttackState(this, StateMachine);
        FallState = new FallState(this, StateMachine);
        DieState = new DieState(this, StateMachine);
        WinState = new WinState(this, StateMachine);
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _switchAnimations.enabled = true;
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentState.HandleInput();
        StateMachine.CurrentState.Transition();
        StateMachine.CurrentState.LogicUpdate();

        _isGrounded = CheckGround();
        Debug.Log(_isGrounded);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Stair>(out Stair stair))
        {
            _isMoveStair = true;
            _rigidbody.useGravity = false;
            _stairPosition = stair.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Stair>(out Stair stair))
        {
            _isMoveStair = false;
            _rigidbody.useGravity = true;
        }
    }

    private bool CheckGround()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawRay(transform.position, Vector3.down);
            if (hit.distance < 0.5f)
                return true;
        }

        return false;
    }
}
