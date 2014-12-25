using UnityEngine;
using System.Collections;

public class SelectMenu : MonoBehaviour {
	
	void Start () {

		DontDestroyOnLoad (this.gameObject);
	}

	void Update () {
	
	}

	void OnGUI()
	{
		//HACK インターンのPCと自身のノートPCで座標が変化してしまう
		// Start	or	Exit
		// インターンPC用の座標
		if(GUI.Button(new Rect(150,200,220,20), "Start")) Application.LoadLevel("StageSelect") ;
		if (GUI.Button (new Rect (150, 240, 220, 20), "Exit")) Application.Quit ();
		// 自身のノートPC用の座標
		//if(GUI.Button(new Rect(150,100,220,20), "Start")) Application.LoadLevel("StageSelect") ;
		//if (GUI.Button (new Rect (150, 240, 220, 20), "Exit")) Application.Quit ();
	}

}