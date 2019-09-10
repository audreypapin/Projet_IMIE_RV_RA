using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RiddleResult : MonoBehaviour
{
    #region Attributes
    //private TimerCount timerCount;
    //private float maxTime;
    #endregion

    #region Functions
    // Start is called before the first frame update
    void Start()
    {
        //maxTime = timerCount.MaxTime;
        Button rightChoiceRiddle1 = GameObject.Find("Choix2").GetComponent<Button>();
        rightChoiceRiddle1.onClick.AddListener(Success);
        Button wrongChoiceRiddle1 = GameObject.Find("Choix1").GetComponent<Button>();
        wrongChoiceRiddle1.onClick.AddListener(Failure);
    }

    void Success()
    {
        // SceneManager.LoadScene("Enigme2");
        Debug.Log("Bonne réponse !");
    }

    void Failure()
    {
        //maxTime -= 30f;
        Debug.Log("Mauvaise réponse !");
    }
    #endregion
}
