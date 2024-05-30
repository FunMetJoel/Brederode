using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

[System.Serializable]
public class DialogLine
{
    public string dialogText;
    public AudioClip dialogAudio;

    public List<DialogOption> dialogOptions;
}

[System.Serializable]
public class DialogOption
{
    public string optionText;
    public DialogLine nextDialogLine;
}

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;

    public GameObject options;
    public GameObject optionPrefab;
    public Button StartDialogButton;

    public TMPro.TextMeshProUGUI dialogTextBox;

    public UnityEvent dialogEndCallback;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDialogText(string dialogText)
    {
        dialogTextBox.text = dialogText;
    }

    public void SetDialogOptions(List<DialogOption> dialogOptions)
    {
        foreach (Transform child in options.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (DialogOption dialogOption in dialogOptions)
        {
            GameObject option = Instantiate(optionPrefab, options.transform);
            option.GetComponentInChildren<TextMeshProUGUI>().text = dialogOption.optionText;
            option.GetComponent<Button>().onClick.AddListener(() => { SetDialog(dialogOption.nextDialogLine); });
        }
    }
    
    public void SetDialog(DialogLine dialogLine)
    {
        if (dialogLine.dialogText == "")
        {
            EndDialog();
        }

        // Set dialog text
        SetDialogText(dialogLine.dialogText);

        // Set dialog audio
        // audioSource.clip = dialogLine.dialogAudio;

        // Set dialog options
        SetDialogOptions(dialogLine.dialogOptions);
    }


    public void StartDialog(DialogLine dialogLine)
    {
        dialogBox.SetActive(true);
        SetDialog(dialogLine);
    }

    public void EndDialog()
    {
        dialogBox.SetActive(false);
        dialogTextBox.text = "";
        foreach (Transform child in options.transform)
        {
            Destroy(child.gameObject);
        }

        dialogEndCallback.Invoke();
        dialogEndCallback.RemoveAllListeners();
    }

}
