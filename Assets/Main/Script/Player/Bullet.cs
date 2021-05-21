using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bullet : MonoBehaviour
{

    //public GameObject bullet;
    private  Rigidbody2D rbBullet;

    public float speed;//弾のスピード

    //private  float x;
    //private  float y;
    //private Vector2 position; 

    public GameObject BulletPrefab;

    public Transform playertran;// playerの位置を参照

    [SerializeField]
    private float bulletcharge;//連打で撃てないようにする
    private float timer;

    private float bulletCount;
    public float bulletMaxCount;

    private bool gamestart = false;

    [SerializeField]
    private Transform bulletTran;


    public bool Attackking  = true;

    /// <summary>
    ///プレイ画面左下の姿勢変更ゲージを作成 
    /// </summary> /// 
    public GameObject MP;//下のpostureGaugeにデータを入れるため
    public Image mpGauge;//fillAmountを使うためにデータを入れる
    public float countTime = 2.0f;//これでゲージの減りを調整


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameStart());

        bulletCount = bulletMaxCount;
        MP = GameObject.Find("greenGauge");
        mpGauge = MP.GetComponent<Image>();
        mpGauge.fillAmount = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(1) && gamestart == true && timer > bulletcharge && bulletCount > 0 && Attackking == true)//右クリックしたら
        {
            Fire();

        }
        if (Attackking == false)
        {
            AddMP();
        }
    }


    /// <summary>
    /// 弾を撃つ
    /// </summary>
    public void Fire()
    {
        timer = 0;

        bulletCount -= 1f;
        DecreseMP();

        GameObject bullet = Instantiate(BulletPrefab, playertran);//弾を生成

        bullet.transform.SetParent(bulletTran);


        rbBullet = bullet.GetComponent<Rigidbody2D>();

        rbBullet.AddForce(transform.up * speed);

        Destroy(bullet, 2.0f);


    }

    private IEnumerator GameStart()
    {
        
        yield return new WaitForSeconds(4.0f);

        gamestart = true;

    }

    private void DecreseMP()
    {
        Debug.Log(mpGauge.fillAmount);
        mpGauge.fillAmount -= 1 / bulletMaxCount;
        if (mpGauge.fillAmount <= 0.0f)
        {
            mpGauge.fillAmount = 0.0f;
            Attackking = false;
            bulletCount = bulletMaxCount;
        }

    }
    private void AddMP()
    {
        mpGauge.fillAmount += 0.5f / countTime * Time.deltaTime;
        if (mpGauge.fillAmount >= 1.0f)
        {
            mpGauge.fillAmount = 1.0f;
            Attackking = true;
        }
    }


}
