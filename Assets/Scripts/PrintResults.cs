using UnityEngine;
using UnityEngine.UI;

public class PrintResults : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HighScore(PlayerPrefs.GetString("Username"), PlayerPrefs.GetInt("NumberOfCorrect"), PlayerPrefs.GetInt("NumberOfFalse"), PlayerPrefs.GetFloat("Timer"));

        Text username = GameObject.Find("Username").GetComponent<Text>();
        Text corrects = GameObject.Find("Corrects").GetComponent<Text>();
        Text mauvais = GameObject.Find("Mauvais").GetComponent<Text>();
        Text temps = GameObject.Find("Temps").GetComponent<Text>();

        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.HasKey("HUsername" + i))
                username.text += PlayerPrefs.GetString("HUsername" + i) + "\r\n\r\n";
            if (PlayerPrefs.HasKey("HCorrect" + i))
                corrects.text += PlayerPrefs.GetInt("HCorrect" + i) + "\r\n\r\n";
            if (PlayerPrefs.HasKey("HFalse" + i))
                mauvais.text += PlayerPrefs.GetInt("HFalse" + i) + "\r\n\r\n";
            if (PlayerPrefs.HasKey("HTime" + i))
                temps.text += Mathf.RoundToInt(PlayerPrefs.GetFloat("HTime" + i)) + "\r\n\r\n";
        }
    }

    void HighScore(string username, int correctAnswers, int falseAnswers, float time)
    {
        string newUsername = username;
        int newCorrect = correctAnswers;
        int newFalse = falseAnswers;
        float newTime = time;
        string oldUsername;
        int oldCorrect;
        int oldFalse;
        float oldTime;

        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.HasKey("HUsername" + i))
            {
                if ((PlayerPrefs.GetInt("HCorrect" + i) == newCorrect && PlayerPrefs.GetFloat("HTime" + i) < newTime) ||
                    PlayerPrefs.GetInt("HCorrect" + i) < newCorrect)
                {
                    oldUsername = PlayerPrefs.GetString("Username" + i);
                    oldCorrect = PlayerPrefs.GetInt("HCorrect" + i);
                    oldFalse = PlayerPrefs.GetInt("HFalse" + i);
                    oldTime = PlayerPrefs.GetFloat("HTime" + i);

                    PlayerPrefs.SetString("HUsername" + i, newUsername);
                    PlayerPrefs.SetInt("HCorrect" + i, newCorrect);
                    PlayerPrefs.SetInt("HFalse" + i, newFalse);
                    PlayerPrefs.SetFloat("HTime" + i, newTime);

                    newUsername = oldUsername;
                    newCorrect = oldCorrect;
                    newFalse = oldFalse;
                    newTime = oldTime;
                }
            }
            else
            {
                PlayerPrefs.SetString("HUsername" + i, newUsername);
                PlayerPrefs.SetInt("HCorrect" + i, newCorrect);
                PlayerPrefs.SetInt("HFalse" + i, newFalse);
                PlayerPrefs.SetFloat("HTime" + i, newTime);
                break;
            }
        }
    }
}
