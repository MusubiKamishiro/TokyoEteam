using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeansHit : MonoBehaviour
{
    void OnCollisionEnter(Collision coll){
        //if (coll.gameObject.tag == "Destroy")
        //{
        //    Destroy(this.gameObject, 3f);
        //}

        //古澤追加
        if (coll.gameObject.CompareTag("Enemy"))
        {
            //coll.gameObject.GetComponent<EnemyHealth>().takeDamage(1);
        }
        Destroy(gameObject, 3f);
    }

}
