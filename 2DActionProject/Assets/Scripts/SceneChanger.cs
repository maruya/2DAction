using UnityEngine;
using System.Collections;

// シーン切り替え時に使用するクラス
public class SceneChanger : MonoBehaviour {
	
	private Vector3 startPoint ;			// 待機座標
	private Vector3 endPoint ;				// 終了座標
	private Vector3 targetPoint ;			// ターゲット座標
	private string targetScene ;			// 現在のシーン
	private string prevScene ;				// 前のシーン
	private const float CHANGE_SPEED = 1f;	// 切り替え速度
	enum ChangeCase{ BEFORE, SCENE_CHANGE, AFTER, EMPTY }
	private ChangeCase enumCase ;			// switchで使用するenum型の変数
	private const float GAP = 25f;			// 画像と座標の差
	private float currentGap ;				// 現在のギャップ

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
		currentGap = GAP ;

	}

	public void SetNextScene(string nextScene)
	{
		// ギャップを再設定
		currentGap = GAP;

		// シーンのセット
		targetScene = nextScene;
		enumCase = ChangeCase.BEFORE;

		// カメラの座標をキャプチャし設定
		Transform cameraTransform = GameObject.Find ("Main Camera").transform;
		startPoint = new Vector3 (cameraTransform.position.x + currentGap, cameraTransform.position.y, 0f);
		targetPoint = cameraTransform.position;
		endPoint = new Vector3 (cameraTransform.position.x - currentGap, cameraTransform.position.y, 0f);

		// 自身の座標を設定
		transform.position = startPoint;

		// rendererをオン
		renderer.enabled = true;
	}


	private void ReRightPostion()
	{
		// カメラの座標をキャプチャし再設定
		Transform cameraTransform = GameObject.Find ("Main Camera").transform;
		transform.position = new Vector3 (cameraTransform.position.x + currentGap, cameraTransform.position.y, 0f);
		targetPoint = cameraTransform.position;
		endPoint = new Vector3 (cameraTransform.position.x - GAP, cameraTransform.position.y, 0f);

		// ギャップの差を縮める
		currentGap -= CHANGE_SPEED;
	}



	private void SceneChange()
	{
		// シーン移動処理
		switch (enumCase) {
		case ChangeCase.BEFORE:
			if (targetPoint.x <= transform.position.x) {
				ReRightPostion ();
			} else
				enumCase = ChangeCase.SCENE_CHANGE;
			break;

		case ChangeCase.SCENE_CHANGE:
			Application.LoadLevel (targetScene);
			enumCase = ChangeCase.AFTER;
			break;

		case ChangeCase.AFTER:
			if (endPoint.x <= transform.position.x) {
				ReRightPostion ();
			} else
			{
				enumCase = ChangeCase.EMPTY;
				prevScene = targetScene ;
				renderer.enabled = false ;
			}
			break;
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



