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


    public bool isPlayer;
    public bool bumped;
    public bool jumped;
    public bool blink;

    public Vector3 clicBuffer;

    private void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if (FreezeInput())
                {
                    clicBuffer = hit.point;
                }
                else
                {
                    agent.transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
                    agent.SetDestination(hit.point);
                }
            }
        }

        //float width = cam.pixelWidth;
        //float height = cam.pixelHeight;

        //Vector3 playerPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        //Vector2 playerScreenPosition = cam.WorldToScreenPoint(playerPosition);

        //spellFusionBar.rectTransform.position = new Vector2(playerScreenPosition.x + spellsFusionBarPositionx * width , playerScreenPosition.y + spellsFusionBarPositiony * height);



    }


    public bool FreezeInput()
    {
        if (!isPlayer) return true;
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

    public void Blink(float blinkTime, Vector3 newPos)
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

    //Methode qui sert à "retirer du jeux" un personage pendant un laps de temps
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
