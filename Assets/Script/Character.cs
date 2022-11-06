using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Character : MonoBehaviour
{
    [SerializeField] private SwitchAnimations _switchAnimations;

    public Rigidbody _rigidbody;
    public StateMachine StateMachine;
    public MovingState MovingState;
    public IdleState IdleState;

    private float _movementSpeed = 5f;

    public float MovementSpeed => _movementSpeed;

    private void Awake()
    {
        StateMachine = new StateMachine();
        MovingState = new MovingState(this, StateMachine);
        IdleState = new IdleState(this, StateMachine);
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
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
}
