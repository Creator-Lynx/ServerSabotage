using System.Collections;
using UnityEngine;

public class CommandReader : MonoBehaviour
{
    [SerializeField] Writer writer;

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
        //if not a coomand
        StartCoroutine(UnknownCommandReaderReaction());
    }

    IEnumerator FunFunction()
    {
        writer.PrintMessage("\nЗдарова Кит и Кабачок. Это тестовый билд чисто посмотреть на консоль. Пока не существует большого количества команд, интеракций и тому подобного. Черканите мне в телегу, приколько ли это вся херня ощущается. \nЗ.Ы. по сути, так и будет начинаться игра, это вроде меню.", 
        TerminalManager.TerminalState.performing);
        yield return new WaitUntil (() => writer.IsWriterReady);
        writer.PrintMomentumMessage("\n\n<color=#ff00ffff>Personal terminal nfPMx16 OS root</color>\n", TerminalManager.TerminalState.input);
    }

    IEnumerator PrintHelp()
    {
        writer.PrintMessage("\nNow we have only HELP function", TerminalManager.TerminalState.performing);
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
}
