using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RiddleResult : MonoBehaviour
{
    #region Attributes
    private TimerCount timerCount;
    private int nextTransition = 1;
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
        if (SceneManager.GetActiveScene().name == "SceneEnigme1")
        {
            if (PlayerPrefs.HasKey("TransitionNumber"))
                PlayerPrefs.DeleteKey("TransitionNumber");
            nextTransition = 1;
        }
    }

    void Update()
    {
        timerCount = GameObject.Find("Timer").GetComponent<TimerCount>();
    }

    void LoadNextTransition()
    {        
        SceneManager.LoadScene("SceneTransition" + nextTransition);
        nextTransition++;
        PlayerPrefs.SetInt("TransitionNumber", nextTransition);
    }

    void Success()
    {
        PlayerPrefs.SetFloat("Timer", timerCount.maxTime);
        LoadNextTransition();
    }

    void Failure()
    {
        timerCount.maxTime -= 30f;
        PlayerPrefs.SetFloat("Timer", timerCount.maxTime);
        LoadNextTransition();
    }
    #endregion
}
