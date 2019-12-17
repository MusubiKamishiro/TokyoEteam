using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Playerの発射代案
public class Shot : MonoBehaviour
{
    public enum State
    {
        ON,
        OFF
    }
    [SerializeField] State state = State.OFF;

    [SerializeField] int angle;

    private float x, z;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKey)
        //{

        //}

        
    }
}
