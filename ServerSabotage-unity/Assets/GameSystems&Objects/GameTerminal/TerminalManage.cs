using System;
using UnityEngine;

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
        
    }
}
