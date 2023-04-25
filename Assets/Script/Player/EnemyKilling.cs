using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Character))]

public class EnemyKilling : MonoBehaviour
{
    [SerializeField] private Character _character; 

    public UnityAction CollisionEnemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy) && _character.IsDead == false)
        {
            CollisionEnemy?.Invoke();
        }
    }
}
