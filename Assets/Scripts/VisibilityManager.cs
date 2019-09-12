using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VisibilityManager : MonoBehaviour
{
	#region Attributes
	Camera cam;
	bool isVisible;
	#endregion

	#region Functions
	void Start()
	{
		cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>() as Camera;
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 viewPos = cam.WorldToViewportPoint(this.gameObject.transform.position);
		if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
		{
			if (!isVisible)
			{
				isVisible = true;
				StartCoroutine(VisibilityTimer());
			}
		}
		else
		{
			if (isVisible)
			{
				isVisible = false;
				StartCoroutine(InvisibilityTimer());
			}
		}
	}

	IEnumerator VisibilityTimer()
	{
		yield return new WaitForSeconds(3);
		if (isVisible)
		{
			SceneManager.LoadScene("ScenePerdu");
		}
	}

    IEnumerator InvisibilityTimer()
    {
	    yield return new WaitForSeconds(5);
	    if (!isVisible)
	    {
		    Destroy(this.gameObject);
	    }
    }
	#endregion
}
