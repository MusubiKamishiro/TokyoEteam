using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyHealth : MonoBehaviour
{
    //古澤追加
    [SerializeField] GameObject fx;
    Rigidbody rb;
    [SerializeField] float power;
    GameDirector gd;
    EnemySpawn es;

    [SerializeField]
    protected float maxHelath = 10;
    protected float healt = 0;
    protected bool isDeath;
    protected Animator anim;
    bool isInvincible = false;
    [SerializeField]
    float invinibleCounter = 5;
    float invincibleTime = 5;

    // サウンド
    public AudioClip BombSE;
    public AudioClip FlySE;
    public AudioClip AttackSE;
    AudioSource audioSource2;
    AudioSource audioSource3;
    AudioSource audioSource4;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        INIT();

        es = transform.parent.GetComponent<EnemySpawn>();
        gd = transform.parent.GetComponent<GameDirector>();

        audioSource2 = GetComponent<AudioSource>();
        audioSource3 = GetComponent<AudioSource>();
        audioSource4 = GetComponent<AudioSource>();
    }

    public virtual void INIT()
    {
        healt = maxHelath;
        anim = GetComponent<Animator>();
    }
    public void becomeInvincible()
    {
        isInvincible = true;
    }
    private void Update()
    {
        if (isInvincible)
        {
            invincibleTime -= Time.deltaTime;
            if (invincibleTime <= 0)
            {
                isInvincible = false;
                invincibleTime = invinibleCounter;
            }
        }
    }
    public void respawn()
    {
        healt = maxHelath;
        isDeath = false;
    }
  public virtual void takeDamage(float damage)
    {

        if (isDeath||isInvincible) { return; }
        healt -= damage;

        
        if (healt <= 0)
        {
            isDeath = true;
            NavMeshAgent ag = GetComponent<NavMeshAgent>();
            audioSource2.PlayOneShot(BombSE);
            if (ag != null)
                ag.SetDestination(transform.position);
            audioSource3.PlayOneShot(FlySE);
            GetComponent<Animator>().SetTrigger(StaticStrings.death);
            Destroy(gameObject,3);

            Instantiate(fx,transform.position + new Vector3(0,1,0),Quaternion.identity);
            rb.isKinematic = false;
            ag.enabled = false;
            Destroy(GetComponent<Enemy>());
            rb.AddForce(new Vector3(Random.Range(-power,power), power-200, Random.Range(-power, power)));
            es.currentEnemyNum--;
            gd.killCount++;


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
