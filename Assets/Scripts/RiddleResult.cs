using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RiddleResult : MonoBehaviour
{
    #region Attributes
    private TimerCount timerCount;
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
    }

    void Update()
    {
        timerCount = GameObject.Find("Timer").GetComponent<TimerCount>();
    }

    void Success()
    {
        // SceneManager.LoadScene("Enigme2");
        Debug.Log("Bonne réponse !");
    }

    void Failure()
    {
        timerCount.maxTime -= 30f;
    }
    #endregion
}
