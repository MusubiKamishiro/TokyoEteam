using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    Player p;
    private void Start()
    {
        p = FindObjectOfType<Player>();
    }
    public void shoot()
    {
        if (p == null) { return; }
        Debug.Log("SHOOT");   
    }
}
