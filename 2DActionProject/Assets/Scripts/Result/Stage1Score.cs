using UnityEngine;
using System.Collections;

public class Stage1Score : MonoBehaviour {

	private const int TimeDrop = 2 ;			// 減少値
	private const int Bonus = 5 ;				// ボーナス

	private int getPoint ;						// 獲得したポイント
	private int clearTime ;						// クリア時間
	public  int totalScore { get; private set; }// スコア

	void Awake()
	{
		// 値を取得
		getPoint = PlayerPrefs.GetInt("Stage1Point");
		clearTime = (int)PlayerPrefs.GetFloat ("Stage1Time");

		// スコアの計算
		totalScore = (getPoint - (clearTime * TimeDrop)) * Bonus;
	}

	void Update () {
		guiText.text = "Stage1Score " + totalScore;
	}
}
