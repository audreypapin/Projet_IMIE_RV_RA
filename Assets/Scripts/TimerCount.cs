using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerCount : MonoBehaviour
{
    #region Attributes
    private Text timer;
    public bool keepTicking = true;
    [SerializeField]
    public float maxTime;
    #endregion

    #region Functions
    // Start is called before the first frame update
    void Start()
    {
        if (maxTime == 0f)
            maxTime = 600f;

        if (PlayerPrefs.HasKey("Timer"))
            maxTime = PlayerPrefs.GetFloat("Timer");
        timer = GameObject.Find("Timer").GetComponent<Text>();

        if (SceneManager.GetActiveScene().name == "SceneEnigme1")
        {
            if (PlayerPrefs.HasKey("Timer"))
                PlayerPrefs.DeleteKey("Timer");
            maxTime = 40f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (keepTicking)
        {
            maxTime -= Time.deltaTime;
            timer.text = "Temps restant : " + Mathf.RoundToInt(maxTime);
        }
        if (maxTime < 0)
        {
            keepTicking = false;
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Mauvais"))
            {
                go.GetComponent<Button>().interactable = false;
            }
            GameObject.FindGameObjectWithTag("Bon").GetComponent<Button>().interactable = false;

            PlayerPrefs.SetFloat("Timer", 0f);
            SceneManager.LoadScene("ScenePerdu");
        }
    }
    #endregion
}
