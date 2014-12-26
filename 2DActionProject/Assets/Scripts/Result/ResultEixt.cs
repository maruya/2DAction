using UnityEngine;
using System.Collections;

public class ResultEixt : MonoBehaviour {

	private bool isSceneInterval ;		// 次のシーンへすぐに移動するのを防止
	private const float INTERVAL = 3f;	// インターバル

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
			if( Input.GetKey(KeyCode.Z) )
			{
				// タイトルへ移動
				SceneChanger changer = GameObject.Find("SceneChange").GetComponent<SceneChanger>();
				changer.SetNextScene("Title") ;
				Destroy(this);
			}
		}
	}
}
