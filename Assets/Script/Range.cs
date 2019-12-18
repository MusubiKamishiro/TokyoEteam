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
        var mat = GetComponent<Renderer>().material;
        mat.SetFloat("_Threshold", player.GetComponent<Player>().GetAttackAngle);
    }

    private void LateUpdate()
    {
        transform.position = player.GetComponent<Player>().GetPosition;
        transform.rotation = player.GetComponent<Player>().GetQuaternion;
        transform.Rotate(0, 58, 0);
    }
}
