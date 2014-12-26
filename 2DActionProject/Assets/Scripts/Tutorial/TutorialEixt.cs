using UnityEngine;
using System.Collections;

public class TutorialEixt : MonoBehaviour {
	
	void Start () {
	
	}

	void Update () {

		if (Input.GetKey (KeyCode.Z)) 
		{
			// タイトルへ移動
			SceneChanger changer = GameObject.Find("SceneChange").GetComponent<SceneChanger>();
			changer.SetNextScene("Title");
		}
	
	}
}
