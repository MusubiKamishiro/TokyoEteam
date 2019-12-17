using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaBossFlag : MonoBehaviour
{
    float time;
    void Start()
    {
       
    }


    void Update()
    {
        time += Time.deltaTime;
        if(time > 2f)
        {
            //ボスからこの関数を呼び出せば占領できる
            transform.parent.GetComponent<AreaManager>().CaptureComplete();
            Destroy(gameObject);
        }
    }

}
