using UnityEngine;
using System.Collections;

public class ItemMain : MonoBehaviour {

    public int point = 0;   // アイテムの持つポイント

	void Start () {
	
	}
	
	void Update () {
	
	}

    void CreateDrawScore()
    {
        string drawScore = point.ToString();
        float addX = 0;								// スコアの描画の重なりを防止

        // スコアをプレハブから生成
        foreach (var score in drawScore)
        {
            string serif = "Prefabs/ScoreNumbers/" + score;
            Vector3 pos = new Vector3(transform.position.x + addX, transform.position.y, transform.position.z);
            Instantiate(Resources.Load(serif), pos, this.transform.rotation);
            addX += 0.5f;
        }
    }

    void OnTriggerEnter2D(Collider2D collider2d)
    {
        // プレイヤーにスコアを渡し消滅する
        if (collider2d.name == "player")
        {
            GameObject.Find("player").GetComponent<BaseCharacterController>().score += point;
            CreateDrawScore();
            Destroy(gameObject);
        }
    }
}
