using UnityEngine;
using UnityEngine.UI;

public class PrintResults : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HighScore(PlayerPrefs.GetInt("NumberOfCorrect"), PlayerPrefs.GetInt("NumberOfFalse"), PlayerPrefs.GetFloat("Timer"));

        Text corrects = GameObject.Find("Corrects").GetComponent<Text>();
        Text mauvais = GameObject.Find("Mauvais").GetComponent<Text>();
        Text temps = GameObject.Find("Temps").GetComponent<Text>();

        for (int i = 0; i < 10; i++)
        {
            corrects.text += PlayerPrefs.GetInt("HCorrect" + i) + "\r\n\r\n";
            mauvais.text += PlayerPrefs.GetInt("HFalse" + i) + "\r\n\r\n";
            temps.text += Mathf.RoundToInt(PlayerPrefs.GetFloat("HTime" + i)) + "\r\n\r\n";
        }
    }

    void HighScore(int correctAnswers, int falseAnswers, float time)
    {
        int newCorrect = correctAnswers;
        int newFalse = falseAnswers;
        float newTime = time;
        int oldCorrect;
        int oldFalse;
        float oldTime;

        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.HasKey("HCorrect" + i))
            {
                if (PlayerPrefs.GetInt("HCorrect" + i) == newCorrect)
                {
                    if (PlayerPrefs.GetFloat("HTime" + i) < newTime)
                    {
                        oldCorrect = PlayerPrefs.GetInt("HCorrect" + i);
                        oldFalse = PlayerPrefs.GetInt("HFalse" + i);
                        oldTime = PlayerPrefs.GetFloat("HTime" + i);

                        PlayerPrefs.SetInt("HCorrect" + i, newCorrect);
                        PlayerPrefs.SetInt("HFalse" + i, newFalse);
                        PlayerPrefs.SetFloat("HTime" + i, newTime);

                        newCorrect = oldCorrect;
                        newFalse = oldFalse;
                        newTime = oldTime;
                    }
                }
                else if (PlayerPrefs.GetInt("HCorrect" + i) < newCorrect)
                {
                    oldCorrect = PlayerPrefs.GetInt("HCorrect" + i);
                    oldFalse = PlayerPrefs.GetInt("HFalse" + i);
                    oldTime = PlayerPrefs.GetFloat("HTime" + i);

                    PlayerPrefs.SetInt("HCorrect" + i, newCorrect);
                    PlayerPrefs.SetInt("HFalse" + i, newFalse);
                    PlayerPrefs.SetFloat("HTime" + i, newTime);

                    newCorrect = oldCorrect;
                    newFalse = oldFalse;
                    newTime = oldTime;
                }
            }
            else
            {
                PlayerPrefs.SetInt("HCorrect" + i, newCorrect);
                PlayerPrefs.SetInt("HFalse" + i, newFalse);
                PlayerPrefs.SetFloat("HTime" + i, newTime);
                newCorrect = 0;
                newFalse = 0;
                newTime = 0f;
            }
        }
    }
}
