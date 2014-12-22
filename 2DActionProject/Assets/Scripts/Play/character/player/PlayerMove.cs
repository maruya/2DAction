using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	private float speed = 0f ;					// 実際に代入する速度
	private const float SPEED = 2.0f ;			// プレイヤーは固定の速度で移動する
	private bool isRightDirection = true ;		// キャラクターの向きを判断するフラグ
	private const float JUMP_POWER = 250f;		// ジャンプ力
	private int OBJECT_LAYER ;					// 接地判定に使用するレイヤー
	private Transform playerLeftLeg ;			// 接地判定に使用するプレイヤーの左脚
    private Transform playerRightLeg;			// 接地判定に使用するプレイヤーの右脚
	private Vector3 prevPos ;					// フレーム前の座標
	private PlayerAnimation playerAnimation ;	// プレイヤのアニメーション
	private bool isLegTouch = false ;			// 攻撃中であるかのフラグ
	private CharacterStatus status ; 			// 自身のステータス

	public CharacterStatus GetStatus(){return status;}


	void Start () {

        // オブジェクトレイヤーを取得
        this.OBJECT_LAYER = 1 << LayerMask.NameToLayer("Object");

        // 1フレーム前の座標
		prevPos = this.transform.position;

        // アニメーションScriptを取得
		playerAnimation = gameObject.GetComponent<PlayerAnimation> ();

		// ステータスを取得
		status = gameObject.GetComponent<CharacterStatus> ();

        // 両足の座標を取得
        playerLeftLeg = transform.Find("playerLeftLeg");
        playerRightLeg = transform.Find("playerRightLeg");
	}

	void Update () {

		// 現在のロコモーターのタグを調べ、移動できるか判断
		Animator anim = GetComponent<Animator> ();
		AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo (0);
		if (state.IsTag ("BaseMotion")) 
		{
			// 移動の方向に速度を代入
			if (Input.GetKey ("left"))
				speed = -SPEED;
			else if (Input.GetKey ("right"))
				speed = SPEED;
			else
				speed = 0f;
		}

		// 接地判定の更新
		isLegTouch = LegTouchToObject ();
	}

	bool LegTouchToObject()
	{
        // 両足で設置判定を見る
        if (Physics2D.Linecast(this.transform.position, this.playerLeftLeg.position, this.OBJECT_LAYER) ||
            Physics2D.Linecast(this.transform.position, this.playerRightLeg.position, this.OBJECT_LAYER)) return true;
		else return false ;
	}


	void GeneralAnimationMove()
	{
		// 移動or待機
		playerAnimation.WalkOrStayAnimation (this.transform.position, this.prevPos);

        //ToDO=====Animationスクリプトで実行するとScaleが反映されない未解決
		// 向きの変更
		//Playeranimation.DirectionChange (IsRightDirection, this.transform.localScale);
		// ジャンプ処理
		playerAnimation.Jump (this.isLegTouch);
		// 現在のsprite画像のnameを受け取る
		SpriteRenderer sp = GetComponent<SpriteRenderer> ();
		// 通常攻撃1
		playerAnimation.NormalAttack1 (this.isLegTouch, sp.sprite.name);
	}

	void FixedUpdate()
	{
		if (isLegTouch) 
		{
            if (Input.GetButtonDown("jump")) rigidbody2D.AddForce(new Vector2(0f, JUMP_POWER));
		}

		// 速度を制限
		float h = Input.GetAxis ("Horizontal");
		rigidbody2D.velocity = new Vector2 (speed, this.rigidbody2D.velocity.y);

		// キャラクターの向きを制御
		if (h > 0f && ! this.isRightDirection || h < 0f && this.isRightDirection) 
		{
			this.isRightDirection = (h > 0f) ;
			float scale = Mathf.Abs(this.transform.localScale.x) ;
			this.transform.localScale = new Vector3(( this.isRightDirection ? -scale : scale ), this.transform.localScale.y, this.transform.localScale.z) ;
		}

		// アニメーションを実行
		GeneralAnimationMove ();
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.tag == "Enemy") 
		{
			// 敵のステータスからスコアの減少値を取得し,プレイヤーに減算
			CharacterStatus enemyStatus = collision.gameObject.GetComponent<CharacterStatus>();
			status.Score -= enemyStatus.DamageScore ;

			// ダメージモーションの実行
			playerAnimation.Damage();
		}
	}
}









