using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]

public class Character : MonoBehaviour
{
    [SerializeField] private SwitchAnimations _switchAnimations;
    [SerializeField] private SwitchSound _switchSound;
    [SerializeField] private float _movementSpeed = 5f;

    private bool _isMoveStair;
    private Vector3 _stairPosition;
    private bool _isGrounded;
    private LayerMask _groundMask = 6;

    public UnityAction PickGold;

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
        _switchSound.enabled = true;
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentState.HandleInput();
        StateMachine.CurrentState.Transition();
        StateMachine.CurrentState.LogicUpdate();

        _isGrounded = CheckGround();
        //Debug.Log("Ground  "+ _isGrounded);
        //Debug.Log("Stair  " + _isMoveStair);
        //Debug.Log("grav   " + _rigidbody.useGravity);

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Stair>(out Stair stair))
        {
            _isMoveStair = true;
            _stairPosition = stair.transform.position;
            _rigidbody.useGravity = false;
            _rigidbody.velocity = Vector3.zero;
        }

        if(other.TryGetComponent<Gold>(out Gold gold))
        {
            PickGold?.Invoke();
            Destroy(gold.gameObject);
        }

        if(other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Debug.Log("game over");
            StateMachine.ChangeState(DieState);
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
        Collider[] colliders;
        float offset = 0.2f;
        Vector3 centerCheckBoxPoint = transform.position;
        Vector3 sizeBox = new Vector3(0.6f, 0.1f, 0.1f);

        centerCheckBoxPoint.y -= offset;
        colliders = Physics.OverlapBox(centerCheckBoxPoint, sizeBox);

        foreach (var item in colliders)
        {
            if (item.TryGetComponent<Brick>(out Brick brick))
            {
                return true;
            }
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawCube(transform.position, new Vector3(0.8f, 1.5f, 0.2f));
    }
}
