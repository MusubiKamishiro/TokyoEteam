using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeansHit : MonoBehaviour
{
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Destroy"){
            Destroy(this.gameObject, 3f);
        }
    }
}
