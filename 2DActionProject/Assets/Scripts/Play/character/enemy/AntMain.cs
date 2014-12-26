using UnityEngine;
using System.Collections;

public class AntMain : MonoBehaviour {

	private AntController controller ;

	void Start () {
	
		controller = GetComponent<AntController> ();
	}

	void Update () {
	
		controller.Work ();		// 敵の挙動から処理までを操作
	}
}
