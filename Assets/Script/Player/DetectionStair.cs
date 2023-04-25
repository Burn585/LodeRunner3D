using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectionStair : MonoBehaviour
{
    public UnityAction<Vector3> EnterZoneStair;
    public UnityAction ExitZoneStair;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Stair>(out Stair stair))
        {
            EnterZoneStair?.Invoke(stair.transform.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Stair>(out Stair stair))
        {
            ExitZoneStair?.Invoke();
        }
    }
}
