using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    void Start()
    {
        
    }


    void Update()
    {
        //とりあえずここに書く。内側の最大値と外側の最大値の間でランダム
        var pos1 = Random.Range(5, 7);

        var angle = Random.Range(0, 360);
        var rad = angle * Mathf.Deg2Rad;
        var px = Mathf.Cos(rad) * pos1 + player.transform.position.x;
        var py = Mathf.Sin(rad) * pos1 + player.transform.position.z;
        Vector3 re = new Vector3(px, 0, py);
        Instantiate(enemy, re, Quaternion.identity);
    }
}
