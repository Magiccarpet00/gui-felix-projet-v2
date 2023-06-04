using UnityEngine;
using UnityEngine.AI;

public class PlayerDeplacement : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                agent.transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
                agent.SetDestination(hit.point);
                
            }

        }
    }
}
