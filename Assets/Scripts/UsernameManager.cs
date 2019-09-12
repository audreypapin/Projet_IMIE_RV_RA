using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UsernameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button validation = GameObject.Find("Validation").GetComponent<Button>();
        validation.onClick.AddListener(ValidateUsername);
    }

    void ValidateUsername()
    {
        Text username = GameObject.Find("Username").GetComponent<Text>();
        PlayerPrefs.SetString("Username", username.text);
        SceneManager.LoadScene("SceneTransition0");
    }
}
