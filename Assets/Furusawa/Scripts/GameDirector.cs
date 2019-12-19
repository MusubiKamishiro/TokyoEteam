using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//インゲームの管理
public class GameDirector : MonoBehaviour
{
    //シーンをまたぐ
    public static int resultCombo2;
    public static int resultKill2;

    [SerializeField] bool startFlag = false;
    [SerializeField] bool endFlag = false;
    [SerializeField] EnemySpawn enemySpawn;
    [SerializeField] PlayerStatus playerStatus;
    [SerializeField] Player player;
    [SerializeField] CanvasGroup cg;

    //UI
    [SerializeField] Animator introduce;
    [SerializeField] Animator result;
    [SerializeField] Animator mamemaki;
    [SerializeField] Text timeText;
    [SerializeField] Text comboText;
    [SerializeField] Text resultKill;
    [SerializeField] Text resultCombo;
    [SerializeField, Range(0, 1)] float comboAlpha = 0;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] GameObject resultGroup;
    [SerializeField] GameObject introGroup;


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
        cg.alpha = 0;

    }


    void Update()
    {
        //ゲーム終了か体力ないなら
        if(endFlag == true || playerStatus.GetCurrentLife() <= 0)
        {
            resultGroup.SetActive(true);
            cg.alpha = 0;
            player.moveFlag = false;
            //終わったときの処理
            //resultCombo.text = "最大コンボ数:" + maxCombo;
            //resultKill.text = "追い払った数:" + killCount;
            resultCombo.text = "こんぼ:" + maxCombo;
            resultKill.text = "たおした:" + killCount;
            currentTime = 0;
            result.enabled = true;

            //リザルト
            resultCombo2 = maxCombo;
            resultKill2 = killCount;
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

        mamemaki.Play("Mamemaki");
        cg.alpha = 1;
        player.moveFlag = true;
        introduce.Play("introduceEnd");
        startFlag = true;
        enemySpawn.processFlag = true;
        Invoke("ChangeGroup", 1);
    }

    private void ChangeGroup()
    {
        introGroup.SetActive(false);
        resultGroup.SetActive(false);
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
