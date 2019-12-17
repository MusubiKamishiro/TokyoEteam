﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject muzzle;//古澤追加
    Rigidbody rb;
    public GameObject ball;
    // スティックの誤差
    public float recoilRate = 0.1f;
    public float a = 0;

    private Vector3 position;
    private Quaternion rotate;
    // 右スティックの回転率
    private Vector3 rightStick;
    // 1フレーム前の右スティックの回転率
    private Vector3 oldRightStick;
   // 豆の攻撃方向
    private Vector3 attack;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        rotate = transform.rotation;

        oldRightStick = rightStick;

        if ((oldRightStick.x >= 0.5) || (oldRightStick.x <= -0.5))
        {
            attack.x = oldRightStick.x;
        }
        if((oldRightStick.z >= 0.5) || (oldRightStick.z <= -0.5))
        {
            attack.z = oldRightStick.z;
        }

        Move();
        Attack();
    }

    // 移動処理
    public void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // 左スティックの情報をもとにキャラの向きの変更と移動
        if ((x != 0) || (z != 0))
        {
            //Vector3 move = new Vector3(0, 0, 0.1f);
            //transform.Translate(move);
            rb.velocity = new Vector3(x*10,0,z*10);

            Vector3 direction = new Vector3(x, 0, z);
            transform.localRotation = Quaternion.LookRotation(direction);
        }
    }

    // 攻撃処理
    public void Attack()
    {
        rightStick.x = Input.GetAxis("Horizontal2");
        rightStick.z = Input.GetAxis("Vertical2");
        // vertical2の値が反転していたため即席の修正、原因は時間があるときに
        rightStick.z = -rightStick.z;

        if((((oldRightStick.x >= recoilRate) || (oldRightStick.x <= -recoilRate)) || ((oldRightStick.z >= recoilRate) || (oldRightStick.z <= -recoilRate))) && 
            (((rightStick.x <= recoilRate) && (rightStick.x >= -recoilRate)) && ((rightStick.z <= recoilRate) && (rightStick.z >= -recoilRate))))
        {
            var obj = GameObject.Instantiate(ball, position - new Vector3(oldRightStick.x * 5, 0, oldRightStick.z * 5), Quaternion.Euler(0, 0, 0));
            Throw();
            //var obj = GameObject.Instantiate(ball, position - new Vector3(attack.x * 5, 0, attack.z * 5), Quaternion.Euler(0, 0, 0));
        }

        Debug.Log("rightStick.x:" + rightStick.x + ", rightStick.z:" + rightStick.z);
    }

    //豆投げるyafusoさんのスクリプト移植
    void Throw()
    {

        for(int i = 0; i < 5; i++)
        {
            Quaternion iden = Quaternion.identity;
            //Quaternion angle = Quaternion.Euler(Random.Range(-30, 30), 0, Random.Range(-30, 30)) + iden;
            Vector3 pos = muzzle.transform.position;
            pos.x += Random.Range(-1, 1);
            pos.z += Random.Range(-1, 1);
            var BeansInstance1 = Instantiate(ball, pos, Quaternion.identity);
            BeansInstance1.GetComponent<Rigidbody>().AddForce(muzzle.transform.forward * 800);

            Destroy(BeansInstance1, 30f);
        }


    }

    // 座標のゲッター
    public Vector3 GetPosition
    {
        get
        {
            return position;
        }
    }
    // 回転率のゲッター
    public Quaternion GetQuaternion
    {
        get
        {
            return rotate;
        }
    }
}
