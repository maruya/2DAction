using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Score : MonoBehaviour {

	// ScoreTextures
	// ==============
	public GameObject score0 ;
	public GameObject score1 ;
	public GameObject score2 ;
	public GameObject score3 ;
	public GameObject score4 ;
	public GameObject score5 ;
	public GameObject score6 ;
	public GameObject score7 ;
	public GameObject score8 ;
	public GameObject score9 ;
	// ==============
	
	private Dictionary<char,GameObject> scoreDictionary = new Dictionary<char, GameObject>() ;
	private List<GameObject> DrawList = new List<GameObject>() ;		// 描画するリスト

	void Start()
	{
		CreateScore ();
	}

	void CreateScore()
	{
		// リストに基盤を入れる
		scoreDictionary.Add ('0', score0);
		scoreDictionary.Add ('1', score1);
		scoreDictionary.Add ('2', score2);
		scoreDictionary.Add ('3', score3);
		scoreDictionary.Add ('4', score4);
		scoreDictionary.Add ('5', score5);
		scoreDictionary.Add ('6', score6);
		scoreDictionary.Add ('7', score7);
		scoreDictionary.Add ('8', score8);
		scoreDictionary.Add ('9', score9);
	}

	GameObject SelectScore(char num)
	{
		foreach (var score in scoreDictionary) 
		{
			// 一致したら対応したオブジェクトをreturn
			if( score.Key == num )
				return score.Value;
			Debug.Log (score.Value.name);
		}

		// 例外
		// TODO=====なにか別の画像を用意する
		GameObject obj = score0;
		return obj;
	}

	void DrawScore( int score )
	{
		// 文字列に変換する
		string strScore = score.ToString ();

		for (int i = 0; i <= strScore.Length; i++) 
		{
			// 上の桁から取得して,リストに代入
			char Num = strScore[i] ;
			GameObject obj = SelectScore(Num) ;
			DrawList.Add(obj);
		}

		// ここまで通らない?
		Debug.Log (1);

		float addX =0f;
		// リストに詰まった分を描画する
		foreach (var list in DrawList) 
		{
			Instantiate( list, new Vector3(addX,0f,0f), list.transform.rotation);
			addX += 0.5f;
		}
	}

	void CrearScore()
	{
		// リストの中身を空にする
		DrawList.Clear ();
	}

	void Update()
	{
		// リストを整理
		CrearScore ();
		// test
		DrawScore (12345);
	}

}








