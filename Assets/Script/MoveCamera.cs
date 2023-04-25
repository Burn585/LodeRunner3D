using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _distance = -6;
    [SerializeField] private float _height = 7;
    [SerializeField] private float _rotationX = 10;
    [SerializeField] private float _rotationY = 0;
    [SerializeField] private float _rotationZ = 0;

    private Vector3 _deltaVector;

    private void Update()
    {
        _deltaVector = Vector3.MoveTowards(transform.position, _target.transform.position, Time.deltaTime*_speed);
        _deltaVector.z = _distance;
        _deltaVector.y = _target.transform.position.y - _height;
        transform.position = _deltaVector;

        transform.rotation = Quaternion.Euler(_rotationX, _rotationY, _rotationZ);
    }
}
