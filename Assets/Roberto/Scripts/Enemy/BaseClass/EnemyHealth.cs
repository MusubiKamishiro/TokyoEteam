using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    protected float maxHelath = 10;
    protected float healt = 0;
    protected bool isDeath;
    protected Animator anim;

    void Start()
    {
        INIT();
    }

    public virtual void INIT()
    {
        healt = maxHelath;
        anim = GetComponent<Animator>();
    }
    public void respawn()
    {
        healt = maxHelath;
        isDeath = false;
    }
  public virtual void takeDamage(float damage)
    {
        if (isDeath) { return; }
        healt -= damage;
        
        if (healt <= 0)
        {
            isDeath = true;
            NavMeshAgent ag = GetComponent<NavMeshAgent>();
            if (ag != null)
                ag.SetDestination(transform.position);
            GetComponent<Animator>().SetTrigger(StaticStrings.death);
            Destroy(gameObject,3);
        }
        else
        {
            //random
            int rnd = Random.Range(0, 11);
            if (rnd > 8)
            {
                if (anim != null)
                    anim.SetTrigger(StaticStrings.hurt);
            }
        }

    }
}
