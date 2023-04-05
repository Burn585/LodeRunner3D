using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private AudioSource _gold;
    [SerializeField] private Stair _stairEndGame;

    private int _countGold = 1;
    private WaitForSeconds _delay = new WaitForSeconds(4);

    private void OnEnable()
    {
        _character.PickGold += PickGoldPlayer;
        _character.DieState.EndStateDie += ReloadGame;
        _character.WinState.EndStateWin += ReloadGame;
    }

    private void OnDisable()
    {
        _character.PickGold -= PickGoldPlayer;
        _character.DieState.EndStateDie -= ReloadGame;
        _character.WinState.EndStateWin -= ReloadGame;
    }

    private void PickGoldPlayer()
    {
        _countGold--;
        _gold.Play();

        if(_countGold <= 0)
        {
            _stairEndGame.gameObject.SetActive(true);
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
