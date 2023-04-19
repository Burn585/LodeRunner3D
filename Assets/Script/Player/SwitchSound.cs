using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]

public class SwitchSound : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private AudioSource _run;
    [SerializeField] private AudioSource _climb;
    [SerializeField] private AudioSource _crawl;
    [SerializeField] private AudioSource _fall;
    [SerializeField] private AudioSource _attack;
    [SerializeField] private AudioSource _die;
    [SerializeField] private AudioSource _win;

    private void OnEnable()
    {
        _character.RunState.StartStateRun += Play;
        _character.RunState.EndStateRun += Stop;

        _character.ClimbState.StartStateClimb += Play;
        _character.ClimbState.EndStateClimb += Stop;

        _character.FallState.StartStateFall += Play;
        _character.FallState.EndStateFall += Stop;

        _character.DieState.StartStateDie += Play;

        _character.WinState.StartStateWin += Play;
    }

    private void OnDisable()
    {
        _character.RunState.StartStateRun -= Play;
        _character.RunState.EndStateRun -= Stop;

        _character.ClimbState.StartStateClimb -= Play;
        _character.ClimbState.EndStateClimb -= Stop;

        _character.FallState.StartStateFall -= Play;
        _character.FallState.EndStateFall -= Stop;

        _character.DieState.StartStateDie -= Play;

        _character.WinState.StartStateWin -= Play;
    }

    private void Play(string sound)
    {
        switch (sound)
        {
            case "Run":
                _run.Play();
                break;
            case "Crawl":
                _crawl.Play();
                break;
            case "Climb":
                _climb.Play();
                break;
            case "Fall":
                _fall.Play();
                break;
            case "Attack":
                _attack.Play();
                break;
            case "Die":
                _die.Play();
                break;
            case "Win":
                _win.Play();
                break;
        }
    }

    private void Stop(string sound)
    {
        switch (sound)
        {
            case "Run":
                _run.Stop();
                break;
            case "Crawl":
                _crawl.Stop();
                break;
            case "Climb":
                _climb.Stop();
                break;
            case "Fall":
                _fall.Stop();
                break;
            case "Attack":
                _attack.Stop();
                break;
            case "Die":
                _die.Stop();
                break;
            case "Win":
                _win.Stop();
                break;
        }
    }
}
