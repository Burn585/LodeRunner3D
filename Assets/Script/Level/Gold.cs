using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gold : MonoBehaviour
{
    public UnityAction PickGold;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            PickGold?.Invoke();
            Destroy(this.gameObject);
        }
    }
}
