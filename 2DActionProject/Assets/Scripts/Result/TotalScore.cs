using UnityEngine;
using System.Collections;

public class TotalScore : MonoBehaviour {

	private int totalScore;		// 合計スコア
	private int prevTotalScore ;// 前回の合計		
	private int stage1;			// ステージ１スコア
	private int stage2;			// ステージ２スコア
	private bool isHighScore ;	// ハイスコアか判定

	void Start()
	{
		// 合計値を算出
		stage1 = GameObject.Find ("Stage1Score").GetComponent<Stage1Score> ().totalScore;
		stage2 = GameObject.Find ("Stage2Score").GetComponent<Stage2Score> ().totalScore;
		totalScore = stage1 + stage2;

		// ハイスコアか判定
		prevTotalScore = PlayerPrefs.GetInt ("TotalScore");
		isHighScore = (totalScore > prevTotalScore ? true : false);

		// 記録
		if (isHighScore) PlayerPrefs.SetInt ("TotalScore", totalScore);
	}
	
	void Update () {
	
		if (isHighScore) guiText.text = "TotalScore " + totalScore + " NEW";
		else guiText.text = "TotalScore " + totalScore;

	}
}
