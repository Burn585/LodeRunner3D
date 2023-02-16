using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private AudioSource _gold;

    private int _countGold = 10;

    private void OnEnable()
    {
        _character.PickGold += PickGoldPlayer;
    }

    private void OnDisable()
    {
        _character.PickGold -= PickGoldPlayer;
    }

    private void PickGoldPlayer()
    {
        _countGold--;
        _gold.Play();

        if(_countGold <= 0)
        {
            //spawn stair
        }
    }
}
