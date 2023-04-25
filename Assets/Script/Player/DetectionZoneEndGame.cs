using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectionZoneEndGame : MonoBehaviour
{
    public UnityAction EnterZoneEndGame;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ZoneEndGame>(out ZoneEndGame zoneEndGame))
        {
            EnterZoneEndGame?.Invoke();
        }
    }
}
