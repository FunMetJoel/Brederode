using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogNpc : MonoBehaviour
{
    public DialogLine dialog;

    public DialogManager dialogManager;

    public Animator Animator;

    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
        dialogManager.StartDialogButton.onClick.AddListener(ShowDialog);
        canvas.worldCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDialog()
    {
        dialogManager.StartDialogButton.gameObject.SetActive(false);
        Animator.SetBool("AanHetPraten", true);
        dialogManager.StartDialog(dialog);
    }

    public void HideDialog()
    {
        dialogManager.StartDialogButton.gameObject.SetActive(true);
        Animator.SetBool("AanHetPraten", false);
    }
}
