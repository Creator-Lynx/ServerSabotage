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
        new string[]{"Party schedule change.", "Due to technical issues, we must inform you that the full party has been postponed.",
        "We apologize for this.", "You will be notified when the party starts. Please wait and stay tuned.",
        "You can now launch a training simulation of the party through your terminal connected to the consciousness expansion chip.",
        "To launch the simulation, use the START command.", "Hint: When using the simulation, remember that you still have access to the terminal via RMB."},
        new string[]{"Greetings, █████████.", "nfPM has analyzed your data. We have decided to accept you for the party. Your sacrifice is invaluable.",
        "Sincerely, nfPM Management"},
        new string[]{"Dear █████████, your request to attend the cake party has been successfully accepted.", 
        "We are currently compiling the guest list; please await further instructions."}
    };

    IEnumerator ExecuteFile(int index)
    {
        for(int i = 0; i < messages[index].Length; i++)
        {
            writer.PrintMessage(messages[index][i] + "\n\n", TerminalManager.TerminalState.performing);
            yield return new WaitUntil (() => writer.IsWriterReady);
            if(i != messages[index].Length - 1)
            {
                writer.PrintRemovableMessage("\nPRESS ANY KEY", TerminalManager.TerminalState.passPossible);
                yield return new WaitUntil(() => terminalManager.IsAnyKeyPressed);
                writer.RestoreTextFromRemovable();
            } 
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
