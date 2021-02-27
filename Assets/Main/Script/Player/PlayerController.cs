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

    private Vector2 playerPosition;

    //private Bullet bullet;

    [Header("JoyStickの場合")]
    public bool isJoyStick;


    [SerializeField]
    private Image greenGauge;//HPゲージ
    [SerializeField]
    private Image redGauge;//HP赤ゲージ
    [SerializeField]
    private Sprite redSprite;
    [SerializeField]
    private Sprite greenSprite;
    //private GameObject imageP;
    [SerializeField]
    private float playerMaxHP;//HPの最大値
    [SerializeField]
    private float damage;//Enemyからのダメージ　　ここを敵で管理できるように変更した方がいい
    [SerializeField]
    private GameObject playerHPGauge;//HPゲージがなくなった時にゲージやフレームごと破壊するため

    public bool destroiedPlayer = false;//GameOverやクリア等の判定
    private GameObject player;//HPゲージがなくなった時にオブジェクトごと破壊するため


    [SerializeField]
    private SimpleTouchController simple;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.Find("Player");

        //imageP = GameObject.Find("ImageP");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        PlayerMove();

    }

    void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -2.2f, 2.2f), Mathf.Clamp(transform.position.y, -4.42f, -3));//これでちゃんと範囲で止まる

    }

    /// <summary>
    /// Playerの移動操作
    /// </summary>
    public void PlayerMove()
    {
        if(isJoyStick)
        {
            Vector2 pos = simple .GetTouchPosition;

            x = pos.x;
            y = pos.y;
        }
        else 
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");
        }
        if (x != 0 || y != 0 )
        {
           //rb.velocity = new Vector2(x * speed, y * speed);滑ってしまう

           Vector2 moveDir = new Vector2(x,y);//速度ベクトルを作成するので、値が０か１になる
           rb.velocity = new Vector2(moveDir.x * speed,moveDir.y * speed);


            ///<summary>この下四行のコードでプレイヤーの移動制限を書いたけど上手くいかない（上下のコードを見て調整必要、おそらく下のzero）</summary>
            //playerPosition = rb.velocity;
            //playerPosition.x = Mathf.Clamp(playerPosition.x, -2, 2);
            //playerPosition.y = Mathf.Clamp(playerPosition.y, -1, 1);
            //transform.position = new Vector2(playerPosition.x, playerPosition.y);


            //移動制限　これでとりあえずOK、ただ横端に当たるとちょこっと範囲外に動く
            //transform.position = new Vector2(Mathf.Clamp(transform.position.x, -2.2f, 2.2f),Mathf.Clamp(transform.position.y, -4.42f, -3));

            


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

            DecreseGaugePlayerHP();

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
        if(greenGauge.fillAmount <=0.5f)
        {
        //    sprite = Resources.Load<Sprite>("ゲージベース2");
        //    redGauge = this.GetComponent<Image>();
        //    redGauge.sprite = sprite;
            greenGauge.sprite = redSprite;
        }
        if(greenGauge.fillAmount <= 0.0f)
        {

            destroiedPlayer = true;
            Destroy(playerHPGauge);
            //Destroy(player);
            player.SetActive(false);
        }
    }
}
