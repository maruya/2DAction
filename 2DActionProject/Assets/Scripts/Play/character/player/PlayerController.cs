using UnityEngine;
using System.Collections;

public class PlayerController : BaseCharacter{

	private bool isDirection ;				// キャラクターの向き
	private int OBJECT_LAYER ;				// 接地判定に使用する専用レイヤー
	private Transform playerLegLeft ;		// キャラクターの左足(接地判定に(使用)
	private Transform playerLegRight;		// キャラクターの右足(接地判定に(使用)
	private Vector3 prevPos ;				// 前回の座標
	private const float KNOCK_BACK = 2000f;	// ノックバック定数


	void Start () {
	
		// 一応なにか入れておく
		isDirection = false;

		// 接地レイやーの取得
		OBJECT_LAYER = 1 << LayerMask.NameToLayer ("Object");

		// 両足の情報を取得
		playerLegLeft = GameObject.Find ("playerLeftLeg").transform;
		playerLegRight = GameObject.Find ("playerRightLeg").transform;

		// 座標の初期化
		prevPos = transform.position;

	}

	void Update () {

	}

// 基本行動(ジャンプ・待機・歩く・向き)
//======================================
	private void DirectionChange()
	{
		// 左右どちらを向いてるか判断
		float left_or_right = Input.GetAxis ("Horizontal");

		// キャラクターの向きを設定
		if (left_or_right > 0 && ! isDirection || left_or_right < 0 && isDirection)
		{
			isDirection = (left_or_right > 0 ) ;
			float scaleX = Mathf.Abs(transform.localScale.x);
			transform.localScale = new Vector3( ( scaleX > 0 ? -scaleX : scaleX ), transform.localScale.y, transform.localScale.z ) ;
		}
	}
	
	public void AnimationWalk()
	{
		if( transform.position != prevPos && 
		   Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) )
		{
			GetComponent<Animator>().SetTrigger("Walk");
		}else
			GetComponent<Animator>().SetTrigger("Stay");
	}

	public void AnimationJump()
	{
		if (! isGroundTouch)
			GetComponent<Animator> ().SetBool ("jump", true);
		else
			GetComponent<Animator> ().SetBool ("Jump", false);
	}

// ダメージ
//========================================

	public void AnimationDamage()
	{
		Vector2 vec2 = new Vector2 ((transform.localScale.x > 0 ? -KNOCK_BACK : KNOCK_BACK), 0f);
		rigidbody2D.AddForce (vec2);
		GetComponent<Animator> ().SetTrigger ("Damage");
	}

// 攻撃各種
//=========================================
	public void AnimationNormalAttack()
	{
		if (isGroundTouch) 
		{
			GetComponent<Animator>().SetTrigger("NormalAttack");
		}
	}


	public void AnimationAirAttack()
	{
		if (!isGroundTouch) 
		{
			GetComponent<Animator>().SetTrigger("AirAttack");
		}
	}
}








