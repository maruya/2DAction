using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class Stage1Clear : MonoBehaviour {
	

	void Start()
	{
	}


	void Update()
	{
	}

	void OnTriggerEnter2D(Collider2D collider2d)
	{
		// 対応したオブジェクトに当たるとステージ2へ移動
		if (collider2d.name == "player") 
		{
			SceneChanger changer = GameObject.Find("SceneChange").GetComponent<SceneChanger>();
			changer.SetNextScene("Stage2");
		}
	}
}
