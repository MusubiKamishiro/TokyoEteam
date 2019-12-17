using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaBossFlag : MonoBehaviour
{
    float time;
    void Start()
    {
       
    }
    private void OnDestroy()
    {
        //ボスからこの関数を呼び出せば占領できる
        transform.parent.GetComponent<AreaManager>().CaptureComplete();
        transform.parent.GetComponent<EnemySpawn>().processFlag = false;
    }



}
