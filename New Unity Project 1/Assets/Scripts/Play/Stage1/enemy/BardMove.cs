using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BardMove : MonoBehaviour {
	


	private  float speed = 1.0f;									// 移動力
	private const float WaveSpeed = 60.0f;							// 揺れる速度
	private int directionCounter = 0;								// 方向変換までのカウンター
	private const int directionintetval = 120;						// 変更までの定数
	
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

	void Update () 
	{
		// 敵の挙動
		this.transform.position = (new Vector3 (this.transform.position.x, 
		                                        Mathf.Sin ((Time.time * WaveSpeed) * Mathf.Deg2Rad), 
		                                            this.transform.position.z)); 

		// 速度を向きを調整する
		IntervalUpdate ();
		rigidbody2D.velocity = new Vector2 (speed, this.rigidbody2D.velocity.y);
		float scale = Mathf.Abs(this.transform.localScale.x) ;
		this.transform.localScale = new Vector3(( speed > 0f ? scale : -scale ), this.transform.localScale.y, this.transform.localScale.z) ;
	}
}






