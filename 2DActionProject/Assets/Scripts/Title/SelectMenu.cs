using UnityEngine;
using System.Collections;

public class SelectMenu : MonoBehaviour {
	
	void Start () {
	}

	void Update () {
	
	}

	void OnGUI()
	{
		// Start	or	Exit
		if(GUI.Button(new Rect(50,100,220,20), "Start")) Application.LoadLevel("StageSelect") ;
		if (GUI.Button (new Rect (50, 140, 220, 20), "Exit")) Application.Quit ();
	}

}