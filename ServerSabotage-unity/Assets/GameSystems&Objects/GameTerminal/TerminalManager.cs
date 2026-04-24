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

    [SerializeField] Writer writer;
    [SerializeField] CommandReader commandReader;

    [SerializeField] AudioSource stampAudioSource;
    [SerializeField] AudioClip stampClip;


    void Start()
    {
        currentState = TerminalState.performing;
        StartCoroutine(FirstLoadingProgram());
    }
    void Update()
    {
        //if(Keyboard.current.digit1Key.wasPressedThisFrame) writer.SetLoadingProgress(10);
        //Keyboard.current.on
        
        if(currentState == TerminalState.passPossible)
        {
            if(Keyboard.current.anyKey.wasPressedThisFrame)
            {
                stampAudioSource.PlayOneShot(stampClip);
                isAnyKeyPressed = true;
            }    
        }
        if(currentState == TerminalState.input)
            OperateUserInput();
    }

    void OperateUserInput()
    {
        if(Keyboard.current.backspaceKey.wasPressedThisFrame) DeleteSymbol();
        if(Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.numpadEnterKey.wasPressedThisFrame) GotoCommandExecution();

        if(Keyboard.current.qKey.wasPressedThisFrame) WriteSymbol('q');
        if(Keyboard.current.wKey.wasPressedThisFrame) WriteSymbol('w');
        if(Keyboard.current.eKey.wasPressedThisFrame) WriteSymbol('e');
        if(Keyboard.current.rKey.wasPressedThisFrame) WriteSymbol('r');
        if(Keyboard.current.tKey.wasPressedThisFrame) WriteSymbol('t');
        if(Keyboard.current.yKey.wasPressedThisFrame) WriteSymbol('y');
        if(Keyboard.current.uKey.wasPressedThisFrame) WriteSymbol('u');
        if(Keyboard.current.iKey.wasPressedThisFrame) WriteSymbol('i');
        if(Keyboard.current.oKey.wasPressedThisFrame) WriteSymbol('o');
        if(Keyboard.current.pKey.wasPressedThisFrame) WriteSymbol('p');
        if(Keyboard.current.aKey.wasPressedThisFrame) WriteSymbol('a');
        if(Keyboard.current.sKey.wasPressedThisFrame) WriteSymbol('s');
        if(Keyboard.current.dKey.wasPressedThisFrame) WriteSymbol('d');
        if(Keyboard.current.fKey.wasPressedThisFrame) WriteSymbol('f');
        if(Keyboard.current.gKey.wasPressedThisFrame) WriteSymbol('g');
        if(Keyboard.current.hKey.wasPressedThisFrame) WriteSymbol('h');
        if(Keyboard.current.jKey.wasPressedThisFrame) WriteSymbol('j');
        if(Keyboard.current.kKey.wasPressedThisFrame) WriteSymbol('k');
        if(Keyboard.current.lKey.wasPressedThisFrame) WriteSymbol('l');
        if(Keyboard.current.zKey.wasPressedThisFrame) WriteSymbol('z');
        if(Keyboard.current.xKey.wasPressedThisFrame) WriteSymbol('x');
        if(Keyboard.current.cKey.wasPressedThisFrame) WriteSymbol('c');
        if(Keyboard.current.vKey.wasPressedThisFrame) WriteSymbol('v');
        if(Keyboard.current.bKey.wasPressedThisFrame) WriteSymbol('b');
        if(Keyboard.current.nKey.wasPressedThisFrame) WriteSymbol('n');
        if(Keyboard.current.mKey.wasPressedThisFrame) WriteSymbol('m');

        if(Keyboard.current.digit0Key.wasPressedThisFrame || Keyboard.current.numpad0Key.wasPressedThisFrame) WriteSymbol('0');
        if(Keyboard.current.digit1Key.wasPressedThisFrame || Keyboard.current.numpad1Key.wasPressedThisFrame) WriteSymbol('1');
        if(Keyboard.current.digit2Key.wasPressedThisFrame || Keyboard.current.numpad2Key.wasPressedThisFrame) WriteSymbol('2');
        if(Keyboard.current.digit3Key.wasPressedThisFrame || Keyboard.current.numpad3Key.wasPressedThisFrame) WriteSymbol('3');
        if(Keyboard.current.digit4Key.wasPressedThisFrame || Keyboard.current.numpad4Key.wasPressedThisFrame) WriteSymbol('4');
        if(Keyboard.current.digit5Key.wasPressedThisFrame || Keyboard.current.numpad5Key.wasPressedThisFrame) WriteSymbol('5');
        if(Keyboard.current.digit6Key.wasPressedThisFrame || Keyboard.current.numpad6Key.wasPressedThisFrame) WriteSymbol('6');
        if(Keyboard.current.digit7Key.wasPressedThisFrame || Keyboard.current.numpad7Key.wasPressedThisFrame) WriteSymbol('7');
        if(Keyboard.current.digit8Key.wasPressedThisFrame || Keyboard.current.numpad8Key.wasPressedThisFrame) WriteSymbol('8');
        if(Keyboard.current.digit9Key.wasPressedThisFrame || Keyboard.current.numpad9Key.wasPressedThisFrame) WriteSymbol('9');

        if(Keyboard.current.commaKey.wasPressedThisFrame) WriteSymbol(',');
        if(Keyboard.current.minusKey.wasPressedThisFrame) WriteSymbol('-');
        if(Keyboard.current.periodKey.wasPressedThisFrame) WriteSymbol('.');
        if(Keyboard.current.spaceKey.wasPressedThisFrame) WriteSymbol(' ');

        if(Keyboard.current.downArrowKey.wasPressedThisFrame) {} //change last writed command
        if(Keyboard.current.upArrowKey.wasPressedThisFrame) {} //change last writed command
    }
    [SerializeField] string commandBuffer = "";

    void WriteSymbol(char c)
    {
        writer.PrintSymbol(c);
        //call keyboard animation by char
        stampAudioSource.PlayOneShot(stampClip);
        commandBuffer += c;
    }
    void DeleteSymbol()
    {
        writer.DeleteSymbol();
        //call keyboard animation by char
        stampAudioSource.PlayOneShot(stampClip);
        if(commandBuffer.Length > 0)
        commandBuffer = commandBuffer.Remove(commandBuffer.Length - 1);
    }
    void GotoCommandExecution()
    {
        commandReader.Read(commandBuffer);
        if(commandBuffer.Length > 0) commandBuffer = commandBuffer.Remove(0);
        //call keyboard animation by char
        stampAudioSource.PlayOneShot(stampClip);
        writer.PrintSymbol('\n');
    }



    bool isAnyKeyPressed = false;
    public bool IsAnyKeyPressed
    {
        get { return isAnyKeyPressed; }
    }

    IEnumerator FirstLoadingProgram()
    {
        writer.PrintMessage("\n\n<color=white>Personal terminal nfPMx16 OS root</color>", TerminalState.performing);
        yield return new WaitUntil(() => writer.IsWriterReady);

        writer.StartLoading();
        yield return new WaitForSeconds(3);
        writer.EndLoading(TerminalState.passPossible);

        writer.PrintRemovableMessage("\nPRESS ANY KEY", TerminalState.passPossible);
        yield return new WaitUntil(() => isAnyKeyPressed);
        isAnyKeyPressed = false;
        writer.RestoreTextFromRemovable();

        writer.StartLoading();
        yield return new WaitForSeconds(1);
        for(int i = 0; i < 101; i++)
        {
            writer.SetLoadingProgress(i);
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.5f);
        writer.EndLoading(TerminalState.performing);

        //here a welcome message
        writer.PrintMessage("\nWelcome, dear user. You are using the interface of the portable terminal system.\n", TerminalState.performing);
        yield return new WaitUntil(() => writer.IsWriterReady);
        writer.PrintRemovableMessage("\nPRESS ANY KEY", TerminalState.passPossible);
        yield return new WaitUntil(() => isAnyKeyPressed);
        isAnyKeyPressed = false;
        writer.RestoreTextFromRemovable();

        writer.PrintMessage("\nThis system is used to connect to stationary terminals, search for connections, signals, and interact with information structures.\n",
        TerminalState.performing);
        yield return new WaitUntil(() => writer.IsWriterReady);
        writer.PrintRemovableMessage("\nPRESS ANY KEY", TerminalState.passPossible);
        yield return new WaitUntil(() => isAnyKeyPressed);
        isAnyKeyPressed = false;
        writer.RestoreTextFromRemovable();

        writer.StartLoading();
        yield return new WaitForSeconds(2);
        writer.EndLoading(TerminalState.passPossible);

         writer.PrintMessage("\n3 new messages found.\n",
        TerminalState.performing);
        yield return new WaitUntil(() => writer.IsWriterReady);

        //helping message
        writer.PrintMessage("\nHint: To read a message, type the command \"read N\", where N is the message number (0 is the last message).\n", 
        TerminalState.performing);
        yield return new WaitUntil(() => writer.IsWriterReady);
        writer.PrintMessage("To get help with commands, use \"help\"\n", TerminalState.performing);
        yield return new WaitUntil(() => writer.IsWriterReady);
        writer.PrintMomentumMessage("\n\n<color=#ff00ffff>Personal terminal nfPMx16 OS root</color>\n", TerminalState.input);
    }
}
