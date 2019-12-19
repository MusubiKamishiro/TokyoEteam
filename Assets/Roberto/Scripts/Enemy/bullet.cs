﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]
    float damage = 1;
    public Rigidbody rb;

    private void Start()
    {
        if(rb==null)
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 5);
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == StaticStrings.player)
        {
           PlayerStatus playerStatus = other.GetComponent<PlayerStatus>();
            if (playerStatus.invisibleFlag == false)
            {
                playerStatus.HitDamage(damage);

            }
            Destroy(gameObject);
        }
    }
}
