using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveFuru : MonoBehaviour
{
    //[SerializeField] float speed = 1f;
    //private Rigidbody rb;

    //private Vector3 oldVector = Vector3.zero;

    //// 右スティックの回転率
    //private Vector3 rightStick;
    //// 1フレーム前の右スティックの回転率
    //private Vector3 oldRightStick;
    //// 豆の攻撃方向
    //private Vector3 attack;

    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}


    //void Update()
    //{


    //    oldRightStick = rightStick;

    //    if ((oldRightStick.x >= 0.5) || (oldRightStick.x <= -0.5))
    //    {
    //        attack.x = oldRightStick.x;
    //    }
    //    if ((oldRightStick.z >= 0.5) || (oldRightStick.z <= -0.5))
    //    {
    //        attack.z = oldRightStick.z;
    //    }

       

    //    //左スティック受付
    //    Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    //    dir = dir * speed;
    //    rb.velocity = dir;
    //    //rb.AddForce(dir);
        

    //    if(Input.GetAxis("Horizontal2") != 0 || Input.GetAxis("Vertical2") != 0)
    //    {
            
    //        Vector3 look = new Vector3(Input.GetAxis("Horizontal2"), 0, -Input.GetAxis("Vertical2"));
    //        Debug.Log(look);
    //        if(look.x >= 0.5f || look.x <= -0.5f && look.z >= 0.5f || look.z <= -0.5f)
    //        {
    //            oldVector = look;
    //        }

    //        look = transform.localPosition + look;
    //        transform.LookAt(look);

    //        //if(oldVector )

            
    //    }
    //}

    //// 攻撃処理
    //public void Attack()
    //{
    //    rightStick.x = Input.GetAxis("Horizontal2");
    //    rightStick.z = Input.GetAxis("Vertical2");
    //    // vertical2の値が反転していたため即席の修正、原因は時間があるときに
    //    rightStick.z = -rightStick.z;

    //    if ((((oldRightStick.x >= recoilRate) || (oldRightStick.x <= -recoilRate)) || ((oldRightStick.z >= recoilRate) || (oldRightStick.z <= -recoilRate))) &&
    //        (((rightStick.x <= recoilRate) && (rightStick.x >= -recoilRate)) && ((rightStick.z <= recoilRate) && (rightStick.z >= -recoilRate))))
    //    {
    //        var obj = GameObject.Instantiate(ball, position - new Vector3(oldRightStick.x * 5, 0, oldRightStick.z * 5), Quaternion.Euler(0, 0, 0));
    //        Throw();
    //        //var obj = GameObject.Instantiate(ball, position - new Vector3(attack.x * 5, 0, attack.z * 5), Quaternion.Euler(0, 0, 0));
    //    }

    //    Debug.Log("rightStick.x:" + rightStick.x + ", rightStick.z:" + rightStick.z);
    //}
}
