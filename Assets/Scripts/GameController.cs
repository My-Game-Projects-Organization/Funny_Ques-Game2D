using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    int m_rightCount;

    public float timePerQues;
    float m_currentTime;

    private void Awake()
    {
        m_currentTime = timePerQues;
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateQuestion();

        UIManager.Ins.SetTimeText("00:" + m_currentTime);
        StartCoroutine(TimeContingDown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateQuestion()
    {
        QuestionData questionData = QuestionManager.Ins.GetRandomQuestion();

        if(questionData != null)
        {
            UIManager.Ins.SetQuestionText(questionData.question);

            string[] wrongAns = new string[] {questionData.answerA,questionData.answerB,questionData.answerC};

            UIManager.Ins.ShufffleAnswers();

            var temp = UIManager.Ins.answerButton;

            if(temp != null && temp.Length > 0)
            {
                int wrongAnsCount = 0;
                
                for(int i = 0; i < temp.Length; i++)
                {
                    int answerID = i;

                    if(string.Compare(temp[i].tag,"RightAnswer") == 0)
                    {
                        temp[i].setAnswerText(questionData.rightAnswer);
                    }
                    else
                    {
                        temp[i].setAnswerText(wrongAns[wrongAnsCount]);
                        wrongAnsCount++;
                    }

                    temp[answerID].btnCom.onClick.RemoveAllListeners();
                    temp[answerID].btnCom.onClick.AddListener(() => CheckRightAnswer(temp[answerID]));
                }
            }
        }
    }

    public void CheckRightAnswer(AnswerButton answerButton)
    {
        if(answerButton != null && (string.Compare(answerButton.tag,"RightAnswer") == 0)){

            m_rightCount++;

            m_currentTime = timePerQues;
            UIManager.Ins.SetTimeText("00:" + m_currentTime);

            if (m_rightCount == QuestionManager.Ins.questions.Length)
            {
                UIManager.Ins.dialog.setTextDialogContent("Bạn đã chiến thắng!");
                UIManager.Ins.dialog.Show(true);

                AudioController.Ins.StopMusic();
                AudioController.Ins.PlayWinSound();
                StopAllCoroutines();
            }
            else
            {
                CreateQuestion();
                AudioController.Ins.PlayRightSound();
                Debug.Log("Ban da tra loi dung");
            }

        }
        else
        {

            UIManager.Ins.dialog.setTextDialogContent("Bạn đã thua!");
            UIManager.Ins.dialog.Show(true);

            AudioController.Ins.StopMusic();
            AudioController.Ins.PlayLoseSound();
            Debug.Log("ban da tra loi sai");
        }
    }

    IEnumerator TimeContingDown()
    {
        yield return new WaitForSeconds(1);
        if (m_currentTime > 0)
        {
            m_currentTime--;
            StartCoroutine(TimeContingDown());
            UIManager.Ins.SetTimeText("00 :" + m_currentTime);
        }
        else
        {
            UIManager.Ins.dialog.setTextDialogContent("Bạn đã thua!");
            UIManager.Ins.dialog.Show(true);
            StopAllCoroutines();

            AudioController.Ins.StopMusic();
            AudioController.Ins.PlayLoseSound();
        }
       

    }

    public void Replay()
    {
        AudioController.Ins.StopMusic();
        SceneManager.LoadScene("Gameplay");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
