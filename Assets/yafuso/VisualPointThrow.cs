using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualPointThrow : MonoBehaviour
{
    [SerializeField]
    private Texture2D cursor;
    [SerializeField]
    private GameObject BeansPrefab;
    //[SerializeField]
    //private Transform LaunchPort;

    [SerializeField] private Transform LP1;
    [SerializeField] private Transform LP2;
    [SerializeField] private Transform LP3;
    [SerializeField] private Transform LP4;

    [SerializeField]
    private float BeansPower = 300f;

    private float delta;

    void Start()
    {
        Cursor.SetCursor(cursor, new Vector2(cursor.width / 2, cursor.height / 2), CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //　射程を合わせてAキーを押したら、豆を投げる
        
            if (Input.GetKeyDown(KeyCode.A))
            {
            if (delta >= 0.85f){
                    delta = 0.0f;
                    //Debug.Log("A");
                    Throw();
                }
            }
    }
    void Throw()
    {

        var BeansInstance1 = Instantiate<GameObject>(BeansPrefab, LP1.position,LP1.rotation);
        BeansInstance1.GetComponent<Rigidbody>().AddForce(BeansInstance1.transform.forward * BeansPower);

        var BeansInstance2 = Instantiate<GameObject>(BeansPrefab, LP2.position, LP2.rotation);
        BeansInstance2.GetComponent<Rigidbody>().AddForce(BeansInstance2.transform.forward * BeansPower);

        var BeansInstance3 = Instantiate<GameObject>(BeansPrefab, LP3.position, LP3.rotation);
        BeansInstance3.GetComponent<Rigidbody>().AddForce(BeansInstance3.transform.forward * BeansPower);

        var BeansInstance4 = Instantiate<GameObject>(BeansPrefab, LP4.position, LP4.rotation);
        BeansInstance4.GetComponent<Rigidbody>().AddForce(BeansInstance4.transform.forward * BeansPower);

        Destroy(BeansInstance1, 30f);
        Destroy(BeansInstance2, 30f);
        Destroy(BeansInstance3, 30f);
        Destroy(BeansInstance4, 30f);

    }
}
