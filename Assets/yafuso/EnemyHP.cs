using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] //敵のMaxHP
    private int MaxHP = 10;
    //敵のHP
    private int hp;

    void Start()
    {
        hp = MaxHP;
    }


    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Beans")
        {
            hp -= 1;
            Debug.Log(hp);
        }
    }

        // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            Destroy(this.gameObject, 5f);
        }
    }
}
