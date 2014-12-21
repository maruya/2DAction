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
		// リザルトへ移行
		if (col.gameObject.name == "player")
			Application.LoadLevel ("Result");
	}
}
