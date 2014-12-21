using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IconMove : MonoBehaviour {

	// ステージ情報を持つ構造体
	struct StageInfo
	{
		public string name ;	// ステージ名(このstringをLoadLevelの引数に渡す)
		public Vector3 pos ;	// 座標
		public float r ;		// 判定に必要な半径
		// コンストラクタ
		public StageInfo(string Name, Vector3 Pos, float R)
		{
			name = Name ;
			pos = Pos ;
			r = R ;
		}
	}

	private const float SPEED = 0.1f;									// 速度は固定値
	private const float CIRCLE = 0.105f;								// 半径
	private string sceneName = "";										// シーン名の入れ物
	private List<StageInfo> StageInfoList = new List<StageInfo>();		// ステージ情報のコンテナ

	
	void CreateStageInfo()
	{
		// 各ステージ情報をセット
		StageInfoList.Add (new StageInfo ("Stage1", new Vector3 (0f, 4.0f, 0), 0.105f));
		StageInfoList.Add (new StageInfo ("Stage2", new Vector3 (0f, 0f, 0), 0.105f));
		StageInfoList.Add (new StageInfo ("Stage3", new Vector3 (0f, -4.0f, 0), 0.105f));

	}

	void CollisionSphere2D()
	{
		foreach(var stage in StageInfoList)
		{
			// ステージアイコンとの判定
			if( Mathf.Sqrt(((this.transform.position.x - stage.pos.x)*(this.transform.position.x - stage.pos.x) +
			                (this.transform.position.y - stage.pos.y)*(this.transform.position.y - stage.pos.y))) < (CIRCLE + stage.r))
			{
				// スペーズを押したらシーン名をキャプチャしてシーンへ移動
				if(Input.GetButtonDown("jump"))
				{
					sceneName = stage.name ;
					Application.LoadLevel(sceneName) ;
				}
			}
		}
	}

	void Start()
	{
		// ステージ情報の初期化
		CreateStageInfo ();
	}


	void Update () {

		// 移動
		if (Input.GetKey ("left")) transform.Translate (Vector3.left * SPEED);
        if (Input.GetKey("right")) transform.Translate(Vector3.right * SPEED);
        if (Input.GetKey("up")) transform.Translate(Vector3.up * SPEED);
        if (Input.GetKey("down")) transform.Translate(Vector3.down * SPEED);

		// 選択ステージの判定
		CollisionSphere2D ();
	}
	


}
