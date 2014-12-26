using UnityEngine;
using System.Collections;

public class SelectMenu : MonoBehaviour {
	
	void Start () {

	}

	void Update () {

	}

	void OnGUI()
	{
		// 各選択先に移動
		if(GUI.Button(new Rect(150,160,220,20), "スタート"))
		{
			SceneChanger changer = GameObject.Find("SceneChange").GetComponent<SceneChanger>();
			changer.SetNextScene("Stage1");
		}

		if(GUI.Button(new Rect(150,200,220,20), "操作説明"))
		{
			SceneChanger changer = GameObject.Find("SceneChange").GetComponent<SceneChanger>();
			changer.SetNextScene("Tutorial");
		}

		if (GUI.Button (new Rect (150, 240, 220, 20), "終了")) Application.Quit ();

	}

}//124,576