using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void LateUpdate()
    {
        transform.position = player.GetComponent<Player>().GetPosition;
        transform.rotation = player.GetComponent<Player>().GetQuaternion;
    }
}
