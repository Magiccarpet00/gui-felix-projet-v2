using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Camera cam;

    private void Awake()
    {
        instance = this;
    }

    public Vector3 GetMousePos()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        Vector3 mousePos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        return mousePos;
    }

}
