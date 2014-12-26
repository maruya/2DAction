using UnityEngine;
using System.Collections;

public class AntsNestMove : MonoBehaviour {

	public GameObject origianlAnt ;					// 蟻のデータ
	private Vector2 AntSize = new Vector2(1f,1.5f);	// 敵の体格を決める範囲
	private const int MAX_ANTS = 2 ;				// 巣から生成される最大数(親の子ノードに座標Objが１つあるため,関数内部の処理でこの値に+1している)
	private const float INTERVAL_TIME = 5f;			// 再出現までのインターバル
	private float prevTime ;						// 前回生成を行った時間
	private bool isObjectNestEixt ;					// 出口にオブジェクトがあるか判定


	void Start () {
	
		// 初期化
		prevTime = Time.time;
		isObjectNestEixt = false;
	}


	void CreateAnt()
	{
		// オリジナルからデータを取得し子ノードに設定
		GameObject ant = Instantiate (origianlAnt) as GameObject;
		ant.transform.parent = transform;
		
		// 座標とサイズを設定
		ant.transform.position = transform.Find ("EnemyStartPos").position;
		float enemySize = Random.Range(AntSize.x,AntSize.y);
		ant.transform.localScale = new Vector3 (enemySize, enemySize, enemySize);

	}


	void UpdatePrevTime(){prevTime = Time.time;}


	void CreateCheckAnts()
	{
		if (isObjectNestEixt) return;

		// + 1はMAX_ANTSのコメントを参照
		int num = transform.childCount;
		if (num >= MAX_ANTS + 1) return;
		else 
		{
			// インターバルを過ぎていれば生成する
			float gap = Mathf.Abs( prevTime - Time.time ) ;
			if( gap >= INTERVAL_TIME )
			{
				CreateAnt();
				UpdatePrevTime();
			}
		}
	}


	void Update () {
		CreateCheckAnts ();		// 生成するか判断して動く関数
	}


	void OnTriggerEnter2D(Collider2D collider2d)
	{
		// 出口にオブジェクトがあるか判定
		if (collider2d.transform.tag == "Object") isObjectNestEixt = true;
	}

	void OnTriggerExit2D(Collider2D collider2d)
	{
		// 出口にオブジェクトがあるか判定
		if (collider2d.transform.tag == "Object") isObjectNestEixt = false;
	}
}














