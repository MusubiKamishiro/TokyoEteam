using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class EffectDamage : MonoBehaviour
{
    [SerializeField] GameObject fx;
    [SerializeField] GameDirector gameDirector;
    void OnParticleCollision(GameObject obj)
    {
        if (obj.CompareTag("Enemy"))
        {
            obj.GetComponent<EnemyHealth>().takeDamage(1);
            gameDirector.CountCombo();
            GameObject ins = Instantiate(fx,obj.transform.position,Quaternion.identity);
            //Destroy(fx, 2);
            //Destroy(gameObject);
        }

    }

}
