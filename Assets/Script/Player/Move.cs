using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

public class Move : MonoBehaviour
{
    [SerializeField] private float _speedRun = 2;

    private Rigidbody _rigidbody;
    private Animator _animator;
    private float _horizontalMove;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _horizontalMove = Input.GetAxis("Horizontal");
        _rigidbody.position += new Vector3(_horizontalMove, 0, 0) * _speedRun * Time.deltaTime;

        SwitchAnimation();
        Flip();
    }

    private void SwitchAnimation()
    {
        if (_horizontalMove == 0)
        {
            _animator.SetBool("Run", false);
        }
        else
        {
            _animator.SetBool("Run", true);
        }
    }

    private void Flip()
    {
        if (_horizontalMove > 0)
            _rigidbody.rotation = Quaternion.Euler(0, 90, 0);

        if (_horizontalMove < 0)
            _rigidbody.rotation = Quaternion.Euler(0, -90, 0);
    }
}
