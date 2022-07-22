using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public Button btnCom;

    public Text answerText;

    public void setAnswerText(string text)
    {
        if (answerText)
        {
            answerText.text = text;
        }
    }
}
