using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveFuru : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        dir = dir * 5;
        rb.velocity = dir;
    }
}
