using UnityEngine;
using System.Collections;

public class CharacterStatus : MonoBehaviour {

	// 随時追加
	// TODO HPをキャラクターに持たせるか決めておく
	public int HP = 0 ;             // 敵にのみ適用されるHP
	public float SPEED ;			// 速さ
	public float JUMP_POWER ;		// ジャンプ力
	public int DamageScore = 0 ;	// スコアの減少値
	public int Score = 0 ;			// プレイヤーにとってはこれがHPみたいなもの
	
}
