﻿using UnityEngine;
using System.Collections;

public class AntMain : MonoBehaviour {

	private AntController controller ;	// コントローラー

	void Start () {
	
		controller = GetComponent<AntController> ();
	}

	void Update () {
	
		controller.Work ();		// 一連の処理をしてくれる
	}
}
