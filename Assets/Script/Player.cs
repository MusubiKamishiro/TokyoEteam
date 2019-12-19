using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject muzzle;//古澤追加
    [SerializeField] ParticleSystem fx_bean;
    Rigidbody rb;
    public GameObject ball;
    // スティックの誤差
    public float recoilRate = 0.1f;

    private Vector3 position;
    private Quaternion rotate;
    // 右スティックの回転率
    private Vector3 rightStick;
    // 1フレーム前の右スティックの回転率
    private Vector3 oldRightStick;
    // 豆の攻撃方向
    private Vector3 attack;
    // 攻撃角度
    private float attackAngle = 0.2f;
    // 
    private float angle = 1;

    //サウンド
    public AudioClip ThrowSE;
    AudioSource audioSource1;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource1 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            angle += 1;
        }
        else if (Input.GetKey(KeyCode.L))
        {
            angle += -1;
        }
        //else
        //{
        //    angle = 0;
        //}

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
        Debug.Log(angle);
    }

    // 移動処理
    public void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // 左スティックの情報をもとにキャラの向きの変更と移動
        rb.velocity = new Vector3(x * 10, -3, z * 10);
        if ((x != 0) || (z != 0))
        {
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

        //if ((oldRightStick.z <= -recoilRate) && (rightStick.z >= -recoilRate))
        if (Input.GetButtonDown("Fire1"))
        {
            // ここに豆を投げる処理の追加
            //Throw();
            fx_bean.Play();
            audioSource1.PlayOneShot(ThrowSE);
        }

        Debug.Log("rightStick.x:" + rightStick.x + ", rightStick.z:" + rightStick.z);
    }

    //豆投げるyafusoさんのスクリプト移植
    void Throw()
    {
        for (int i = 0; i < 5; i++)
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
    // 攻撃範囲のゲッター
    public float GetAttackAngle
    {
        get
        {
            return attackAngle;
        }
    }
    // 回転情報のゲッター
    public float GetAngle
    {
        get
        {
            return angle;
        }
    }
}
