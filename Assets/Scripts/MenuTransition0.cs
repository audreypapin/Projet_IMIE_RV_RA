using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        Application.LoadLevel("SceneTransition0");
        Debug.Log("You have clicked the button!");
    }


    // Update is called once per frame
    void Update()
    {

    }
}
