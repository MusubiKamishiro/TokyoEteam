using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Playerの状態（HPなど)を管理する
public class PlayerStatus : MonoBehaviour
{
    [Header("プレイヤーの体力")]
    [SerializeField, Tooltip("Playerの最大体力")]
    float playerMaxLife = 150;
    [SerializeField]
    float playerCurrentLife = 150;

    [Header("必殺技ゲージ")]
    [SerializeField, Tooltip("必殺ゲージの上限値")]
    float specialMaxValue = 100;
    [SerializeField]
    float specialCurrentValue = 100;
    [SerializeField, Tooltip("時間経過でゲージがたまる倍率")]
    float magni;

    [Header("移動速度")]
    [SerializeField, Tooltip("Playerの移動速度")]
    float moveSpeed = 1;

    [Header("占領したエリア数")]
    [Tooltip("占領したエリア数")] public int captureNumber;


    float time;

    //プレイヤーの状態
    public enum PlayerCondition
    {
        Live,
        Dying,//瀕死の時にゲージはたまるのか
        Dead,
        Item1,//足が速くなるアイテム拾いましたとか
        None
    }
    public PlayerCondition condition = PlayerCondition.None;

    void Start()
    {
        
    }


    void Update()
    {

        //specialCurrentValue = specialCurrentValue % specialMaxValue;
        StatusUpdate();
    }

    private void StatusUpdate()
    {
        specialCurrentValue += Time.deltaTime * magni;
    }


    //必殺技ゲージ
    //もし敵倒した時にゲージ回収できるならこれを敵倒した時もしくは敵にダメージ与えた時
    public void SpecialGageCharge(float value)
    {
        specialCurrentValue += value;
    }


    //他のスクリプトから呼び出す系ーーーーーーーー↓
    public float GetCurrentLife()
    {
        return playerCurrentLife;
    }
    public void SetCurrentLife(float value)
    {
        playerCurrentLife = value;

    }

    //プレイヤーの体力の割合を求める
    public float GetLifePercentage()
    {
        float percentage = playerCurrentLife / playerMaxLife;
        return percentage;
    }

    //プレイヤーの必殺ゲージの割合を求める
    public float GetSpecialGage()
    {
        float percetage = specialCurrentValue / specialMaxValue;
        return percetage;
    }

    public void HitDamage(float damage)
    {
        playerCurrentLife -= damage;
        if(playerCurrentLife <= 0)
        {

        }
    }
}
