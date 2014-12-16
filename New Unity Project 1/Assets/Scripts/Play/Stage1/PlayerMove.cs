using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	private float speed = 0f ;			// 実際に代入する速度
	private const float Speed = 2.0f ;	// プレイヤーは固定の速度で移動する
	private bool IsRight = true ;		// キャラクターの向きを判断するフラグ

	void Start () {
	
	}

	void Update () {

		// 移動の方向に速度を代入
		if (Input.GetKey ("left")) speed = -Speed;
		else if (Input.GetKey ("right"))speed = Speed;
		else speed = 0f;
	
	}

	void FixedUpdate()
	{
		// 速度を制限
		float h = Input.GetAxis ("Horizontal");
		rigidbody2D.velocity = new Vector2 (speed, this.rigidbody2D.velocity.y);

		// キャラクターの向きを制御
		if (h > 0 && ! this.IsRight || h < 0 && this.IsRight) 
		{
			this.IsRight = (h > 0) ;
			float scale = Mathf.Abs(this.transform.localScale.x) ;
			this.transform.localScale = new Vector3(( this.IsRight ? scale : -scale ), this.transform.localScale.y, this.transform.localScale.z) ;
		}

	}
}
