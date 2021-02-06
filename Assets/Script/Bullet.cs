using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    //public GameObject bullet;
    private  Rigidbody2D rbBullet;

    public float speed;

    //private  float x;
    //private  float y;
    //private Vector2 position; 

    public GameObject BulletPrefab;

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

    public void Fire()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject bullet = Instantiate(BulletPrefab, transform);

            //Debug.Log(transform.position);
            rbBullet = bullet.GetComponent<Rigidbody2D>();


            //bullet.transform.SetParent(canvas.transform, false);

        //transform.position = startPosition;


        //rbBullet.AddForce(transform.forward * speed);

        
            rbBullet.velocity = new Vector2(0, speed);

            Destroy(bullet,2.0f);
        }

    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);

        }
    }
}
