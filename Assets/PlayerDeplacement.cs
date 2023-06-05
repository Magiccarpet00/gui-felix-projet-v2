using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class PlayerDeplacement : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public Rigidbody rb;

    public bool bumped;
    public bool jumped;


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

        if(Input.GetKey(KeyCode.J) && FreezeInput() == false)
        {
            Debug.Log("zizi");
            StartCoroutine(Jump(0.3f, 150f));
            agent.ResetPath();
        }
    }


    public bool FreezeInput()
    {
        if (bumped) return true;
        if (jumped) return true;

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

    public IEnumerator Jump(float jumpTime, float velocity)
    {
        jumped = true;
        Vector3 dirWithForce = Vector3.up * velocity;
        rb.AddForce(dirWithForce, ForceMode.Impulse);
        yield return new WaitForSeconds(jumpTime);
        rb.AddForce(-dirWithForce, ForceMode.Impulse);
        jumped = false;
    }


}
