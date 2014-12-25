using UnityEngine;
using System.Collections;
using System.Collections.Generic ;

public class SelectMove : MonoBehaviour {
	
	// ToDo
	//==============
	private GameObject Icon ;
	private List<GameObject> StageList = new List<GameObject>() ; 
	private GameObject Stage1 ;
	private GameObject Stage2 ;
	private GameObject Stage3 ;
	//==============


	void CreateStageInfoList()
	{
		// CreateStageInfo
		Stage1 = GameObject.Find ("Stage1");
		StageList.Add (Stage1);

		Stage2 = GameObject.Find ("Stage2");
		StageList.Add (Stage2);

		Stage3 = GameObject.Find ("Stage3");
		StageList.Add (Stage3);
	}

	void Start () {
	
		CreateStageInfoList ();

	}

	void Update () {
	
	}
}
