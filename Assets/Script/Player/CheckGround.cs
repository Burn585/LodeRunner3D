using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public bool Try(Vector3 positionPlayer)
    {
        Collider[] colliders;
        float sizeBoxX = 1f;
        float sizeBoxY = 0.1f;
        float sizeBoxZ = 0.1f;
        float offset = 0.2f;
        Vector3 centerCheckBoxPoint = positionPlayer;
        Vector3 sizeBox = new Vector3(sizeBoxX, sizeBoxY, sizeBoxZ);

        centerCheckBoxPoint.y -= offset;
        colliders = Physics.OverlapBox(centerCheckBoxPoint, sizeBox);

        foreach (var item in colliders)
        {
            if (item.TryGetComponent<Brick>(out Brick brick))
            {
                return true;
            }
        }

        return false;
    }
}
