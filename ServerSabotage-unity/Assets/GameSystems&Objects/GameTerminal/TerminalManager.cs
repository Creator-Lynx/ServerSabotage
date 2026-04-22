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

    [SerializeField]
    Writer writer;

    void Update()
    {
        //if(Keyboard.current.digit1Key.wasPressedThisFrame) writer.SetLoadingProgress(10);
        //Keyboard.current.on
    }



    void Start()
    {
        currentState = TerminalState.performing;
        StartCoroutine(FirstLoadingCorutine());
    }
    IEnumerator FirstLoadingCorutine()
    {
        writer.StartLoading();
        yield return new WaitForSeconds(3);
        writer.EndLoading();
    }
}
