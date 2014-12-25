using UnityEngine;
using System.Collections;

public class ElectIconMain : MonoBehaviour {
	
	void Start () {
	
	}

	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D collider2d)
	{
		// アイコンが範囲内であればステージの詳細を描画する
		if (collider2d.tag == "SelectIcon") 
		{
			Debug.Log("Hit") ;
			foreach( Transform info in transform )
			{

				var tmp = info.GetComponent<ElectIconInformation>();
				tmp.DrawInfo();
			}
		}
	}
}
