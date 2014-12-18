using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	private float speed = 0f ;					// 実際に代入する速度
	private const float Speed = 2.0f ;			// プレイヤーは固定の速度で移動する
	private bool IsRightDirection = true ;		// キャラクターの向きを判断するフラグ
	private const float JumpPower = 250f;		// ジャンプ力
	private int Object ;						// 接地判定に使用するレイヤー
	private Transform playerLeg ;				// 接地判定に使用するプレイヤーの脚
	private Vector3 prevPos ;					// フレーム前の座標
	private PlayerAnimation Playeranimation ;	// プレイヤのアニメーション
	private bool IsLegTouch = false ;			// 攻撃中であるかのフラグ


	void Start () {

		this.Object = 1 << LayerMask.NameToLayer ("Object");
		playerLeg = transform.Find ("playerLeg");
		prevPos = this.transform.position;
		Playeranimation = gameObject.GetComponent<PlayerAnimation> ();		// アニメーションScriptを取得
	}

	void Update () {

		// 現在のロコモーターのタグを調べ、移動できるか判断
		Animator anim = GetComponent<Animator> ();
		AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo (0);
		if (state.IsTag ("BaseMotion")) 
		{
			// 移動の方向に速度を代入
			if (Input.GetKey ("left"))
				speed = -Speed;
			else if (Input.GetKey ("right"))
				speed = Speed;
			else
				speed = 0f;
		}

		// 接地判定の更新
		IsLegTouch = LegTouchToObject ();
	}

	bool LegTouchToObject()
	{
		if (Physics2D.Linecast (this.transform.position, this.playerLeg.position, this.Object)) return true;
		else return false ;
	}


	void AnimationMove()
	{
		// 移動or待機
		Playeranimation.WalkOrStayAnimation (this.transform.position, this.prevPos);
		// 向きの変更
		//Playeranimation.DirectionChange (IsRightDirection, this.transform.localScale);
		// ジャンプ処理
		Playeranimation.Jump (this.IsLegTouch);
		// 現在のsprite画像のnameを受け取る
		SpriteRenderer sp = GetComponent<SpriteRenderer> ();
		// 通常攻撃1
		Playeranimation.NormalAttack1 (this.IsLegTouch, sp.sprite.name);
	}

	void FixedUpdate()
	{
		if (IsLegTouch) 
		{
			if( Input.GetButtonDown("jump") ) rigidbody2D.AddForce( new Vector2(0f,JumpPower) );
		}

		// 速度を制限
		float h = Input.GetAxis ("Horizontal");
		rigidbody2D.velocity = new Vector2 (speed, this.rigidbody2D.velocity.y);

		// キャラクターの向きを制御
		if (h > 0f && ! this.IsRightDirection || h < 0f && this.IsRightDirection) 
		{
			this.IsRightDirection = (h > 0f) ;
			float scale = Mathf.Abs(this.transform.localScale.x) ;
			this.transform.localScale = new Vector3(( this.IsRightDirection ? -scale : scale ), this.transform.localScale.y, this.transform.localScale.z) ;
		}

		// アニメーションを実行
		AnimationMove ();
	}
}
