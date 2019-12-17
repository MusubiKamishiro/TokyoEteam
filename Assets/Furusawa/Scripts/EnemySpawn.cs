using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敵の沸き(Spawn)を管理する
//敵が沸いてほしくないところを設定するにはTagをGroundに設定する
public class EnemySpawn : MonoBehaviour
{
    //このスクリプトを実行するか（ゲーム開始前とか終わりにはFalseにしておくこと)
    public bool processFlag = true;
    //敵の種類
    [SerializeField,Tooltip("敵のプレハブを入れてください")] GameObject[] enemy;

    //沸き上限(確認用Serialize)
    [SerializeField,Tooltip("敵が沸く上限を設定してください")] float spawnLimit = 10;

    //空から地面にRayを飛ばして地面の様子を見る？
    //sphere出して様子見る？

    [SerializeField,Tooltip("現在敵がどれくらいいるのか")] private int currentEnemyNum = 0;


    //プレイヤーからの沸き範囲
    [SerializeField,Tooltip("何のそばに敵をSpawnさせるか")] GameObject target;
    [SerializeField,Tooltip("敵が沸く、プレイヤーとの最低距離")] float innerRadius;
    [SerializeField,Tooltip("敵が沸く、プレイヤーとの最高距離")] float outerRadius;



    //どのくらいのペースでspawnさせるか
    [SerializeField,Tooltip("どのくらいの頻度で敵をSpawnさせるか(秒)")] float spawnInterVal = 3;
    private float currentTime = 0;

    //一度にどれくらいspawnさせるか
    [SerializeField,Tooltip("一度に何体Spawnさせるか")] int oneTimeSpawn = 3;


    void Start()
    {
        
    }


    void Update()
    {
        //Debug.DrawRay(new Vector3(0, 10, 0), new Vector3(0, 10, 0));
        if(processFlag == false)
        {
            return;
        }
        TimeCount();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CheckGround(Vector3.zero);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            SetPosition();
        }


    }

    //常に呼ぶ関数。時間がクールタイム以上ならスポーン
    private void TimeCount()
    {
        currentTime += Time.deltaTime;
        if (spawnInterVal < currentTime)
        {
            //一度に何体spawnさせるのか
            for(int i = 0; i < oneTimeSpawn; i++)
            {
                Spawn();
            }

            //小数点を切り捨てない
            currentTime -= spawnInterVal;
        }
    }

    //敵を沸かすメソッド
    private void Spawn()
    {
        //敵が上限に達しているなら処理通さない
        if(spawnLimit <= currentEnemyNum)
        {
            return;
        }

        //沸かす処理開始
        currentEnemyNum++;

        Vector3 spawnPos = SetPosition();

        //配列の中でランダムに敵を選び、Groundの場所に敵を配置
        GameObject enemyInstant = Instantiate(RandomEnemy(), spawnPos, Quaternion.identity);


    }

    //配列内の敵をランダムで決定
    private GameObject RandomEnemy()
    {
        GameObject setEnemy = enemy[Random.Range(0, enemy.Length)];
        return setEnemy;
    }

    //敵が死んだときに現在の敵の数を減らして管理する
    public void EnemyNumDecrease()
    {
        currentEnemyNum--;
    }

    //敵の沸き位置を決定
    private Vector3 SetPosition()
    {
        //外の四角の範囲内かつ内の四角の範囲内に敵を沸かす
        //円を求めてradiusの分離れた場所にset
        Vector3 pos = Vector3.zero;
        bool isOK = false;
        //場所が見つからない間繰り返す

        while (true)
        {
            ////とりあえずここに書く。内側の最大値と外側の最大値の間でランダム
            var pos1 = Random.Range(innerRadius, outerRadius);

            var angle = Random.Range(0, 360);
            var rad = angle * Mathf.Deg2Rad;
            var px = Mathf.Cos(rad) * pos1 + target.transform.position.x;
            var py = Mathf.Sin(rad) * pos1 + target.transform.position.z;
            pos = new Vector3(px, 0, py);

            if (CheckGround(pos)) break;
        }



        return pos;

    }

    //spawnの位置に物が置いてないか確認してなければTrueを返す
    private bool CheckGround(Vector3 checkPos)
    {
        bool flag = false;
        checkPos.y += 5;

        Ray ray = new Ray(checkPos, new Vector3(0, -10, 0));
        RaycastHit hit;

        //Rayが伸びる距離
        int distance = 50;


        //Rayの可視化    ↓Rayの原点　　　　↓Rayの方向　　　　↓Rayの色
        //Debug.DrawLine(ray.origin, ray.direction * distance, Color.red);

        //もしRayにオブジェクトが衝突したら
        if (Physics.Raycast(ray, out hit, distance))
        {
            //当たったものがGround、つまり地面のタグのもの（もし樽とかあってもタグがGroundならOK)
            if (hit.collider.tag == "Ground")
            {
                Debug.Log("RayがGroundに当たった");
                flag = true;
            }
        }

        return flag;
    }
}
