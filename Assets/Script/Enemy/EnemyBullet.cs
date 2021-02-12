using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D enemyrbBullet;

    public float speed;//弾のスピード

    public GameObject EnemyBulletPrefab;
    // Start is calledd before the first frame update
    void Start()
    {
        InvokeRepeating("enemyFire", 2,1);//enemyFireメソッドをゲームスタート時は２秒後に生成し、その後は１秒間隔で生成
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
        GameObject bullet = Instantiate(EnemyBulletPrefab, transform);//Prefabを生成

        enemyrbBullet = bullet.GetComponent<Rigidbody2D>();

        enemyrbBullet.velocity = new Vector2(0, -speed);//弾の方向を指定

        Destroy(bullet, 2.0f);
    }
}
