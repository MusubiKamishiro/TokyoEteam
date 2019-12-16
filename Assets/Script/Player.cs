using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // 左スティックの情報をもとにキャラの向きの変更と移動
        if ((x != 0) || (z != 0))
        {
            Vector3 move = new Vector3(0, 0, 0.1f);
            transform.Translate(move);

            Vector3 direction = new Vector3(x, 0, z);
            transform.localRotation = Quaternion.LookRotation(direction);
        }
        
       


        // 右スティックテスト
        float x2 = Input.GetAxis("Horizontal2");
        float z2 = Input.GetAxis("Vertical2");
        // vertical2の値が反転していたため即席の修正、原因は時間があるときに
        z2 = -z2;


        Debug.Log("x:" + x);
        Debug.Log("x2:" + x2);
        Debug.Log("z:" + z);
        Debug.Log("z2:" + z2);
    }
}
