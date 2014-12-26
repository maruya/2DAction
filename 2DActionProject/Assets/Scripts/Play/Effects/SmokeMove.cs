using UnityEngine;
using System.Collections;

public class SmokeMove : MonoBehaviour {

	void Update () {

        Destroy(gameObject, 0.3f);
	}
}
