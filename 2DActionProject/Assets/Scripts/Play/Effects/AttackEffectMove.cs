using UnityEngine;
using System.Collections;

public class AttackEffectMove : MonoBehaviour {

	private float direction = 0;			// 向き
	private const float SPEED = 0.1f;		// 速度		

	void Awake()
	{
	}

	void Start () {
	
		// 進む方向
		Transform player = GameObject.Find ("player").transform;
		transform.position = player.transform.position;
		direction = (player.transform.localScale.x > 0 ? -SPEED : SPEED);

		// 向き
		float scaleX = Mathf.Abs (transform.localScale.x);
		transform.localScale = new Vector3 ((direction > 0 ? -scaleX : scaleX), transform.localScale.y, transform.localScale.z);

		// 削除の予約
		Destroy (gameObject, 0.5f);
	}

	void Update () {
		transform.position = new Vector3 (transform.position.x + direction, transform.position.y, transform.position.z);
	}

	void OnTriggerEnter2D(Collider2D collider2d)
	{
		if (collider2d.tag == "Enemy")
		Destroy (gameObject);
	}
}
