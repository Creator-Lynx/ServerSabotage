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

    void Start()
    {
        currentState = TerminalState.performing;
        StartCoroutine(FirstLoadingCorutine());
    }

    void Update()
    {
        //if(Keyboard.current.digit1Key.wasPressedThisFrame) writer.SetLoadingProgress(10);
        //Keyboard.current.on
    }


    IEnumerator FirstLoadingCorutine()
    {
        StartCoroutine(writer.PrintingMessage("Personal terminal nfPMx16 OS root", TerminalState.performing));
        yield return new WaitUntil(() => writer.IsWriterReady);
        writer.StartLoading();
        yield return new WaitForSeconds(3);
        writer.EndLoading(TerminalState.passPossible);
        writer.PrintMessage("\n PRESS ANY KEY", TerminalState.passPossible);
    }
}
