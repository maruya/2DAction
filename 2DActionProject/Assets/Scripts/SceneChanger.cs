using UnityEngine;
using System.Collections;

// シーン切り替え時に使用するクラス
public class SceneChanger : MonoBehaviour {

	// private GameObject changeImage ;		// イメージ画像
	private Vector3 startPoint ;			// 待機座標
	private Vector3 endPoint ;				// 終了座標
	private Vector3 targetPoint ;			// ターゲット座標
	private string targetScene ;			// 現在のシーン
	private string prevScene ;				// 前のシーン
	private const float CHANGE_SPEED = 1f;	// 切り替え速度
	enum ChangeCase{ BEFORE, SCENE_CHANGE, AFTER, EMPTY }
	private ChangeCase enumCase ;			// switchで使用するenum型の変数
	private const float GAPPOS = 25f;		// 画像と座標の差

	void Start () {

		// アプリケーションの終了まで使用する
		DontDestroyOnLoad (this);

		// 初期化
		targetScene = "";
		prevScene = "";
		startPoint = Vector3.zero;
		endPoint = Vector3.zero;
		targetPoint = Vector3.zero;
		renderer.enabled = false;		// シーン切り替え時のみtrue

	}

	public void SetNextScene(string nextScene)
	{
		// シーンのセット
		targetScene = nextScene;
		enumCase = ChangeCase.BEFORE;

		// カメラの座標をキャプチャし設定
		Transform cameraTransform = GameObject.Find ("Main Camera").transform;
		startPoint = new Vector3 (cameraTransform.position.x + GAPPOS, cameraTransform.position.y, 0f);
		targetPoint = cameraTransform.position;
		endPoint = new Vector3 (cameraTransform.position.x - GAPPOS, cameraTransform.position.y, 0f);

		// 自身の座標を設定
		transform.position = startPoint;

		// rendererをオン
		renderer.enabled = true;
	}

	private void SceneChange()
	{
		// 切り替えまでの一連の処理
		switch (enumCase)
		{
		case ChangeCase.BEFORE :
			if (targetPoint.x <= transform.position.x)
			{
				transform.position = new Vector3 (transform.position.x - CHANGE_SPEED, transform.position.y, transform.position.z);
			}else
				enumCase = ChangeCase.SCENE_CHANGE ;
			break ;

		case ChangeCase.SCENE_CHANGE :
			Application.LoadLevel(targetScene);
			enumCase = ChangeCase.AFTER ;
			break ;

		case ChangeCase.AFTER :
			if( endPoint.x <= transform.position.x )
			{
				transform.position = new Vector3 (transform.position.x - CHANGE_SPEED, transform.position.y, transform.position.z);
			}else
			{
				enumCase = ChangeCase.EMPTY;
				prevScene = targetScene ;
				renderer.enabled = false ;
			}
			break ;
		}
	}

	private bool CheckChangeScene()
	{
		if (targetScene != prevScene) return true;
		else return false;
	}

	void Update () {

		// シーン切り替えが必要か判定
		bool isChange = CheckChangeScene ();
		if (isChange) SceneChange ();
	
	}
}



