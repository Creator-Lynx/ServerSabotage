using UnityEngine;
using TMPro;
using System.Collections;


public class Writer : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textMesh;
    [SerializeField]
    TerminalManager terminalManager;

    [SerializeField] AudioSource printAudioSource;
    float standardAudioPitch;
    [SerializeField] float pitchRandomRange = 0.1f;
    [SerializeField] AudioClip printClip;
    void Start()
    {
        standardAudioPitch = printAudioSource.pitch;
    }

    //loading animation ===========================================================================
    #region LoadingAnimation
    string bufferedText;
    public void StartLoading()
    {
        terminalManager.currentState = TerminalManager.TerminalState.performing;
        bufferedText = textMesh.text;
        isPerformingLoading = true;
        StartCoroutine(PerformLoading());
    }
    public void EndLoading(TerminalManager.TerminalState state)
    {
        terminalManager.currentState = state;
        isPerformingLoading = false;
        currentLoadingProgress = 0;
        textMesh.text = bufferedText;
    }
    public void SetLoadingProgress(int p)
    {
        if(isPerformingLoading)
        currentLoadingProgress = Mathf.Clamp(p, 0, 100);
    }

    int currentLoadingProgress = 0;
    bool isPerformingLoading = false;
    char[] loadingChar = {'|', '/', '-', '\\'};
    IEnumerator PerformLoading()
    {
        string buffer = "Loading...";
        int i = 0;
        while(isPerformingLoading)
        {
            if(currentLoadingProgress == 0)
            {
                buffer = "\nLoading... " + loadingChar[i % loadingChar.Length];
            }
            else
            {
                buffer = "\nLoading... " + currentLoadingProgress + '%';
            }
            textMesh.text = bufferedText + buffer;
            i++;
            yield return new WaitForSeconds(0.2f);
        }
    }
    #endregion
    //end loading animation block ===========================================================================

    #region MessagePrinting
    public bool IsWriterReady = true;
    public void PrintMessage(string message, TerminalManager.TerminalState finalState)
    {
        StartCoroutine(PrintingMessage(message, finalState));
    }
    public void PrintMomentumMessage(string message, TerminalManager.TerminalState finalState)
    {
        textMesh.text += message;
        printAudioSource.PlayOneShot(printClip);
        terminalManager.currentState = finalState;
    }
    public void PrintRemovableMessage(string message, TerminalManager.TerminalState finalState)
    {
        bufferedText = textMesh.text;
        textMesh.text += message;
        printAudioSource.PlayOneShot(printClip);
        terminalManager.currentState = finalState;
    }
    public void RestoreTextFromRemovable()
    {
        textMesh.text = bufferedText;
    }

    IEnumerator PrintingMessage(string message, TerminalManager.TerminalState finalState)
    {
        IsWriterReady = false;
        terminalManager.currentState = TerminalManager.TerminalState.performing;
        textMesh.text += '\n';
        for (int i = 0; i < message.Length; i++)
        {
            yield return new WaitForSeconds(0.04f + ((i % 8 == 0) ? 0.04f : 0));
            textMesh.text += message[i];
            printAudioSource.PlayOneShot(printClip);
            printAudioSource.pitch = standardAudioPitch + ((i % 4 == 0) ? pitchRandomRange : 0);
        }
        terminalManager.currentState = finalState;
        IsWriterReady = true;;
    }
    #endregion
}
