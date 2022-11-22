using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSound : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private AudioSource _runSound;

    private void OnEnable()
    {
        _character.RunState.StartStateRun += PlaySound;
        _character.RunState.EndStateRun += StopSound;
    }

    private void OnDisable()
    {
        _character.RunState.StartStateRun -= PlaySound;
        _character.RunState.EndStateRun -= StopSound;
    }

    private void PlaySound(string sound)
    {
        switch (sound)
        {
            case "Run":
                _runSound.Play();
                break;
            case "Crowl":
                break;
        }
    }

    private void StopSound(string sound)
    {
        switch (sound)
        {
            case "Run":
                _runSound.Stop();
                break;
            case "Crowl":
                break;
        }
    }
}
