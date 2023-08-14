using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Camera cam;

    public GameObject[] prefabElements;
   

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {

       
    }


    public Vector3 GetMousePosWorld(Transform transform)
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        Vector3 mousePos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        return mousePos;
    }

    public Vector3 GetMousePosLocal(Transform transform)
    {
        Vector3 mousePosWorld = GetMousePosWorld(transform);

        // �tape 1 : Inversion de la translation
        Vector3 vectorLocalNonTranslate = mousePosWorld - transform.position;

         //�tape 2 : Inversion de la rotation
        Quaternion rotationInverse = Quaternion.Inverse(transform.rotation);
        Vector3 vectorLocalNonRotate = rotationInverse * vectorLocalNonTranslate;

         //�tape 3 : Inversion de l'�chelle
        Vector3 vectorLocalFinal = new Vector3(
            vectorLocalNonRotate.x / transform.localScale.x,
            vectorLocalNonRotate.y / transform.transform.localScale.y,
            vectorLocalNonRotate.z / transform.transform.localScale.z);

        return vectorLocalFinal; 
    }
 
    
}
