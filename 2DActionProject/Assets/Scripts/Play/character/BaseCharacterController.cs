using UnityEngine;
using System.Collections;

public class BaseCharacterController : MonoBehaviour {

	// ベースとなるキャラクタークラス
	public int hp ;				// 敵が持つヒットポイント
	public int power ;
	public float speed ;		// 速度
	public float jumpPower;		// ジャンプ力
	public int score ;			// スコア
	public bool isGroundTouch;	// 接地判定
	
	
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
