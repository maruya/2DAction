using UnityEngine;
using System.Collections;

public class PlayerController : BaseCharacterController
{

    private bool isDirection;				// キャラクターの向き
    private int OBJECT_LAYER;				// 接地判定に使用する専用レイヤー
    private Transform playerLeftLeg;		// キャラクターの左足(接地判定に(使用)
    private Transform playerRightLeg;		// キャラクターの右足(接地判定に(使用)
	private Transform playerCenterLeg;		// キャラクターの両足の中間
    private Vector3 prevPos;				// 前回の座標
    private const float KNOCK_BACK = 2000f;	// ノックバック定数
    private const float SPEED = 2.0f;       // プレイヤーの速度
    private const float JUMP_POWER = 250f;  // プレイヤーのジャンプ力

    protected override void Awake()
    {
        // 一応なにか入れておく
        isDirection = false;

        // 接地レイやーの取得
        OBJECT_LAYER = 1 << LayerMask.NameToLayer("Object");

        // 両足の情報を取得
        playerLeftLeg = GameObject.Find("playerLeftLeg").transform;
        playerRightLeg = GameObject.Find("playerRightLeg").transform;
		playerCenterLeg = GameObject.Find ("playerCenterLeg").transform;

        // 初期化
        prevPos = transform.position;
        jumpPower = JUMP_POWER;
    }


    // PlayerMainのUpdateで初めに呼んでもらう内部的処理をしている関数
    //======================================
    public void EarlyUpdate()
    {
        // 移動の方向に速度を代入
            if (Input.GetKey("left"))
                speed = -SPEED;
            else if (Input.GetKey("right"))
                speed = SPEED;
            else
                speed = 0f;

        // 設置してるか判断
        isGroundTouch = LegTouchToObject();
    }


    private bool LegTouchToObject()
    {
        // 両足の設置判定を見る
        if (Physics2D.Linecast(transform.position, playerLeftLeg.position, OBJECT_LAYER) ||
            Physics2D.Linecast(transform.position, playerRightLeg.position, OBJECT_LAYER)||
		    Physics2D.Linecast(transform.position, playerCenterLeg.position, OBJECT_LAYER)) 
			return true;
        else return false;
    }


    // 基本行動(ジャンプ・待機・歩く・向き)
    //======================================
    private void DirectionChange()
    {
        // 左右どちらを向いてるか判断
        float left_or_right = Input.GetAxis("Horizontal");

        // キャラクターの向きを設定
        if (left_or_right > 0 && !isDirection || left_or_right < 0 && isDirection)
        {
            isDirection = (left_or_right > 0);
            float scaleX = Mathf.Abs(transform.localScale.x);
            transform.localScale = new Vector3(( isDirection ? -scaleX : scaleX), transform.localScale.y, transform.localScale.z);
        }
    }


    private void AnimationWalk()
    {
        if (transform.position != prevPos &&
           Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Animator>().SetTrigger("Walk");
        }
        else
            GetComponent<Animator>().SetTrigger("Stay");
    }

    private void AnimationJump()
    {
        if (!isGroundTouch)
            GetComponent<Animator>().SetBool("IsJump", true);
        else
            GetComponent<Animator>().SetBool("IsJump", false);
    }

    // 移動、ジャンプなど一般的なアニメーションを管理する
    public void AnimationCommon()
    {
		AnimationWalk ();
        AnimationJump();
    }
    // ダメージ
    //========================================

    private void AnimationDamage()
    {
        Vector2 vec2 = new Vector2((transform.localScale.x > 0 ? KNOCK_BACK : -KNOCK_BACK), 0f);
        rigidbody2D.AddForce(vec2);
        GetComponent<Animator>().SetTrigger("Damage");
    }

    // 攻撃各種
    //=========================================
    private void AnimationNormalAttack()
    {
        if (isGroundTouch)
		{			
			// TODO アニメーターで指定のフレーム情報がうまく取れない
			// falseであれば衝撃波を生成
			Animator animator = GetComponent<Animator> ();
			AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo (0);
			if(! stateInfo.IsName("NormalAttack1"))
			{
				Instantiate(Resources.Load("Prefabs/AttackEffect1"));
			}

            GetComponent<Animator>().SetTrigger("NormalAttack1");
        }
    }


    private void AnimationAirAttack()
    {
        if (!isGroundTouch)
        {
            GetComponent<Animator>().SetTrigger("AirAttack1");
        }
    }


    public void AnimationAttackManager()
    {
        AnimationNormalAttack();
        AnimationAirAttack();
    }


    protected override void FixedUpdate()
    {
        // ジャンプ
        if (isGroundTouch)
        {
            if (Input.GetButtonDown("jump"))
			{
                rigidbody2D.AddForce(new Vector2(0f, jumpPower));
				rigidbody2D.velocity = new Vector2( 0f,1f );		// 接地している地面から少し離れる(大ジャンプ防止)
			}
        }

        // 速度を加算
        rigidbody2D.velocity = new Vector2(speed, this.rigidbody2D.velocity.y);

        // 向きを設定
        DirectionChange();
    }
	


	void OnCollisionEnter2D(Collision2D collision2d)
    {
        if (collision2d.transform.tag == "Enemy")
        {
            // 敵のステータスからスコアの減少値を取得し,プレイヤーに減算
			int damage = collision2d.gameObject.GetComponent<BaseCharacterController>().power ;
            score -= damage;
			if( score <= 0 ) score = 0 ;

            // ダメージモーションの実行
            AnimationDamage();
        }

    }
}








