using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BardMove : MonoBehaviour {
	


	private  float speed = 1.0f;									// 移動力
	private const float WAVE_SIZE = 2.0f;							// 揺れる幅
	private int directionCounter = 0;								// 方向変換までのカウンター
	private  int directionintetval = 0;								// 変更までの数値,乱数で決める
	private Vector2 WAVE_POINT ;									// 波の開始地点を持つvector2
	private Vector2 INTERVAL_TIME ;									// インターバルまでの数値
	private float wavePoint ;										// 波の開始地点
	private CharacterStatus status ;								// 自身のステータス

	public CharacterStatus GetStatus(){return status;}

	
	void Start()
	{
		// ステータスを取得
		status = gameObject.GetComponent<CharacterStatus> ();		// ステータスを取得
		
		// インターバルと波のポイントを決める
		INTERVAL_TIME = new Vector2 (120, 180);
		WAVE_POINT = new Vector2 (0f, 5f);

		// 向き変更までの時間を決定する
		directionintetval = Random.Range ((int)INTERVAL_TIME.x, (int)INTERVAL_TIME.y);

		// 波の開始地点を決定
		wavePoint = Random.Range (WAVE_POINT.x, WAVE_POINT.y);
	}

    void Update()
    {
        // 一連の処理
        Work();
    }


	void IntervalUpdate()
	{
		// 時間になったら向きの変更とカウンターのリセット
		directionCounter++;
		if( directionintetval < this.directionCounter )
		{
			speed *= -1;
			directionCounter = 0 ;
		}
	}

	float Wave()
	{
		float point = Time.time + wavePoint;	// 開始地点
		float wave = (Mathf.Sin (point * WAVE_SIZE) * Mathf.Deg2Rad) ;
		return wave;
	}

	void CreateDrawScore()
	{
		string drawScore = status.Score.ToString();
		float addX = 0;								// スコアの重なりを防止

		// スコアをプレハブから生成
		foreach (var score in drawScore) 
		{
			string serif = "Prefabs/ScoreNumbers/" + score ;
			Vector3 pos = new Vector3(transform.position.x + addX, transform.position.y, transform.position.z);
			Instantiate(Resources.Load(serif), pos, this.transform.rotation);
			addX += 0.5f ;
		}

	}

	void Die()
	{
		if (status.HP <= 0)
        {
            // 死亡エフェクトをプレハブから生成
            Instantiate(Resources.Load("Prefabs/Smoke"), transform.position, transform.rotation);

			// 自身の持つスコアを生成
			CreateDrawScore();

			// プレイヤーにスコアを渡す
            PlayerMove player = GameObject.Find("player").GetComponent<PlayerMove>();
            player.GetStatus().Score += status.Score;
            Destroy(gameObject);
        }
	}

	public void Work () 
	{
		// 死亡チェック
		Die ();

		// 敵の挙動
		this.transform.position += (new Vector3 (0f, Wave(), 0f)); 

		// 速度を向きを調整する
		IntervalUpdate ();
		rigidbody2D.velocity = new Vector2 (speed, this.rigidbody2D.velocity.y);
		float scale = Mathf.Abs(this.transform.localScale.x) ;
		this.transform.localScale = new Vector3(( speed > 0f ? scale : -scale ), this.transform.localScale.y, this.transform.localScale.z) ;
	}

	public void OnTriggerEnter2D(Collider2D collider)
	{
		// ToDO=============
		// プレイヤーに当たった場合HPを0にする
		if ( collider.tag== "NormalAttack") 
		{
			status.HP = 0 ;
		}
	}
}






