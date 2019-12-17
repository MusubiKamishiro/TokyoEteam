using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChase : MonoBehaviour
{

    //マウスカーソルの位置取得用
    Transform Cursor;

    // Start is called before the first frame update
    void Start()
    {
        //マウスカーソルのTransformを設定
        Cursor = GameObject.Find("Main Camera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(ray.direction);

       
    }
}
