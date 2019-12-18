using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//一つのエリアを占領しているかしていないかの判断
//敵が死んだときにtransform.parent.getcomponent<AreaManager>().CaptureComplete()を指定しなきゃ占領できない
public class AreaManager : MonoBehaviour
{
    [SerializeField] PlayerStatus playerStatus;
    //処理し始めるか？
    [SerializeField] bool inPlayer = false;

    //エリアの主
    [SerializeField] GameObject bossPrefab;
    private GameObject boss;

    [SerializeField] Color enemyColor;
    [SerializeField] Color playerColor;
    [SerializeField] Renderer renderer;

    //[SerializeField]

    //エリアの占領状況について
    public enum State
    {
        Capture,
        NotCapture,
        NowCapture
    }
    public State state = State.NowCapture;

    void Start()
    {
        renderer.material.color = enemyColor;
    }


    void Update()
    {
        

        //プレイヤーが来てない
        if(inPlayer == false || State.Capture == state)
        {
            //Debug.Log("プレイヤーがいない");
            return;
        }

        //if(state == State.Capture)
        //{
        //    renderer.material.color = playerColor;
        //}


        //ボスがいない＋占領している　=　もう倒し終わった
        if(boss == null && state == State.Capture)
        {
            Debug.Log("倒し終わった");
            return;
        }

        //ボスがいない＋占領していない　=　これから占領
        if(boss == null && state == State.NotCapture)
        {
            BossInstantiate();
        }

    }

    private void BossInstantiate()
    {
        state = State.NowCapture;
        //ボスがいないからプレイヤーが来たら出現させる
        Vector3 pos = new Vector3(Random.Range(-3, 3), 0, Random.Range(-3, 3));
        pos = pos + transform.position;
        boss = Instantiate(bossPrefab, pos, Quaternion.identity);
        boss.transform.SetParent(transform);
        Debug.Log("ボス出現");
    }

    //Player
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inPlayer = true;
            playerStatus = other.GetComponent<PlayerStatus>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inPlayer = false;
        }
    }

    public void CaptureComplete()
    {
        state = State.Capture;
        //playerStatus.captureNumber++;
        renderer.material.color = playerColor;

    }
}
