using UnityEngine;
using System.Collections;


public class PlayerAnimation : MonoBehaviour {


	public void WalkOrStayAnimation(Vector3 currentPos,Vector3 prevPos)
	{
        // なにかキーが押されていれば歩く
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

		// キャラクターの向きを制御
		if (left_or_right > 0 && ! isDirection || left_or_right < 0 && isDirection) 
		{
			isDirection = (left_or_right > 0) ;
			float scaleX = Mathf.Abs(playerScale.x) ;
			playerScale = new Vector3(( isDirection ? -scaleX : scaleX ), playerScale.y, playerScale.z) ;
		}
	}


	public void NormalAttack1(bool isLegTouch, string currentRenderer)
	{
        // 足が設置している状態
		if (isLegTouch) 
		{
			// Zが押されたら攻撃する
			if (Input.GetKeyDown (KeyCode.Z)) 
			GetComponent <Animator> ().SetTrigger ("NormalAttack1");
		}
	}

}







