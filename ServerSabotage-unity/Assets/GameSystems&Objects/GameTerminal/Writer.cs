using UnityEngine;
using TMPro;
using System.Collections;

public class Writer : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textMesh;

    //loading animation ===========================================================================
    #region LoadingAnimation
    string bufferedText;
    public void StartLoading()
    {
        bufferedText = textMesh.text;
        isPerformingLoading = true;
        StartCoroutine(PerformLoading());

    }
    public void EndLoading()
    {
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
}
