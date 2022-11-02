using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _distance = -6;
    [SerializeField] private float _height = 7;

    private Vector3 deltaVector;

    private void Update()
    {
        deltaVector = Vector3.MoveTowards(transform.position, _target.transform.position, Time.deltaTime*_speed);
        deltaVector.z = _distance;
        deltaVector.y = _height;
        transform.position = deltaVector;
    }
}
