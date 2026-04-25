using System.Collections;
using UnityEngine;

public class ReadCommandExecutor : MonoBehaviour
{
    [SerializeField] Writer writer;
    public void Read(int index)
    {
        StartCoroutine(ExecuteFile(0));
    }

    IEnumerator ExecuteFile(int index)
    {
        writer.PrintMessage("\nCommand read is execute", TerminalManager.TerminalState.performing);
        yield return new WaitUntil (() => writer.IsWriterReady);
        writer.PrintMomentumMessage("\n\n<color=#ff00ffff>Personal terminal nfPMx16 OS root</color>\n", TerminalManager.TerminalState.input);
    }
}
