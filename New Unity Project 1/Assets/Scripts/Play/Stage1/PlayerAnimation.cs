using UnityEngine;
using System.Collections;


public class PlayerAnimation : MonoBehaviour {
	

	public void WalkOrStayAnimation(Vector3 currentPos,Vector3 prevPos)
	{
		if (prevPos != currentPos && Input.anyKey)
			GetComponent <Animator> ().SetTrigger ("Walk");
		else
			GetComponent <Animator> ().SetTrigger ("Stay");

		// prevPosの更新
		prevPos = currentPos;
	}


	public void Jump(Vector3 playerPos, Vector3 playerLegPos, int layer)
	{
		// 接地していないときジャンプ
		if (! Physics2D.Linecast (playerPos, playerLegPos, layer)) 
			GetComponent <Animator> ().SetBool ("IsJump", true);
		else
			GetComponent <Animator> ().SetBool ("IsJump", false);
	}


	public void DirectionChange(bool isDirection, Vector3 playerScale)
	{
		// 左右どちらかの判定
		float left_or_right = Input.GetAxis ("Horizontal");

		// キャラクターの向きを制御
		if (left_or_right > 0f && ! isDirection || left_or_right < 0f && isDirection) 
		{
			isDirection = (left_or_right > 0f) ;
			float scaleX = Mathf.Abs(playerScale.x) ;
			playerScale = new Vector3(( isDirection ? -scaleX : scaleX ), playerScale.y, playerScale.z) ;
		}

	}


	public void NormalAttack1()
	{
		// Zが押されたら攻撃する
		if (Input.GetKeyDown (KeyCode.Z)) 
			GetComponent <Animator> ().SetTrigger ("NormalAttack1");
			
	}

}







