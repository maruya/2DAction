using UnityEngine;
using System.Collections;

public class SelectIconMain : MonoBehaviour {

	private const float SPEED = 0.1f ;		// 移動速度 

	void Movement()
	{
		// TODO アニメージョンの再生と停止を追加する
		// 移動処理
		if (Input.GetKey(KeyCode.DownArrow)){
			transform.position = new Vector3( transform.position.x, transform.position.y - SPEED, transform.position.z);
			GetComponent<Animator> ().SetTrigger ("MoveDown");
		}

		if (Input.GetKey(KeyCode.UpArrow)){
			transform.position = new Vector3( transform.position.x, transform.position.y + SPEED, transform.position.z);
			GetComponent<Animator> ().SetTrigger ("MoveUp");
		}

		if (Input.GetKey(KeyCode.LeftArrow)){
			transform.position = new Vector3( transform.position.x - SPEED, transform.position.y, transform.position.z);
			GetComponent<Animator> ().SetTrigger ("MoveLeft");
		}

		if (Input.GetKey(KeyCode.RightArrow)){
			transform.position = new Vector3( transform.position.x + SPEED, transform.position.y, transform.position.z);
			GetComponent<Animator> ().SetTrigger ("MoveRight");
		}
	}

	void Start () {
	}

	void Update () {

		// キー入力があれば移動
		if (Input.anyKey) Movement ();
	}
}
