using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TerminalManage : MonoBehaviour
{
    public enum TerminalState
    {
        input,
        performing,
        passPossible
    }

    TerminalState currentState;

    [SerializeField]
    Writer writer;
    void Start()
    {
        currentState = TerminalState.performing;
        writer.StartLoading();
    }


    void Update()
    {
        if(Keyboard.current.digit1Key.wasPressedThisFrame) writer.SetLoadingProgress(10);
        if(Keyboard.current.digit2Key.wasPressedThisFrame) writer.SetLoadingProgress(20);
        if(Keyboard.current.digit3Key.wasPressedThisFrame) writer.SetLoadingProgress(30);
        if(Keyboard.current.digit4Key.wasPressedThisFrame) writer.SetLoadingProgress(40);
        if(Keyboard.current.digit5Key.wasPressedThisFrame) writer.SetLoadingProgress(50);
        if(Keyboard.current.digit6Key.wasPressedThisFrame) writer.SetLoadingProgress(60);
        if(Keyboard.current.digit7Key.wasPressedThisFrame) writer.SetLoadingProgress(70);
        if(Keyboard.current.digit8Key.wasPressedThisFrame) writer.SetLoadingProgress(80);
        if(Keyboard.current.digit9Key.wasPressedThisFrame) writer.SetLoadingProgress(90);
        if(Keyboard.current.digit0Key.wasPressedThisFrame) writer.SetLoadingProgress(100);
    }
}
