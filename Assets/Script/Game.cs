using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private AudioSource _goldSound;
    [SerializeField] private AudioSource _stairEndGameSound;
    [SerializeField] private AudioSource _stairStartGameSound;
    [SerializeField] private Stair _stairEndGame;

    private int _countGold = 10;

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

    private void Start()
    {
        _stairStartGameSound.Play();
    }

    private void PickGoldPlayer()
    {
        _countGold--;
        _goldSound.Play();

        if(_countGold <= 0)
        {
            _stairEndGame.gameObject.SetActive(true);
            _stairEndGameSound.Play();
        }
    }

    private void ReloadGame(float second)
    {
        StartCoroutine(DelayLoadScene(second));
    }

    private IEnumerator DelayLoadScene(float second)
    {
        WaitForSeconds _delayDieReboot = new WaitForSeconds(second);
        yield return _delayDieReboot;
        SceneManager.LoadScene(0);
    }
}
