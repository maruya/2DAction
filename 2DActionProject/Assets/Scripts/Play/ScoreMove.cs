using UnityEngine;
using System.Collections;

public class ScoreMove : MonoBehaviour {

	private const float UP_SPEED = 0.1f;			// 上昇速度
	private const float DELETE_TIME = 0.3f ;		// 消滅時間

	void Update () {
	
		// 上昇しながら時間で消滅
		transform.position = new Vector3 (transform.position.x, transform.position.y + UP_SPEED, transform.position.z);
		Destroy (gameObject, DELETE_TIME);
	}
}
