using UnityEngine;
using System.Collections;

public class Stage2Clear : MonoBehaviour {
	

	void OnTriggerEnter2D(Collider2D collider2d)
	{
		if (collider2d.tag == "Player")
		{
			// スコアを記録
			int Stage2Point = GameObject.Find("player").GetComponent<BaseCharacterController>().score ;
			PlayerPrefs.SetInt("Stage2Point", Stage2Point) ;

			// クリア時間を記録
			float Stage2Time = GameObject.Find("GUITime").GetComponent<GuiTime>().timer;
			PlayerPrefs.SetFloat("Stage2Time", Stage2Time);
			PlayerPrefs.Save();

			// リザルトへ移動
			SceneChanger changer = GameObject.Find("SceneChange").GetComponent<SceneChanger>();
			changer.SetNextScene("Result") ;
		}
	}
}
