using UnityEngine;
using System.Collections;

public class Stage2Clear : MonoBehaviour {


	void Start () {
	
	}

	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider2d)
	{
		if (collider.tag == "palyer")
		{
			// スコアを記録
			int Stage2Score = GameObject.Find("player").GetComponent<BaseCharacterController>().score ;
			//PlayerPrefs.SetInt("Stage2Score", Stage2Score) ;

			// クリア時間を記録
			//float Stage2Time = GetComponent<PlayTime>().timer;
			//PlayerPrefs.SetFloat("Stage2Score", Stage2Score);
			//PlayerPrefs.Save();

			// リザルトへ移動
			SceneChanger changer = GameObject.Find("SceneChange").GetComponent<SceneChanger>();
			changer.SetNextScene("Result") ;
		}
	}
}
