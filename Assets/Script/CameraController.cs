using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private float smoothing = 10.0f;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        var ppos = player.GetComponent<Player>().GetPosition;
        
        // カメラをターゲットに追従
        Vector3 targetCamPos = player.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, Time.deltaTime * smoothing);
        //transform.position = Vector3.Lerp(transform.position, ppos, Time.deltaTime * smoothing);
        //transform.RotateAround(ppos, Vector3.up, player.GetComponent<Player>().GetAngle);
        transform.eulerAngles = new Vector3(46.8f, player.GetComponent<Player>().GetAngle);
    }
}
