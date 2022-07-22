using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Dialog dialog;

    public static UIManager Ins;

    public Text timeText;

    public Text questionText;

    public AnswerButton[] answerButton;

    public void SetTimeText(string text)
    {
        if (timeText)
        {
            timeText.text = text;
        }
    }


    public void SetQuestionText(string text)
    {
        if (questionText)
        {
            questionText.text = text;
        }
    }

    public void ShufffleAnswers()
    {
        if(answerButton != null && answerButton.Length > 0)
        {
            for (int i = 0; i < answerButton.Length; i++)
            {
                if(answerButton[i])
                {
                    answerButton[i].tag = "Untagged";
                }
            }

            int randIdx = Random.Range(0, answerButton.Length);

            if (answerButton[randIdx])
            {
                answerButton[randIdx].tag = "RightAnswer";
            }
        }
    }

    public void Awake()
    {
        MakeSingleTone();
    }

    public void MakeSingleTone()
    {
        if(Ins == null)
        {
            Ins = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
