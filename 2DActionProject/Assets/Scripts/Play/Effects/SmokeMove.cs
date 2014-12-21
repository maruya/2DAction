using UnityEngine;
using System.Collections;

public class SmokeMove : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {

        // アクティブにして、指定時間に削除
        gameObject.SetActive(true);
        Destroy(gameObject, 0.3f);
	
	}
}
