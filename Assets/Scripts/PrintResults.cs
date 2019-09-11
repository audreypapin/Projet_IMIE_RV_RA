using UnityEngine;
using UnityEngine.UI;

public class PrintResults : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HighScore(PlayerPrefs.GetInt("NumberOfCorrect"), PlayerPrefs.GetInt("NumberOfFalse"), PlayerPrefs.GetFloat("Timer"));

        Text premier = GameObject.Find("Premier").GetComponent<Text>();
        premier.text = PlayerPrefs.GetInt("HCorrect0") + " | " + PlayerPrefs.GetInt("HFalse0") + " | " + PlayerPrefs.GetFloat("HTime0");

        Text deuxieme = GameObject.Find("Deuxieme").GetComponent<Text>();
        deuxieme.text = PlayerPrefs.GetInt("HCorrect1") + " | " + PlayerPrefs.GetInt("HFalse1") + " | " + PlayerPrefs.GetFloat("HTime1");
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
                if (PlayerPrefs.GetInt("HCorrect" + i) < newCorrect)
                {
                    if (PlayerPrefs.GetFloat("HTime" + i) < newTime)
                    {
                        oldCorrect = PlayerPrefs.GetInt("HCorrect" + i);
                        oldFalse = PlayerPrefs.GetInt("HFalse" + i);
                        oldTime = PlayerPrefs.GetInt("HTime" + i);

                        PlayerPrefs.SetInt("HCorrect" + i, newCorrect);
                        PlayerPrefs.SetInt("HFalse" + i, newFalse);
                        PlayerPrefs.SetFloat("HTime" + i, newTime);

                        newCorrect = oldCorrect;
                        newFalse = oldFalse;
                        newTime = oldTime;
                    }
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
