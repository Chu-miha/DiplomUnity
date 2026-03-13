using System.Collections;
using UnityEngine;

public class DialogManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    [SerializeField] private string[] linesDialog;
    [SerializeField] private float speedText;
    private int index;

    public void Startup()
    {
        Debug.Log("Dialog manager starting...");
        status = ManagerStatus.Started;
    }

    public void StartDialog(string[] lines)
    {
        index = 0;
        linesDialog = lines;
        MainManager.UIManager.DialogText.text = string.Empty;
        MainManager.EventManager.InvokeDialogActive(true);
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach(char c in linesDialog[index].ToCharArray())
        {
            MainManager.UIManager.DialogText.text += c;
            yield return new WaitForSeconds(speedText);
        }
    }

    public void ScipTextClick()
    {
        if (MainManager.UIManager.DialogText.text == linesDialog[index]) NextLine();
        else
        {
            StopAllCoroutines();
            MainManager.UIManager.DialogText.text = linesDialog[index];

        }
    }

    private void NextLine()
    {
        if(index < linesDialog.Length - 1)
        {
            index++;
            MainManager.UIManager.DialogText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            MainManager.EventManager.InvokeDialogActive(false);
        }
    }
}
