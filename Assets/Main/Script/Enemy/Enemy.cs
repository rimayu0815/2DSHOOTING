using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float enemyHP;//Sliderで使っているEnemyのHP　　　　上か下どちらかでいい
    [SerializeField]
    private float enemyMaxHP;//FillAmountで使っているEnemyのHP
    [SerializeField]
    private float damage;//Playerからのダメージ　　ここを敵で管理できるように変更した方がいい



    [SerializeField]
    private Slider enemySlider;//Slider版HP



    [SerializeField]
    private Image greenGauge;//一本目のHP
    [SerializeField]
    private Image redGauge;//二本目のHP
    [SerializeField]
    private GameObject enemyHPGauge;//HPゲージがなくなった時にゲージやフレームごと破壊するため



    public bool destroiedEnemy = false;//破壊されたかの判断に使う
    private GameObject enemy;//HPゲージがなくなった時にオブジェクトごと破壊するため


    [SerializeField]
    private float speed;//移動速度
    private Vector3 direction;//移動方向
    private float x;
    private float y;
    [SerializeField]
    private float chargeTime;
    private float timeCount;
    private Vector3 playerPosition;

    //private Vector2 minMoveArea;  Mathf.Clampsで作成する
    //private Vector2 maxMoveArea;




    // Start is called before the first frame update
    void Start()
    {
        //enemyHP = 30.0f;SerializeFieldを書いてInspectorから変更できるようにする 　HPGaugeで使いたいからpublicに変更

        //enemySlider = GameObject.Find("EnemySlider").GetComponent<Slider>();//Slider版のHPゲージ

        enemy = GameObject.Find("Enemy");

        RandomDirection();

    }


    // Update is called once per frame
    void Update()
    {
        //DecreseSliderHP();Slider版HPゲージで使用
        EnemyMove();
    }



    /// <summary>
    /// 当たり判定
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerEnter2D(Collider2D other)
    {     
        if(other.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject);//弾オブジェクトを破壊

            DecreseGaugeHP();
        }

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
    /// Slider版のHPゲージ
    /// </summary>
    //public void DecreseSliderHP()
    //{
    //    enemySlider.value = enemyHP;　　必要ない
    //}

    ///<summary>
    ///fillAmountでの㏋ゲージ
    /// </summary>
    public void DecreseGaugeHP()
    {
        if(greenGauge.fillAmount>0.0f)
        {
            greenGauge.fillAmount -= damage / enemyMaxHP;
        }
        else if(greenGauge.fillAmount <=0)
        {
            redGauge.fillAmount -= damage / enemyMaxHP;

            //Debug.Log(redGauge.fillAmount);
        }
        if(redGauge.fillAmount <= 0)
        {
            destroiedEnemy = true;
            Destroy(enemyHPGauge);
            //Destroy(enemy); 
            enemy.SetActive(false);
        }
    }


    /// <summary>
    /// 方向を定める（改良必要）
    /// </summary>
    public void RandomDirection()
    {
        x = Random.Range(-1,2);//ランダムに動く方向のｘの範囲、2にしているのはこれ-１以上２未満だから
        y = Random.Range(-1,2);//ｙの範囲
        direction = new Vector3(x, y, 0);


        //動かないという待機状態をなくしたかったが上手くいってなさそう、
        //ついでに動く限界範囲になってもその方向を選んでしまったら動いてないように見える
        //例えば、右端にいるのに方向をｘが１でｙが０を選んでしまったとき
        if (x==0&&y==0)

        {
            RandomDirection();
        }

    }

    /// <summary>
    /// ランダム移動（改良必要）
    /// </summary>
    public void EnemyMove()
    {
        timeCount += Time.deltaTime;//移動方向を変えるために時間を図ってる


        transform.position += speed * direction * Time.deltaTime;//移動
        playerPosition = transform.position;//変数作らないとtransform.positionをいじれないから
        playerPosition.x = Mathf.Clamp(playerPosition.x, -2, 2);//ｘの移動範囲、0，0で画面の中心だからそこから把握
        playerPosition.y = Mathf.Clamp(playerPosition.y, -1, 3);//ｙの移動範囲
        transform.position = new Vector2(playerPosition.x, playerPosition.y);//範囲を定めて代入
        

        if(timeCount>chargeTime)//時間を超えたら（何秒か毎に方向変更）
        {
            RandomDirection();
            timeCount = 0;//カウントをリセット
        }
    }

}
