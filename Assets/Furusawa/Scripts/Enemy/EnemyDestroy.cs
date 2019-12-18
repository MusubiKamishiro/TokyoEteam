using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    private void OnDestroy()
    {
        //transform.parent.GetComponent<EnemySpawn>().currentEnemyNum--;
        //transform.parent.GetComponent<GameDirector>().killCount++;
    }
}
