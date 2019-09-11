using UnityEngine;
using UnityEngine.UI;

public class TimerCount : MonoBehaviour
{
    #region Attributes
    private Text timer;
    private bool keepTicking = true;
    [SerializeField]
    public float maxTime;
    #endregion

    #region Functions
    // Start is called before the first frame update
    void Start()
    {
        if(maxTime == 0f)
        {
            maxTime = 600f;
        }

        timer = GameObject.Find("Timer").GetComponent<Text>();
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
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Choix"))
            {
                go.GetComponent<Button>().interactable = false;
            }
        }
    }
    #endregion
}
