using UnityEngine;
using System.Collections;

public class GuiScore : MonoBehaviour {

    // GUIの表示
    [ExecuteInEditMode()]

	private int drawScore ;

	void Start () {
	
		drawScore = 0;
	}
	
	void Update () {

        // スコアの更新
        drawScore = GameObject.Find("player").GetComponent<BaseCharacterController>().score;

        // 描画する
        this.guiText.text = "Score_" + drawScore;
	
	}
}
