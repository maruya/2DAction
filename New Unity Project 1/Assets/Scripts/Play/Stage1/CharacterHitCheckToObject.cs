using UnityEngine;
using System.Collections;

public class CharacterHitCheckToObject : MonoBehaviour {

	private int ObjectLayer ;		//	判定の対象となるレイヤー
	//private string[] tags;			// Unityに登録されているタグ

	void Start () {
	
		// レイヤーを対象のみに絞る
		ObjectLayer = 1 << LayerMask.NameToLayer ("Object");

#if false
		// タグのサイズ分だけ配列を確保する
		tags = tag.Length;

		var it = tag.GetEnumerator ();
		// 登録されているタグを追加する
		int counter = 0;
		while(it.MoveNext())
		{
			tags[counter] = it ;
			counter++;
		}
#endif
	}

	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		// 当たったレイヤーのタグを調べて対応したメソッドを呼び処理をする
	}
}
