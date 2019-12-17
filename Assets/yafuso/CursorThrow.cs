using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorThrow : MonoBehaviour
{
    [SerializeField]
    private Texture2D cursor;
    public GameObject Sphere;

    void Start()
    {
        Cursor.SetCursor(cursor, new Vector2(cursor.width / 2, cursor.height / 2), CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A");
            //Instantiate(Sphere);
            Throw();
        }
    }
    void Throw()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Enemy")))
        {
            Destroy(hit.collider.gameObject);
        }

    }
}
