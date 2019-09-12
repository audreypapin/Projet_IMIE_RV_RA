using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TransitionEnigme1 : MonoBehaviour
{
    public Button Trouve;

    void Start()
    {
        Button btn = GameObject.Find("Trouve").GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("SceneEnigme1");
        Debug.Log("You have clicked the button!");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
