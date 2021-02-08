using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    private float x;
    private float y;

    private Bullet bullet;

    [Header("JoyStickの場合")]
    public bool isJoyStick;

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
}
