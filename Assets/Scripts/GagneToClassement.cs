using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GagneToClassement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GoToClassement");   
    }

    IEnumerator GoToClassement()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("SceneClassement");
    }
}
