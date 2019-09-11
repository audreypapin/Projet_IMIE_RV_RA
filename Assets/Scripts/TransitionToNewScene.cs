using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionToNewScene : MonoBehaviour
{
    #region Attributes
    private TimerCount timerCount;
    private int nextScene = 2;
    #endregion

    #region Functions
    // Start is called before the first frame update
    void Start()
    {
        Button validation = GameObject.Find("Validation").GetComponent<Button>();
        validation.onClick.AddListener(LoadNextScene);

        if (PlayerPrefs.HasKey("SceneNumber"))
            nextScene = PlayerPrefs.GetInt("SceneNumber");
        if (SceneManager.GetActiveScene().name == "SceneTransition1")
        {
            if (PlayerPrefs.HasKey("SceneNumber"))
                PlayerPrefs.DeleteKey("SceneNumber");
            nextScene = 2;
        }
    }

    void Update()
    {
        timerCount = GameObject.Find("Timer").GetComponent<TimerCount>();
    }

    void LoadNextScene()
    {
        PlayerPrefs.SetFloat("Timer", timerCount.maxTime);
        SceneManager.LoadScene("SceneEnigme" + nextScene);
        nextScene++;
        PlayerPrefs.SetInt("SceneNumber", nextScene);
    }
    #endregion
}
