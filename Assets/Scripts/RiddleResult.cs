using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RiddleResult : MonoBehaviour
{
    #region Attributes
    private TimerCount timerCount;
    private int nextTransition = 1;
    private int numberOfCorrect = 0;
    private int numberOfFalse = 0;
    #endregion

    #region Functions
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] badChoices = GameObject.FindGameObjectsWithTag("Mauvais");
        foreach (GameObject go in badChoices)
        {
            go.GetComponent<Button>().onClick.AddListener(Failure);
        }
        GameObject goodChoice = GameObject.FindGameObjectWithTag("Bon");
        goodChoice.GetComponent<Button>().onClick.AddListener(Success);

        if (PlayerPrefs.HasKey("TransitionNumber"))
            nextTransition = PlayerPrefs.GetInt("TransitionNumber");
        if (PlayerPrefs.HasKey("NumberOfCorrect"))
            numberOfCorrect = PlayerPrefs.GetInt("NumberOfCorrect");
        if (PlayerPrefs.HasKey("NumberOfFalse"))
            numberOfFalse = PlayerPrefs.GetInt("NumberOfFalse");
        if (SceneManager.GetActiveScene().name == "SceneEnigme1")
        {
            if (PlayerPrefs.HasKey("TransitionNumber"))
                PlayerPrefs.DeleteKey("TransitionNumber");
            if (PlayerPrefs.HasKey("NumberOfCorrect"))
                PlayerPrefs.DeleteKey("NumberOfCorrect");
            if (PlayerPrefs.HasKey("NumberOfFalse"))
                PlayerPrefs.DeleteKey("NumberOfFalse");
            nextTransition = 1;
            numberOfCorrect = 0;
            numberOfFalse = 0;
        }
    }

    void Update()
    {
        timerCount = GameObject.Find("Timer").GetComponent<TimerCount>();
    }

    void LoadNextTransition()
    {
        PlayerPrefs.SetFloat("Timer", timerCount.maxTime);
        PlayerPrefs.SetInt("NumberOfCorrect", numberOfCorrect);
        PlayerPrefs.SetInt("NumberOfFalse", numberOfFalse);
        if (SceneManager.GetActiveScene().name == "SceneEnigme7")
        {
            timerCount.keepTicking = false;
            SceneManager.LoadScene("SceneClassement");
        }
        else if (SceneManager.GetActiveScene().name != "SceneEnigme7" && timerCount.maxTime < 0)
        {
            timerCount.keepTicking = false;
            SceneManager.LoadScene("ScenePerdu");
        }
        else
        {
            SceneManager.LoadScene("SceneTransition" + nextTransition);
            nextTransition++;
            PlayerPrefs.SetInt("TransitionNumber", nextTransition);
        }
    }

    void Success()
    {
        numberOfCorrect++;
        LoadNextTransition();
    }

    void Failure()
    {
        timerCount.maxTime -= 30f;     
        numberOfFalse++;
        LoadNextTransition();
    }
    #endregion
}
