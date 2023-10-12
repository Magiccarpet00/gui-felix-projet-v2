using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.UI;

public class PlayerDeplacement : MonoBehaviour
{
    public Character character;    

    public Camera cam;
    public NavMeshAgent agent;
    public Rigidbody rb;
    public Image spellFusionBar;
    [SerializeField] float spellsFusionBarPositionx;
    [SerializeField] float spellsFusionBarPositiony;


    public bool bumped;
    public bool jumped;
    public bool blink;
    public bool dash;
    public float dashForce;
    public Vector3 playerForward;


    public Vector3 clicBuffer;
    public bool isSlowed = false;
    public Vector3 hitClicked;
   


    Actions PLayerAction;

    private void Start()
    {
        PLayerAction = GetComponent<Actions>();
        
    }

    void Update()
    {
        playerForward = transform.forward;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;



    if(Physics.Raycast(ray, out hit))
    {
    agent.transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        if (Input.GetMouseButton(0))
        {
        hitClicked = hit.point;
        agent.SetDestination(hit.point);
        PLayerAction.Run();
        }

        if (transform.position.x - hitClicked.x == 0 && transform.position.z - hitClicked.z ==0)
        {
        PLayerAction.Stay();
        }
    }

    }


    public bool FreezeInput()
    {
        if (bumped) return true;
        if (jumped) return true;
        if (blink) return true;
        

        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CubeTest"))
        {
            Vector3 dir = transform.position - other.transform.position;
            _Bump(0.3f, 15f, dir);
            agent.ResetPath();
        }
    }

    public void _Bump(float bumpTime, float velocity, Vector3 direction)
    {
        StartCoroutine(Bump(bumpTime, velocity, direction));
    }

    public IEnumerator Bump(float bumpTime, float velocity, Vector3 direction)
    {
        bumped = true;

        agent.ResetPath();
        clicBuffer = Vector3.negativeInfinity;

        direction.y = 0;
        Vector3 dirWithForce = direction.normalized * velocity;
        Debug.Log(dirWithForce.magnitude);
        rb.AddForce(dirWithForce, ForceMode.Impulse);
        yield return new WaitForSeconds(bumpTime);
        rb.AddForce(-dirWithForce, ForceMode.Impulse);

        if (clicBuffer != Vector3.negativeInfinity)
            agent.SetDestination(clicBuffer);

        bumped = false;
    }

    public void BlinkPlayer(float blinkTime, Vector3 newPos)
    {
        StartCoroutine(BlinkCoroutine(blinkTime, newPos));
    }

    public IEnumerator BlinkCoroutine(float blinkTime, Vector3 newPos)
    {
        blink = true;
        agent.ResetPath();       
        character.model.SetActive(false);
        character.capsuleCollider.enabled = false;
        transform.position = newPos;
        yield return new WaitForSeconds(blinkTime);
        character.model.SetActive(true);
        character.capsuleCollider.enabled = true;
        blink = false;
    }

    public void DashPlayer(float dashTime)
    {
        agent.ResetPath();
        rb.AddForce(transform.forward * dashForce, ForceMode.Impulse);
        StartCoroutine(dashCoroutine(dashTime));
    }

    public IEnumerator dashCoroutine(float dashTime)
    {
        dash = true;
        yield return new WaitForSeconds(dashTime);
        rb.velocity = Vector3.zero;
        dash = false;
    }

    public void slowPlayerDeplacement()
    {

    }

    public void slowDeplacement(float spellValue, float spellTime)
    {
        if(isSlowed == false)
        {
            StartCoroutine(ReducePlayerSpeed(spellValue, spellTime));
        }
    }

    IEnumerator ReducePlayerSpeed(float spellValue, float time)
    {
        agent.speed = agent.speed - spellValue;
        isSlowed = true;

            yield return new WaitForSeconds(time);

        agent.speed = agent.speed + spellValue;
        isSlowed = false;

    }


    public IEnumerator Exil(float time)
    {
        
        character.model.SetActive(false);
        character.capsuleCollider.enabled = false;
        character.navMeshAgent.enabled = false;
        yield return new WaitForSeconds(time);
        character.model.SetActive(true);
        character.capsuleCollider.enabled = true;
        character.navMeshAgent.enabled = true;
    }

}
