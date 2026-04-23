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
        
        if(Keyboard.current.anyKey.wasPressedThisFrame)
        {
            if(currentState == TerminalState.passPossible)
                isAnyKeyPressed = true;
            stampAudioSource.PlayOneShot(stampClip);
        }

    }

    bool isAnyKeyPressed = false;

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
        writer.PrintMomentumMessage("\n\n<color=#ff00ffff>Personal terminal nfPMx16 OS root</color>", TerminalState.input);
    }
}
