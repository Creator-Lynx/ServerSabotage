using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
 
public class TerminalManager : MonoBehaviour
{
    public enum TerminalState
    {
        input,
        performing,
        passPossible
    }

    public TerminalState currentState;

    [SerializeField] Writer writer;

    [SerializeField] AudioSource stampAudioSource;
    [SerializeField] AudioClip stampClip;


    void Start()
    {
        currentState = TerminalState.performing;
        StartCoroutine(FirstLoadingCorutine());
    }

    void Update()
    {
        //if(Keyboard.current.digit1Key.wasPressedThisFrame) writer.SetLoadingProgress(10);
        //Keyboard.current.on
        
        if(Keyboard.current.anyKey.wasPressedThisFrame)
        {
            if(currentState == TerminalState.passPossible)
                isAnyKeyPressed = true;
            stampAudioSource.PlayOneShot(stampClip);
        }

    }

    bool isAnyKeyPressed = false;

    IEnumerator FirstLoadingCorutine()
    {
        writer.PrintMessage("\n\nPersonal terminal nfPMx16 OS root", TerminalState.performing);
        yield return new WaitUntil(() => writer.IsWriterReady);
        writer.StartLoading();
        yield return new WaitForSeconds(3);
        writer.EndLoading(TerminalState.passPossible);
        writer.PrintRemovableMessage("\nPRESS ANY KEY", TerminalState.passPossible);
        yield return new WaitUntil(() => isAnyKeyPressed);
        isAnyKeyPressed = false;
        writer.RestoreTextFromRemovable();
        writer.StartLoading();
    }
}
