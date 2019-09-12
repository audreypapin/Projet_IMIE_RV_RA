using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button home = GameObject.Find("Home").GetComponent<Button>();
        home.onClick.AddListener(BackToHome);
    }

    void BackToHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
