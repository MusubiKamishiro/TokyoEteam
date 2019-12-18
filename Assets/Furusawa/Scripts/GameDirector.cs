using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//インゲームの管理
public class GameDirector : MonoBehaviour
{
    [SerializeField] bool startFlag = false;
    [SerializeField] bool endFlag = false;
    [SerializeField] EnemySpawn enemySpawn;
    [SerializeField] PlayerStatus playerStatus;

    //UI
    [SerializeField] Animator introduce;
    [SerializeField] Animator result;
    [SerializeField] Text timeText;
    [SerializeField] Text comboText;
    [SerializeField] Text resultText;
    [SerializeField, Range(0, 1)] float comboAlpha = 0;
    [SerializeField] CanvasGroup canvasGroup;


    [SerializeField] float limitTime = 60;
    public float currentTime = 0;



    public int maxCombo = 0;
    //現在のコンボ数
    public int currentCombo = 0;
    public int killCount = 0;

    private float time = 0;

    void Start()
    {
        introduce.Play("introduce");
        result.enabled = false;
        currentTime = limitTime;
        timeText.text = currentTime.ToString();

    }


    void Update()
    {
        //ゲーム終了か体力ないなら
        if(endFlag == true || playerStatus.GetCurrentLife() <= 0)
        {
            //終わったときの処理
            resultText.text = "最大コンボ数:" + maxCombo;

            currentTime = 0;
            result.enabled = true;
            return;
        }


        if(startFlag == false)
        {
            //ゲームが始まってないときの処理
            return;
        }


        TextUpdate();
        UpdateScore();
        TimeUpdate();

    }

    public void TextUpdate()
    {
        timeText.text = currentTime.ToString();

        comboText.text = currentCombo + "Hit";
        if (maxCombo <= currentCombo) maxCombo = currentCombo;
    }

    private void TimeUpdate()
    {

        currentTime -= Time.deltaTime;
        //制限時間来たらおしまい
        if (currentTime <= 0)
        {
            currentTime = 0;
            endFlag = true;
        }
    }

    public void GameStart()
    {
        introduce.Play("introduceEnd");
        startFlag = true;
        enemySpawn.processFlag = true;
    }

    //ゲームエンドは別スクリプトをボタンにアタッチする

    private void UpdateScore()
    {
        if(currentCombo == 0)
        {
            comboAlpha = 0;
            canvasGroup.alpha = comboAlpha;
            return;
        }

        comboAlpha = 1;
        canvasGroup.alpha = comboAlpha;

    }

    public void CountCombo()
    {
        currentCombo++;
    }

}
