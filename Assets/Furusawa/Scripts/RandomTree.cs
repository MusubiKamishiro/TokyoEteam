using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//木を適当に配置
[ExecuteInEditMode]
public class RandomTree : MonoBehaviour
{
    [SerializeField] GameObject tree;
    [SerializeField] Vector3 pos;
    [SerializeField] int num;


    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            TreeSet();
        }
    }

    public void TreeSet()
    {
        for(int i = 0; i< num; i++)
        {
            pos.x = Random.Range(-pos.x, pos.x);
            pos.z = Random.Range(-pos.z, pos.z);
            Instantiate(tree, pos, Quaternion.Euler(0, Random.Range(0, 360), 0));
        }


    }

}
