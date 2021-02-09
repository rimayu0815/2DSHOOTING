using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float enemyHP;
    [SerializeField]
    private float damage;
   


    [SerializeField]
    private Slider enemySlider;//Slider版HP



    [SerializeField]
    private Image greenGauge;
    [SerializeField]
    private Image redGauge;

    [SerializeField]
    private GameObject enemyHPGauge;



    public bool destroiedEnemy = false;//破壊されたかの判断に使う



    // Start is called before the first frame update
    void Start()
    {
        //enemyHP = 30.0f;SerializeFieldを書いてInspectorから変更できるようにする 　HPGaugeで使いたいからpublicに変更

        //enemySlider = GameObject.Find("EnemySlider").GetComponent<Slider>();//Slider版のHPゲージ

    }


    // Update is called once per frame
    void Update()
    {
        //DecreseSliderHP();Slider版HPゲージで使用
    }



    /// <summary>
    /// 当たり判定
    /// </summary>
    /// <param name="other"></param>
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



        DecreseGaugeHP();
        
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
            greenGauge.fillAmount -= damage / enemyHP;
        }
        else if(greenGauge.fillAmount <=0)
        {
            redGauge.fillAmount -= damage / enemyHP;

            //Debug.Log(redGauge.fillAmount);
        }
        if(redGauge.fillAmount <= 0)
        {
            destroiedEnemy = true;
            Destroy(enemyHPGauge);
            Destroy(this.gameObject);       
        }
    }
}
