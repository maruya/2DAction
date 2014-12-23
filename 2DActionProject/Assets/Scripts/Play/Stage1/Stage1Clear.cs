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

	void OnTriggerEnter2D(Collider2D collider2d)
	{
		// 対応したオブジェクトに当たるとリザルトへ移行
		if (collider2d.name == "player")
			Application.LoadLevel ("Result");
	}
}
