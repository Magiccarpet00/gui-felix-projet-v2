using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Camera cam;
    public Vector3 offSet;
    public Transform follow;



    public bool freezeCam;

    public float panSpeed;
    public float panBorder;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (freezeCam) freezeCam = false;
            else freezeCam = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 newPos = follow.position + offSet;
            cam.transform.position = newPos;
        }
        else
        {
            if (freezeCam)
                return;

            Vector3 pos = cam.transform.position;

            if (Input.mousePosition.y >= Screen.height - panBorder)
                pos.z += panSpeed * Time.deltaTime;

            if (Input.mousePosition.y <= panBorder)
                pos.z -= panSpeed * Time.deltaTime;

            if (Input.mousePosition.x >= Screen.width - panBorder)
                pos.x += panSpeed * Time.deltaTime;

            if (Input.mousePosition.x <= panBorder)
                pos.x -= panSpeed * Time.deltaTime;
            
            cam.transform.position = pos;
        }

    }
}
