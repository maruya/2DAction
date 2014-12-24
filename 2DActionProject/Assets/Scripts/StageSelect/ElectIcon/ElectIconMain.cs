using UnityEngine;
using System.Collections;

public class ElectIconMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
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
