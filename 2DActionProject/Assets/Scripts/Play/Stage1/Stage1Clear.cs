using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class Stage1Clear : MonoBehaviour {
	

	void Start()
	{
	}


	void Update()
	{
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		// 対応したオブジェクトに当たるとリザルトへ移行
		if (col.gameObject.name == "player")
			Application.LoadLevel ("Result");
	}
}
