using UnityEngine;
using System.Collections;

public class TutorialEixt : MonoBehaviour {

	private bool isSceneInterval ;
	private const float INTERVAL = 3f;

	void Start () {
	
		isSceneInterval = false;
	}

	IEnumerator ChangeNextScene()
	{
		yield return new WaitForSeconds (INTERVAL);
		isSceneInterval = true;
	}

	void Update () {

		StartCoroutine (ChangeNextScene ());

		if (isSceneInterval)
		{
			if (Input.GetKey (KeyCode.Z))
			{
				// タイトルへ移動
				SceneChanger changer = GameObject.Find ("SceneChange").GetComponent<SceneChanger> ();
				changer.SetNextScene ("Title");
				Destroy(this);
			}
		}
	}
}
