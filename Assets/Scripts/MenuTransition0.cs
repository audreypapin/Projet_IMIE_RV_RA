using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuTransition0 : MonoBehaviour
{
    public Button jouer;

    void Start()
    {
        Button btn = GameObject.Find("jouer").GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        Button quit = GameObject.Find("quitter").GetComponent<Button>();
        quit.onClick.AddListener(Quitter);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("SceneUsername");
    }

    void Quitter()
    {
        Application.Quit();
    }
}
