using UnityEngine;
using System.Collections;

public class GuiScore : MonoBehaviour {

    // GUIの表示
    [ExecuteInEditMode()]

    private int score = 100;

	void Start () {
	
	}
	
	void Update () {

        // スコアの更新
        //PlayerMove player = GameObject.Find("player").GetComponent<PlayerMove>();
        //score = player.GetStatus().Score;

        // 描画する
        this.guiText.text = "Score_" + score;
	
	}
}
