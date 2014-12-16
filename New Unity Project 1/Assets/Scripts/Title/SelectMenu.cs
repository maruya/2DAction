using UnityEngine;
using System.Collections;

public class SelectMenu : MonoBehaviour {
	
	void Start () {
		Debug.Log ("test");
	}

	void Update () {
	
	}

	void OnGUI()
	{
		// Start	or	Exit
		if(GUI.Button(new Rect(120,180,200,20), "Start")) Application.LoadLevel("StageSelect") ;
		if (GUI.Button (new Rect (120, 220, 200, 20), "Exit")) Application.Quit ();
	}

}