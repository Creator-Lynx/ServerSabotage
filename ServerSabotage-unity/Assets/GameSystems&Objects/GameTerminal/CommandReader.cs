using System.Collections;
using TMPro;
using UnityEngine;

public class CommandReader : MonoBehaviour
{
    [SerializeField] Writer writer;
    [SerializeField] ReadCommandExecutor readExecutor;
    public void Read(string command)
    {
        if(string.Compare(command, "help") == 0)
        {
            StartCoroutine(PrintHelp());
            return;
        }
        if(string.Compare(command, "fun") == 0)
        {
            StartCoroutine(FunFunction());
            return;
        }
        string[] splittedCommand = command.Split(new char[]{' '}, System.StringSplitOptions.RemoveEmptyEntries);
        if(splittedCommand.Length == 0)
        {
            StartCoroutine(UnknownCommandReaderReaction()); 
            return;
        }
        if(splittedCommand[0].CompareTo("read") == 0)
        {
            if(splittedCommand.Length != 2)
            {
                InvalidArgumentsNumberReaderReaction("read", 1);
                return;
            }
            if(int.TryParse(splittedCommand[1], out int result))
            {
                readExecutor.Read(result);
                return;
            }
            else
            {
                InvalidArgumentsReaderReaction("read", "integer");
                return;
            }

        }  

        StartCoroutine(UnknownCommandReaderReaction()); 
    }

    IEnumerator FunFunction()
    {
  
        writer.PrintMessage(Anek.GetAnek(), TerminalManager.TerminalState.performing);
        yield return new WaitUntil (() => writer.IsWriterReady);
        writer.PrintMomentumMessage("\n\n<color=#ff00ffff>Personal terminal nfPMx16 OS root</color>\n", TerminalManager.TerminalState.input);
    }
    IEnumerator PrintHelp()
    {
        writer.PrintMessage("\nHELP shows the command list\n", 
        TerminalManager.TerminalState.performing);
        yield return new WaitUntil (() => writer.IsWriterReady);
        writer.PrintMomentumMessage("\n\n<color=#ff00ffff>Personal terminal nfPMx16 OS root</color>\n", TerminalManager.TerminalState.input);
    }

    IEnumerator UnknownCommandReaderReaction()
    {
        writer.PrintMessage("\nUnknown command. Use \"help\" to see accessible command list.", TerminalManager.TerminalState.performing);
        yield return new WaitUntil (() => writer.IsWriterReady);
        writer.PrintMomentumMessage("\n\n<color=#ff00ffff>Personal terminal nfPMx16 OS root</color>\n", TerminalManager.TerminalState.input);
    }
    IEnumerator UnknownCommandReaderReaction(string command)
    {
        writer.PrintMessage('\n' + command + "is unknown command. Use \"help\" to see accessible command list.", TerminalManager.TerminalState.performing);
        yield return new WaitUntil (() => writer.IsWriterReady);
        writer.PrintMomentumMessage("\n\n<color=#ff00ffff>Personal terminal nfPMx16 OS root</color>\n", TerminalManager.TerminalState.input);
    }
    IEnumerator InvalidArgumentsNumberReaderReaction(string command, int arguments)
    {
        writer.PrintMessage("\nThere is too much or not enough arguments, command\n" + command + "\n takes up to " + arguments + " arguments.", 
        TerminalManager.TerminalState.performing, Writer.PrintSpeed.fast);
        yield return new WaitUntil (() => writer.IsWriterReady);
        writer.PrintMomentumMessage("\n\n<color=#ff00ffff>Personal terminal nfPMx16 OS root</color>\n", TerminalManager.TerminalState.input);
    }
    IEnumerator InvalidArgumentsReaderReaction(string command, string argumentType)
    {
        writer.PrintMessage("\nInvalid argument. Command\n" + command + "\n takes only " + argumentType, 
        TerminalManager.TerminalState.performing, Writer.PrintSpeed.fast);
        yield return new WaitUntil (() => writer.IsWriterReady);
        writer.PrintMomentumMessage("\n\n<color=#ff00ffff>Personal terminal nfPMx16 OS root</color>\n", TerminalManager.TerminalState.input);
    }
}
