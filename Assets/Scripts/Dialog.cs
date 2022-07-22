using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Text dialogContentText;

    public void Show(bool state)
    {
        gameObject.SetActive(state);
    }

    public void setTextDialogContent(string text)
    {
        if (dialogContentText)
        {
            dialogContentText.text = text;
        }
    }

}
