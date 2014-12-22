using UnityEngine;
using System.Collections;


public class PlayerAnimation : MonoBehaviour {

	private const float KNOCK_BACK = 2000f ;		// ノックバック値

	public void WalkOrStayAnimation(Vector3 currentPos,Vector3 prevPos)
	{
		// 左右どちらかが押されていれば移動
		if (prevPos != currentPos && (Input.GetKey("left") || Input.GetKey("right") ))
			GetComponent <Animator> ().SetTrigger ("Walk");
		else
			GetComponent <Animator> ().SetTrigger ("Stay");

		// prevPosの更新
		prevPos = currentPos;
	}


	public void Jump(bool isTouch)
	{
		// 接地していないときジャンプ
		if (!isTouch) 
			GetComponent <Animator> ().SetBool ("IsJump", true);
		else
			GetComponent <Animator> ().SetBool ("IsJump", false);
	}


	public void DirectionChange(bool isDirection, Vector3 playerScale)
	{
		// 左右どちらかの判定
		float left_or_right = Input.GetAxis ("Horizontal");

		// キャラクターの向きを制御
		if (left_or_right > 0 && ! isDirection || left_or_right < 0 && isDirection) 
		{
			isDirection = (left_or_right > 0) ;
			float scaleX = Mathf.Abs(playerScale.x) ;
			playerScale = new Vector3(( isDirection ? -scaleX : scaleX ), playerScale.y, playerScale.z) ;
		}
	}


	public void Damage()
	{
		// TODO ノックバックの調整がよくない
		// ノックバックとダメージモーション
		Vector2 vec2 = new Vector2( (this.transform.localScale.x > 0 ? KNOCK_BACK : -KNOCK_BACK), 0f );
		rigidbody2D.AddForce(vec2);
		GetComponent<Animator> ().SetTrigger ("Damage");
	}


	public void NormalAttack1(bool isLegTouch)
	{
        // 足が接地している状態
		if (isLegTouch) 
		{
			// Zが押されたら攻撃する
			if (Input.GetKeyDown (KeyCode.Z)) 
			GetComponent <Animator> ().SetTrigger ("NormalAttack1");
		}
	}


	public void AirAttack1(bool isLegTouch)
	{
		// 足が接地していない状態
		if (! isLegTouch) 
		{
			// Zが押されたら攻撃する
			if (Input.GetKeyDown (KeyCode.Z)) 
			GetComponent <Animator> ().SetTrigger ("AirAttack1");
		}
	}

}







