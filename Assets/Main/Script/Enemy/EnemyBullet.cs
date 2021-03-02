using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D enemyrbBullet;

    public float speed;//弾のスピード

    public GameObject EnemyBulletPrefab;

    [SerializeField]
    private Transform enemybulletTran;

    [SerializeField]
    private PlayerController playercontroller;

    [SerializeField]
    private Enemy enemy;

    private GameObject enemybullet;

    private Vector2 direction;

    // Start is calledd before the first frame update
    void Start()
    {
        InvokeRepeating("enemyFire", 4, 1);//enemyFireメソッドをゲームスタート時は4秒後に生成し、その後は１秒間隔で生成　　3，2，1，スタートするため4秒後


        InvokeRepeating("TripleenemyFire",4,1);
    }

    // Update is called once per frame
    void Update()
    {
        //enemyFire();


    }


    /// <summary>
    /// 弾を撃つ
    /// </summary>
    public void enemyFire()
    {
        enemybullet = Instantiate(EnemyBulletPrefab, transform);//Prefabを生成

        enemybullet.transform.SetParent(enemybulletTran);

        enemyrbBullet = enemybullet.GetComponent<Rigidbody2D>();

        direction = playercontroller.transform.position - transform.position;

        direction = direction.normalized;

        enemyrbBullet.AddForce(direction * speed);
        //enemyrbBullet.velocity = new Vector2(0, -speed);//弾の方向を指定

        Destroy(enemybullet, 2.0f);

        if(enemy.greenGauge.fillAmount <= 0)
        {
            enemybullet.SetActive(false);
        }
    }

    public void TripleenemyFire()//に送る
                                 //上のUpdateメソッドを参考に作った
                                 //イメージは三方向に球が飛んでいく
    {
        if (enemy.greenGauge.fillAmount <= 0)
        {

            GameObject enemybullet1 = Instantiate(EnemyBulletPrefab, transform);

            enemybullet1.transform.SetParent(enemybulletTran);

            Rigidbody2D enemyrbBullet1 = enemybullet1.GetComponent<Rigidbody2D>();

            direction = playercontroller.transform.position - transform.position;

            direction = direction.normalized;

            direction = new Vector2(direction.x - 0.3f, direction.y - 0.3f);

            enemyrbBullet1.AddForce(direction * speed);

            Destroy(enemybullet1, 3.0f);


            GameObject enemybullet2 = Instantiate(EnemyBulletPrefab, transform);

            enemybullet2.transform.SetParent(enemybulletTran);

            Rigidbody2D enemyrbBullet2 = enemybullet2.GetComponent<Rigidbody2D>();

            direction = playercontroller.transform.position - transform.position;

            direction = direction.normalized;

            direction = new Vector2(direction.x + 0.3f, direction.y + 0.3f);

            enemyrbBullet2.AddForce(direction * speed);

            Destroy(enemybullet2, 3.0f);


            GameObject enemybullet3 = Instantiate(EnemyBulletPrefab, transform);//Prefabを生成

            enemybullet3.transform.SetParent(enemybulletTran);

            Rigidbody2D enemyrbBullet3 = enemybullet3.GetComponent<Rigidbody2D>();

            direction = playercontroller.transform.position - transform.position;

            direction = direction.normalized;

            enemyrbBullet3.AddForce(direction * speed);
            //enemyrbBullet.velocity = new Vector2(0, -speed);//弾の方向を指定

            Destroy(enemybullet3, 2.0f);



        }
    }
}
