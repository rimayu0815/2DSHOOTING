using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    private float x;
    private float y;

    private Bullet bullet;

    [Header("JoyStickの場合")]
    public bool isJoyStick;


    [SerializeField]
    private Image greenGauge;
    [SerializeField]
    private float playerHP;
    [SerializeField]
    private float damage;
    [SerializeField]
    private GameObject playerHPGauge;

    public bool destroiedPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMove();

    }

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
    public void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(other.gameObject);//弾オブジェクトを破壊

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

    private void DecreseGaugePlayerHP()
    {
        if (greenGauge.fillAmount > 0.0f)
        {
            greenGauge.fillAmount -= damage / playerHP;
        }
        else
        {

            destroiedPlayer = true;
            Destroy(playerHPGauge);
            Destroy(this.gameObject);
        }
    }
}
