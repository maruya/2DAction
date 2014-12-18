using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	private float speed = 0f ;				// 実際に代入する速度
	private const float Speed = 2.0f ;		// プレイヤーは固定の速度で移動する
	private bool IsRight = true ;			// キャラクターの向きを判断するフラグ
	private const float JumpPower = 250f;	// ジャンプ力
	private int Ground ;					// 接地判定に使用するレイヤー
	private Transform playerLeg ;			// 接地判定に使用するプレイヤーの脚
	private Vector3 prevPos ;				// フレーム前の座標
	private PlayerAnimation animation ;		// プレイヤのアニメーション

	void Start () {

		Ground = 1 << LayerMask.NameToLayer ("Ground");
		playerLeg = transform.Find ("playerLeg");
		prevPos = this.transform.position;
		animation = gameObject.GetComponent<PlayerAnimation> ();		// アニメーションScriptを取得
	}

	void Update () {

		// 移動の方向に速度を代入
		if (Input.GetKey ("left")) speed = -Speed;
		else if (Input.GetKey ("right"))speed = Speed;
		else speed = 0f;
	
	}

	void FixedUpdate()
	{
		if (Physics2D.Linecast (this.transform.position, playerLeg.position, Ground)) 
		{
			if( Input.GetButtonDown("jump") ) rigidbody2D.AddForce( new Vector2(0f,JumpPower) );
		}

		// 速度を制限
		float h = Input.GetAxis ("Horizontal");
		rigidbody2D.velocity = new Vector2 (speed, this.rigidbody2D.velocity.y);


		// キャラクターの向きを制御
		if (h > 0 && ! this.IsRight || h < 0 && this.IsRight) 
		{
			this.IsRight = (h > 0) ;
			float scale = Mathf.Abs(this.transform.localScale.x) ;
			this.transform.localScale = new Vector3(( this.IsRight ? -scale : scale ), this.transform.localScale.y, this.transform.localScale.z) ;
		}

		// スクリプトを参照してのメソッドテスト
		//animation.DirectionChange (IsRight, this.transform.localScale);
		animation.WalkOrStayAnimation (this.transform.position, this.prevPos);

	}
}
