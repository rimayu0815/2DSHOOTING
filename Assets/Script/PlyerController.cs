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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();

    }

    public void PlayerMove()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        if (x > 0 || x < 0 || y > 0 || y < 0)
        {
           rb.velocity = new Vector2(x * speed, y * speed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
