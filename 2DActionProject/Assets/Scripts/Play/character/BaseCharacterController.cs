using UnityEngine;
using System.Collections;

public class BaseCharacterController : MonoBehaviour {

	// ベースとなるキャラクタークラス
	public int hp 				{ get ;set; }// 敵が持つヒットポイント
	public int power			{ get ;set; }// 攻撃力
	public float speed			{ get ;set; }// 速度
	public float jumpPower		{ get ;set; }// ジャンプ力
	public int score			{ get ;set; }// スコア
	public bool isGroundTouch	{ get ;set; }// 接地判定
	
	
	protected virtual void Awake()
	{
		hp = 0;
		power = 0;
		speed = 0;
		jumpPower = 0;
		score = 0;
		isGroundTouch = false;
	}
	
	protected virtual void Start () {
		
	}
	
	protected virtual void Update () {
		
	}
	
	protected virtual void FixedUpdate()
	{
	}

}
