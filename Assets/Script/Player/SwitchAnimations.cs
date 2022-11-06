using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAnimations : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        _character.MovingState.ChangeDirection += Flip;
        _character.MovingState.StopHorizontalMove += AnimationChanger;

        _character.IdleState.StartHorizontalMove += AnimationChanger;
    }

    private void OnDisable()
    {
        _character.MovingState.ChangeDirection -= Flip;
        _character.MovingState.StopHorizontalMove -= AnimationChanger;

        _character.IdleState.StartHorizontalMove -= AnimationChanger;
    }

    private void Flip(float horizontalMove)
    {
        if(horizontalMove > 0)
            _character._rigidbody.rotation = Quaternion.Euler(0, 90, 0);

        if (horizontalMove < 0)
            _character._rigidbody.rotation = Quaternion.Euler(0, -90, 0);
    }

    private void AnimationChanger(string animationName)
    {
        _animator.Play(animationName);
    }
}
