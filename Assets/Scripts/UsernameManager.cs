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
        if (username.text == "")
            PlayerPrefs.SetString("Username", "Username" + Random.Range(0, 1000));
        else
            PlayerPrefs.SetString("Username", username.text);
        Debug.Log("Username is : " + PlayerPrefs.GetString("Username"));
        SceneManager.LoadScene("SceneTransition0");
    }
}
