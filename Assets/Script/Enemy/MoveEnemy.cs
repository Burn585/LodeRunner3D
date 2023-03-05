using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] _pathPoint;
    [SerializeField] private float _speed = 5f;
 
    private int _currentPoint;

    private void Update()
    {
        Transform target = _pathPoint[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if(transform.position == target.position)
        {
            _currentPoint++;

            if(_currentPoint >= _pathPoint.Length)
            {
                _currentPoint = 0;
            }

            if (_pathPoint[_currentPoint].position.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}
