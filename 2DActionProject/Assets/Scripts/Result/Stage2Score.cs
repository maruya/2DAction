using UnityEngine;
using System.Collections;

public class Stage2Score : MonoBehaviour {

	private const int TimeDrop = 5 ;			// 減少値
	private const int TimeBonus = 10 ;			// ボーナス
	
	private int getPoint ;						// 獲得したポイント
	private int clearTime ;						// クリア時間
	public int totalScore { get; private set; }	// スコア

	void Awake()
	{
		// 値を取得
		getPoint = PlayerPrefs.GetInt("Stage2Point");
		clearTime = (int)PlayerPrefs.GetFloat ("Stage2Time");

		// スコアを計算
		totalScore = getPoint + (clearTime / TimeDrop) * TimeBonus;
	}
	
	void Update () {
		guiText.text = "Stage2Score " + totalScore;
	}
}
