using UnityEngine;

public class TerminalManage : MonoBehaviour
{
    public enum TerminalState
    {
        input,
        performing,
        passpossible
    }

    TerminalState currentState;
    void Start()
    {
        currentState = TerminalState.performing;
    }


    void Update()
    {
        
    }
}
