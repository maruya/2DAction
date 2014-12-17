using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	private const float CameraPosZ = -10f;		// カメラのZ座標の固定値

	void Start () {
	
	}

	void Update () {

		// カメラをキャプチャ
		GameObject main_camera = GameObject.Find ("Main Camera");

		// プレイヤーを追従
		main_camera.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, CameraPosZ);
	}
}
