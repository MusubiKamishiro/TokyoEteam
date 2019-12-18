using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Phase2 :BossPhase
{
    public Phase2(NavMeshAgent ag, Animator an, EnemyStatus sta, Weapon w, Player p, Transform t,Boss b) : base(ag, an, sta, w, p,t,b)
    {

    }

    public override void EnterState()
    {

        boss.SpawnMinion();
        boss.teleport();
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }
    public override void Updating()
    {
        base.Updating();
        attackCounter -= Time.deltaTime;
        if (attackCounter <= 0)
        {

        }
    }
}
