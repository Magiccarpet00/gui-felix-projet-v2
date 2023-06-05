using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class PlayerDeplacement : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public Rigidbody rb;

    public bool bumped;


    void Update()
    {
        if(Input.GetMouseButtonDown(1) && FreezeInput() == false)
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


    public bool FreezeInput()
    {
        if (bumped) return true;


        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CubeTest"))
        {
            Vector3 dir = transform.position - other.transform.position;
            dir.Normalize();
            StartCoroutine(Bump(0.3f, 15f, dir));
            agent.ResetPath();
        }
    }

    public IEnumerator Bump(float bumpTime, float velocity, Vector3 direction)
    {
        bumped = true;
        Vector3 dirWithForce = direction * velocity; 
        rb.AddForce(dirWithForce, ForceMode.Impulse);
        yield return new WaitForSeconds(bumpTime);
        rb.AddForce(-dirWithForce, ForceMode.Impulse);
        bumped = false;
    }


}
