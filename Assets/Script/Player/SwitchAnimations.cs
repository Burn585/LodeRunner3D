using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAnimations : MonoBehaviour
{
    [SerializeField] private Character _character;

    private void OnEnable()
    {
        _character.MovingState._changeDirection += Flip;
    }

    private void OnDisable()
    {
        _character.MovingState._changeDirection -= Flip;
    }

    private void Flip(float horizontalMove)
    {
        if(horizontalMove > 0)
            _character._rigidbody.rotation = Quaternion.Euler(0, 90, 0);

        if (horizontalMove < 0)
            _character._rigidbody.rotation = Quaternion.Euler(0, -90, 0);
    }
}
