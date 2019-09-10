using UnityEngine;
using UnityEngine.UI;

public class RiddleResult : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button rightChoiceRiddle1 = GameObject.Find("Choix2").GetComponent<Button>();
        rightChoiceRiddle1.onClick.AddListener(Success);
    }

    void Success()
    {
        Debug.Log("Bonne réponse !");
    }
}
