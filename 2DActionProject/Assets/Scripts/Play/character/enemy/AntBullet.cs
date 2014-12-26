using UnityEngine;
using System.Collections;

public class AntBullet : MonoBehaviour {

	private const int DAMAGE = 20;			// 攻撃力
	private const float SPEED = 2.5f;		// 弾速定数
	private const float LIFE_SPAN = 5f;		// 弾の寿命
	private float speed ;					// 弾速

	void Start () {

		SetDirection ();
	}


	void SetDirection()
	{
		// 親から進む方向を取得する
		float scaleX = transform.parent.transform.localScale.x;
		speed = (scaleX > 0 ? SPEED : -SPEED);
	}

	void BulletMovement()
	{
		Vector3 pos = transform.position;
		transform.position = new Vector3 (pos.x + speed, pos.y, pos.z);
	}

	IEnumerator Die()
	{
		yield return new WaitForSeconds (LIFE_SPAN);
		Destroy (gameObject);
	}

	void Update () {

		StartCoroutine (Die());		// 指定時間で消滅
		BulletMovement ();			// 移動
	}

	void OnTriggerEnter2D(Collider2D collider2d)
	{
		if (collider2d.tag == "player")
		{
			// スコアを減少させる
			GameObject.Find("player").GetComponent<BaseCharacterController>().score -= DAMAGE ;
			Destroy(gameObject);
		}
	}
}
