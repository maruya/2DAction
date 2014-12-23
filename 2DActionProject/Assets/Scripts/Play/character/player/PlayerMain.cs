using UnityEngine;
using System.Collections;

public class PlayerMain : MonoBehaviour {

	private PlayerController controller ;		// プレイヤーのコントローラー

	void Start () {

        controller = GetComponent<PlayerController>();
	}

	void Update () {

        controller.EarlyUpdate();       // コントローラー内で行う内部的な処理
        controller.AnimationCommon();   // ジャンプ、移動の基本的な操作ができるようになる関数

        if (Input.GetKeyDown(KeyCode.Z)) controller.AnimationAttackManager();  // プレイヤーの状態に合わせた攻撃

	}
}
