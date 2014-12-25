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
		if (collider2d.name == "player") 
		{
			// スコアを記録
			int Stage1Score = GameObject.Find("player").GetComponent<BaseCharacterController>().score;
			// PlayerPrefs.SetInt("Stage1Score", Stage1Score);

			// クリア時間を記録
			//float Stage1Time = GetComponent<PlayTime>().timer ;
			// PlayerPrefd.SetFloat("Stage1Time", Stage1Time);
			//PlayerPrefs.Save();

			// ステージ２へ移動
			SceneChanger changer = GameObject.Find("SceneChange").GetComponent<SceneChanger>();
			changer.SetNextScene("Stage2");
		}
	}
}
