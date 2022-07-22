using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager Ins;

    public QuestionData[] questions;

    List<QuestionData> questionList;

    QuestionData m_currentQues;

    public QuestionData CurrentQues { get => m_currentQues; set => m_currentQues = value; }

    private void Awake()
    {
        questionList =  questions.ToList();

        MakeSingleTone();
    }

    public QuestionData GetRandomQuestion()
    {
        if (questionList != null && questionList.Count > 0)
        {
            int randIdx = Random.Range(0, questionList.Count);

            m_currentQues = questionList[randIdx];

            // xoa cau hoi da hoi
            questionList.RemoveAt(randIdx);
        }
        return m_currentQues;
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
