using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    public Transform roof = null;
    //攻撃力など、ボスの様々値が入っているクラス
    [SerializeField]
    EnemyStatus state=null;
    //ステップの管理
    List<BossPhase> phases = new List<BossPhase>();
    BossPhase currentPhase;
    int phaseIndex = 0;
    //
    NavMeshAgent ag;
    Animator anim;
    Player p;
    Weapon w;
    //minons
    [SerializeField]
    GameObject enemyToSpawn = null;
    //teleport
    Vector3 startPos=Vector3.zero;
    ParticleSystem smoke = null;
    bool isDead = false;
    Weapon wp = null;
    EnemyHealth health;
    void Start()
    {
        anim = GetComponent<Animator>();
        ag = GetComponent<NavMeshAgent>();
        p = FindObjectOfType<Player>();
        w = GetComponentInChildren<Weapon>();
        health = GetComponent<EnemyHealth>();
        //バトルはステップに別れています、リストのなかでステップを作る
        BossPhase phase1 = new Phase1(ag, anim, state, w, p,transform,this);
        BossPhase phase2 = new Phase2(ag, anim, state, w, p,transform,this);
        BossPhase phase3 = new Phase3(ag, anim, state, w, p,transform,this);
        phases.Add(phase1);
        phases.Add(phase2);
        phases.Add(phase3);
        startPos = transform.position;
        smoke = GetComponentInChildren<ParticleSystem>();
        if(roof==null)
        roof = GameObject.FindGameObjectWithTag(StaticStrings.roof).transform;
        currentPhase = phases[phaseIndex];
        currentPhase.EnterState();
        wp = GetComponentInChildren<Weapon>();
        
    }

   
    void Update()
    {
        if (isDead) return;
        //現在スペップのUpdate
        currentPhase.Updating();
        updateAnimator();
       
    }
    void updateAnimator()
    {
        anim.SetFloat(StaticStrings.move, ag.velocity.magnitude);
    }
    //次のステップへ行く、もし最後のステップだったら死ぬ
    public void goToNextPhase()
    {
        
        //まずは現在のステップから出ます
        currentPhase.ExitState();
        phaseIndex++;
        if (phaseIndex >= phases.Count)
        {
            Death();
        }
        else
        {
            
            currentPhase = phases[phaseIndex];
            //ステップに入る
            currentPhase.EnterState();
            restoreHealth();
        }
    }
    #region spells
    public void teleport()
    {
        if (smoke != null)
        {
            smoke.Play();
        }
        transform.position = startPos;
    }
    public void SpawnMinion()
    {
        for(int i = 0; i < 4; i++)
        {
            Vector3 spawnPos;
            float x=0, z=0;
            switch (i)
            {
                case 0: x = 2;z = 2; break;
                case 1:x = -2;z = -2; break;
                case 2: x=4; z = 4; break;
                case 3: x = -4; z = -4; break;
                case 4: x = -6; z = -6; break;
 
            }
            spawnPos = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
            
            
            Instantiate(enemyToSpawn, spawnPos, transform.rotation);
        }
    }
    #endregion
     void restoreHealth()
    {
        health.respawn();
    }
    public void weaponAttack(int v)
    {
        if (wp == null) { return; }
        wp.attack(v);
    }
    private void Death()
    {
        isDead = true;
        Destroy(gameObject);
    }
}
