using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassementTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoadClassement");
    }

    IEnumerator LoadClassement()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("SceneClassement");
    }
}
