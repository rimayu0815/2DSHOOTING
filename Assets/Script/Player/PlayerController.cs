using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;//移動スピード

    private Rigidbody2D rb;//弾の運動

    private float x;//横移動
    private float y;//縦移動

    //private Bullet bullet;

    [Header("JoyStickの場合")]
    public bool isJoyStick;


    [SerializeField]
    private Image greenGauge;//HPゲージ
    [SerializeField]
    private float playerMaxHP;//HPの最大値
    [SerializeField]
    private float damage;//Enemyからのダメージ　　ここを敵で管理できるように変更した方がいい
    [SerializeField]
    private GameObject playerHPGauge;//HPゲージがなくなった時にゲージやフレームごと破壊するため

    public bool destroiedPlayer = false;//GameOverやクリア等の判定
    private GameObject player;//HPゲージがなくなった時にオブジェクトごと破壊するため

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMove();

    }

    /// <summary>
    /// Playerの移動操作
    /// </summary>
    public void PlayerMove()
    {
        if(isJoyStick)
        {
            //
        }
        else 
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");
        }
        if (x != 0 || y != 0 )
        {
           //rb.velocity = new Vector2(x * speed, y * speed);滑ってしまう

           Vector2 moveDir = new Vector2(x,y).normalized;//速度ベクトルを作成するので、値が０か１になる
            rb.velocity = new Vector2(moveDir.x * speed, moveDir.y * speed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        x = 0;
        y = 0;
    }


    /// <summary>
    /// Playerの当たり判定
    /// </summary>
    public void OnTriggerEnter2D(Collider2D other)//CollisionからTorrigerに変更　弾同士がぶつかるため
    {
        if(other.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
        }
        //Destroy(other.gameObject);//弾オブジェクトを破壊

        //if(enemyHP > 0.0f)//０より上なら１減らして、０未満なら破壊 Slider版HPゲージで使用
        //{
        //    enemyHP -= damage;
        //}
        //else
        //{
        //    Destroy(this.gameObject);
        //}



        DecreseGaugePlayerHP();

    }


    /// <summary>
    /// ダメージ処理
    /// </summary>
    private void DecreseGaugePlayerHP()
    {
        if (greenGauge.fillAmount > 0.0f)
        {
            greenGauge.fillAmount -= damage / playerMaxHP;
        }
        if(greenGauge.fillAmount <= 0.0f)
        {

            destroiedPlayer = true;
            Destroy(playerHPGauge);
            Destroy(player);
        }
    }
}
