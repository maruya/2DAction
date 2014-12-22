using UnityEngine;
using System.Collections;

public class Stage1Manager : MonoBehaviour {

	private  const float WAIT_TIME = 3f;	// ゲーム開始までの待機時間


	void Start () {

		// TODO 一時停止の処理をどうするか考えておく
	}

	IEnumerator Setup()
	{
		yield return new WaitForSeconds(1.0f) ;
		Time.timeScale = 0;
	}

	void Update () {

		//StartCoroutine (Setup ());

	}
}
