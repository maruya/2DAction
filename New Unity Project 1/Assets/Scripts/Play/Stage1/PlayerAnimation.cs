using UnityEngine;
using System.Collections;


public class PlayerAnimation : MonoBehaviour {


	// 自身の攻撃名
	private string NormalAttack1_str = "player_normal_attack1_2";

	public void WalkOrStayAnimation(Vector3 currentPos,Vector3 prevPos)
	{
		if (prevPos != currentPos && Input.anyKey)
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

		Debug.Log(left_or_right);
		// キャラクターの向きを制御
		if (left_or_right > 0 && ! isDirection || left_or_right < 0 && isDirection) 
		{
			isDirection = (left_or_right > 0) ;
			float scaleX = Mathf.Abs(playerScale.x) ;
			playerScale = new Vector3(( isDirection ? -scaleX : scaleX ), playerScale.y, playerScale.z) ;
		}
	}


	public bool NormalAttack1(bool isTouch, string currentRenderer)
	{
		if (isTouch) 
		{
			// Zが押されたら攻撃する
			if (Input.GetKeyDown (KeyCode.Z)) 
				GetComponent <Animator> ().SetTrigger ("NormalAttack1");

			// 攻撃のレイヤーであれば判定を反映させる
			if (NormalAttack1_str == currentRenderer)
				return true;
			else
				return false;
		}
		else
			return false;
	}

}







