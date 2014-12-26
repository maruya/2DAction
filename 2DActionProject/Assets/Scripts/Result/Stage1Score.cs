using UnityEngine;
using System.Collections;

public class Stage1Score : MonoBehaviour {

	private const int TimeDrop = 5 ;			// 減少値
	private const int TimeBonus = 10 ;			// ボーナス

	private int getPoint ;						// 獲得したポイント
	private int clearTime ;						// クリア時間
	public int totalScore { get; private set; }	// スコア

	void Awake()
	{
		// 値を取得
		getPoint = PlayerPrefs.GetInt("Stage1Point");
		clearTime = (int)PlayerPrefs.GetFloat ("Stage1Time");

		// スコアの計算
		totalScore = getPoint + (clearTime / TimeDrop) * TimeBonus;
	}

	void Update () {
		guiText.text = "Stage1Score " + totalScore;
	}
}
