using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadCommandExecutor : MonoBehaviour
{
    [SerializeField] Writer writer;
    [SerializeField] TerminalManager terminalManager;
    public void Read(int index)
    {
        if(index >= messages.Count || index < 0)
        {
            StartCoroutine(IncorrectMessage());
            return;
        }
        StartCoroutine(ExecuteFile(index));
    }
    List<string[]> messages = new List<string[]>
    {
        new string[]{},
        new string[]{"", "",""}
    };

    IEnumerator ExecuteFile(int index)
    {
        for(int i = 0; i < messages[index].Length; i++)
        {
            writer.PrintMessage(messages[index][i] + "\n\n", TerminalManager.TerminalState.performing);
            yield return new WaitUntil (() => writer.IsWriterReady);
            writer.PrintRemovableMessage("\nPRESS ANY KEY", TerminalManager.TerminalState.passPossible);
            yield return new WaitUntil(() => terminalManager.IsAnyKeyPressed);
            writer.RestoreTextFromRemovable();
        }
        writer.PrintMomentumMessage("\n\n<color=#ff00ffff>Personal terminal nfPMx16 OS root</color>\n", TerminalManager.TerminalState.input);
    }
    IEnumerator IncorrectMessage()
    {

            writer.PrintMessage("\nIncorrect message number. Message does not exist.", TerminalManager.TerminalState.performing);
            yield return new WaitUntil (() => writer.IsWriterReady);

        writer.PrintMomentumMessage("\n\n<color=#ff00ffff>Personal terminal nfPMx16 OS root</color>\n", TerminalManager.TerminalState.input);
    }
}
