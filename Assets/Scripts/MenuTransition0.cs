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
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("SceneTransition0");
    }


    // Update is called once per frame
    void Update()
    {

    }
}
