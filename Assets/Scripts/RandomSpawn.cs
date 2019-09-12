using System.Collections;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
	#region Attributes
	public GameObject myPrefab;
    public static bool canSpawn = true;
    private GameObject instance;
	private bool spawning;
    private int spawnTimer = 5;
    #endregion

    #region Functions
    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        StartCoroutine(Spawn());
    }

	void Update()
	{
        if (null == instance && !spawning)
		{
			spawnTimer = Random.Range(5, 11);
			StartCoroutine(Spawn());
		}
	}

	IEnumerator Spawn()
    {
		spawning = true;
        yield return new WaitForSeconds(spawnTimer);
        if (canSpawn)
        {
            Camera cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>() as Camera;
            instance = Instantiate(myPrefab, cam.transform.position + cam.transform.forward * 3, Quaternion.Euler(new Vector3(0, cam.transform.eulerAngles.y + 180, 0)));
        }
		spawning = false;
	}
	#endregion
}
