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
                StartCoroutine(InvalidArgumentsNumberReaderReaction("read", 1));
                return;
            }
            if(int.TryParse(splittedCommand[1], out int result))
            {
                readExecutor.Read(result);
                return;
            }
            else
            {
                StartCoroutine(InvalidArgumentsReaderReaction("read", "integer"));
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
        writer.PrintMessage("\nHELP — shows the command list", 
        TerminalManager.TerminalState.performing);
        yield return new WaitUntil (() => writer.IsWriterReady);
        writer.PrintMessage("\n\nREAD n — reads messages received on the device via the operating system. N is a number of message, from last recieved (0) to the earliest. Example of use: <color=white>read 1</color>", 
        TerminalManager.TerminalState.performing, Writer.PrintSpeed.fast);
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
        writer.PrintMessage("\nThere is too much or not enough arguments, command\n" + "<color=white>" + command.ToUpper() + "</color>" + 
        "\ntakes up to " + arguments + " arguments.", 
        TerminalManager.TerminalState.performing, Writer.PrintSpeed.fast);
        yield return new WaitUntil (() => writer.IsWriterReady);
        writer.PrintMomentumMessage("\n\n<color=#ff00ffff>Personal terminal nfPMx16 OS root</color>\n", TerminalManager.TerminalState.input);
    }
    IEnumerator InvalidArgumentsReaderReaction(string command, string argumentType)
    {
        writer.PrintMessage("\nInvalid argument. Command\n" + "<color=white>" + command.ToUpper() + "</color>" + "\ntakes only " + argumentType + " type.", 
        TerminalManager.TerminalState.performing, Writer.PrintSpeed.fast);
        yield return new WaitUntil (() => writer.IsWriterReady);
        writer.PrintMomentumMessage("\n\n<color=#ff00ffff>Personal terminal nfPMx16 OS root</color>\n", TerminalManager.TerminalState.input);
    }
}
