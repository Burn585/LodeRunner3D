using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAnimations : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        _character.IdleState.StartStateIdle += AnimationChanger;

        _character.RunState.ChangeDirection += Flip;
        _character.RunState.StartStateRun += AnimationChanger;

        _character.ClimbState.StartStateClimb += AnimationChanger;
        _character.ClimbState.PauseAnimation += AnimationStartStop;

        _character.FallState.StartStateFall += AnimationChanger;

        _character.DieState.StartStateDie += AnimationChanger;

        _character.WinState.StartStateWin += AnimationChanger;
    }

    private void OnDisable()
    {
        _character.IdleState.StartStateIdle -= AnimationChanger;

        _character.RunState.ChangeDirection -= Flip;
        _character.RunState.StartStateRun -= AnimationChanger;

        _character.ClimbState.StartStateClimb -= AnimationChanger;
        _character.ClimbState.PauseAnimation -= AnimationStartStop;

        _character.FallState.StartStateFall -= AnimationChanger;

        _character.DieState.StartStateDie -= AnimationChanger;

        _character.WinState.StartStateWin -= AnimationChanger;
    }

    private void Flip(float horizontalMove)
    {
        if(horizontalMove > 0)
            _character._rigidbody.rotation = Quaternion.Euler(0, 180, 0);

        if (horizontalMove < 0)
            _character._rigidbody.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void AnimationChanger(string animationName)
    {
        _animator.Play(animationName);
    }

    private void AnimationStartStop(bool play)
    {
        if (play)
        {
            _animator.StartPlayback();
        }
        else
        {
            _animator.StopPlayback();
        }
    }
}
