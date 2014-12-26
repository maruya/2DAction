using UnityEngine;
using System.Collections;

public class Stage1Clear : MonoBehaviour {
	
	
	void OnTriggerEnter2D(Collider2D collider2d)
	{
		if (collider2d.name == "player") 
		{
			// スコアを記録
			int Stage1Point = GameObject.Find("player").GetComponent<BaseCharacterController>().score;
			PlayerPrefs.SetInt("Stage1Point", Stage1Point);

			// クリア時間を記録
			float Stage1Time = GameObject.Find ("GUITime").GetComponent<GuiTime>().timer;
			PlayerPrefs.SetFloat("Stage1Time", Stage1Time);
			PlayerPrefs.Save();

			// ステージ２へ移動
			SceneChanger changer = GameObject.Find("SceneChange").GetComponent<SceneChanger>();
			changer.SetNextScene("Stage2");
		}
	}
}
