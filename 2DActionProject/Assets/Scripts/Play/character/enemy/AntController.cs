using UnityEngine;
using System.Collections;

public class AntController : BaseCharacterController {

	private const int POWER = 10 ;							// 攻撃力
	private const float SPEED = 1.5f ;						// 速度
	private Vector2 MOVEMENT_TIME = new Vector2( 1f,3f ) ;	// 移動時間
	private float nextMovementTime ;						// 次の移動時間
	private float intervalTime ;							// インターバル
	private bool isWalkAnimation ;							// 歩いてるか判断 


	protected override void Awake()
	{
		// 初期化
		power = POWER;
		speed = SPEED;

		// 移動する時間を決定
		nextMovementTime = Random.Range (MOVEMENT_TIME.x, MOVEMENT_TIME.y);

		// 初期化
		intervalTime = Time.time;
		isWalkAnimation = false;
	}


	private bool CheckAnimation()
	{
		// アニメーション名がWalkであればtrue
		Animator animator = GetComponent<Animator> ();
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo (0);

		if (stateInfo.IsName("Walk") ) return true;
		else return false;
	}


	private void UpdateDirection()
	{
		// 時間差
		float gap = Mathf.Abs (intervalTime - Time.time);

		if (gap >= nextMovementTime) 
		{
			// 次回のインターバルと移動方向の更新
			nextMovementTime = Random.Range(MOVEMENT_TIME.x, MOVEMENT_TIME.y);
			intervalTime = Time.time;
			speed = (speed > 0 ? -SPEED : SPEED) ;

			// Spriteの向きの更新
			float scaleX = Mathf.Abs(transform.localScale.x);
			transform.localScale = new Vector3( ( speed > 0 ? scaleX : -scaleX ), transform.localScale.y, transform.localScale.z );
		}
	}


	private void CreateDrawScore()
	{
		string drawScore = score.ToString();
		float addX = 0;								// スコアの重なりを防止
		
		// スコアをプレハブから生成
		foreach (var _score in drawScore) 
		{
			string serif = "Prefabs/ScoreNumbers/" + _score ;
			Vector3 pos = new Vector3(transform.position.x + addX, transform.position.y, transform.position.z);
			Instantiate(Resources.Load(serif), pos, this.transform.rotation);
			addX += 0.5f ;
		}
		
	}


	private void Die()
	{
		if (hp <= 0)
		{
			// 死亡エフェクトをプレハブから生成
			Instantiate(Resources.Load("Prefabs/Smoke"), transform.position, transform.rotation);
			
			// 自身の持つスコアを生成
			CreateDrawScore();
			
			// プレイヤーにスコアを渡して消滅
			GameObject.Find("player").GetComponent<BaseCharacterController>().score += score ;
			Destroy(gameObject);
		}
	}


	private void Movement()
	{
		// 向き,移動方向の更新
		UpdateDirection ();

		// 速度の加算
		rigidbody2D.velocity = new Vector2 (speed, 0f);
	}


	public void Work()
	{
		// 死亡チェック
		Die ();

		// 現在のアニメーションをチェック
		isWalkAnimation = CheckAnimation ();

		if (isWalkAnimation) Movement ();
	}


	void OnTriggerEnter2D( Collider2D collider2d )
	{
		if (collider2d.tag == "PlayerAttack")  hp -= 1;
	}
}






