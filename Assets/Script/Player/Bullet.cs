using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    //public GameObject bullet;
    private  Rigidbody2D rbBullet;

    public float speed;//弾のスピード

    //private  float x;
    //private  float y;
    //private Vector2 position; 

    public GameObject BulletPrefab;

    [SerializeField]
    private float x;

    public Transform playertran;// playerの位置を参照

    //public GameObject canvas;

    //private Vector3 startPosition;


    // Start is called before the first frame update
    void Start()
    {
        //canvas = GameObject.Find("Canvas");

        //startPosition = transform.position;



        //rbBullet = GameObject.Find("Bullet").GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }


    /// <summary>
    /// 弾を撃つ
    /// </summary>
    public void Fire()
    {
        if (Input.GetMouseButtonDown(1))//右クリックしたら
        {
            GameObject bullet = Instantiate(BulletPrefab, playertran);//弾を生成

            //Debug.Log(transform.position);
            rbBullet = bullet.GetComponent<Rigidbody2D>();


            //bullet.transform.SetParent(canvas.transform, false);

            //transform.position = startPosition;

            //rbBullet.AddForce(transform.up * speed);
        
            rbBullet.velocity = new Vector2(rbBullet.velocity.x, speed);//弾の方向指定

            Destroy(bullet,2.0f);
        }

    }

    //public void OnCollisionEnter2D(Collision2D col)
    //{
    //    if(col.gameObject.tag == "Enemy")
    //    {
    //        Destroy(this.gameObject);

    //    }
    //}
}
