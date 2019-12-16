using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//アイテムの表示について
public class Item : MonoBehaviour
{
    [SerializeField,Tooltip("アイテムをどのくらい回転させるか")] Vector3 rotateSpeed;
    void Start()
    {
        
    }


    void Update()
    {

    }

    //処理回数一定
    private void FixedUpdate()
    {
        transform.Rotate(rotateSpeed);
    }
}
