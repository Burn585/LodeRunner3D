using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private AudioSource _gold;

    private int _countGold = 10;
    private WaitForSeconds _delay = new WaitForSeconds(5);

    private void OnEnable()
    {
        _character.PickGold += PickGoldPlayer;
        _character.DieState.EndStateDie += ReloadGame;
    }

    private void OnDisable()
    {
        _character.PickGold -= PickGoldPlayer;
        _character.DieState.EndStateDie -= ReloadGame;
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

    private void ReloadGame()
    {
        StartCoroutine(DelayLoadScene());
    }

    private IEnumerator DelayLoadScene()
    {
        yield return _delay;
        SceneManager.LoadScene(0);
    }
}
