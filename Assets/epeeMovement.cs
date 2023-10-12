using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class epeeMovement : MonoBehaviour
{
    public Vector3 epeeBougeDebut;
    public Vector3 epeeBougeFin;

   
    public float epeeSpeed = 2f;
    private CapsuleCollider epeeCollider;
    private PlayerDeplacement playerDeplacement;

    public bool blink;
    public bool epeeBlinked;
    public bool eppeDashed;
    public Rigidbody rb;
    private Vector3 forceToCancel;

    public Animator epeeAnimator;
    
    private bool idledroitRunning;
    private bool idlegaucheRunning;



    // Start is called before the first frame update
    void Start()
    {
       
        epeeCollider = GetComponent<CapsuleCollider>();
        epeeCollider.enabled = false;
        playerDeplacement = GameManager.instance.prefabPlayer.GetComponent<PlayerDeplacement>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        idledroitRunning = epeeAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle");
        idlegaucheRunning = epeeAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idlegauche");


        if (!idledroitRunning && !idlegaucheRunning)
        {
            playerDeplacement.enabled = false;
            playerDeplacement.agent.SetDestination(GameManager.instance.prefabPlayer.transform.position);
            
        }

        if (idledroitRunning || idlegaucheRunning)
        {
            playerDeplacement.enabled = true;
        }

        if (epeeBlinked == true || eppeDashed == true)
        {

            epeeCollider.enabled = true;
            //transform.rotation = new Quaternion(transform.rotation.x, Mathf.LerpAngle(0, 1080, GameManager.instance.elapsedTime * epeeSpeed),transform.rotation.z,transform.rotation.w);
            Quaternion rotation = Quaternion.AngleAxis(GameManager.instance.elapsedTime * epeeSpeed, Vector3.left);
            transform.rotation *= rotation;
        }

    }

    public void BlinkEpee(Vector3 newPos)
    {
        
        StartCoroutine(BlinkCoroutine(newPos));
    }

    public IEnumerator BlinkCoroutine(Vector3 newPos)
    {
        GameManager.instance.ResetElapsedTime();
        epeeBlinked = true;
        transform.SetParent(null);
        //GameManager.instance.epeeAnimator.SetTrigger("epeerotationblink");
        GameManager.instance.epeeAnimator.enabled = false;
        transform.position = newPos;
        //GameManager.instance.epeeAnimator.SetTrigger("rota");
        yield return new WaitForSeconds(3f);
        GameManager.instance.epeeAnimator.enabled = true;
        //GameManager.instance.epeeAnimator.SetBool("epeecoup",false);
        transform.SetParent(GameManager.instance.prefabPlayer.transform);
        epeeBlinked = false;
        //epeeCollider.enabled = false;
    }

    public void DashEpee(float dashTime, float spellLifeTime, float dashForce)
    {
        StartCoroutine(DashCoroutine(dashTime, spellLifeTime, dashForce));
    }

    public IEnumerator DashCoroutine(float dashTime, float spellLifeTime, float dashForce)
    {
        GameManager.instance.ResetElapsedTime();
        eppeDashed = true;
        GameManager.instance.epeeAnimator.enabled = false;
        rb.AddForce(GameManager.instance.prefabPlayer.transform.forward.normalized * dashForce, ForceMode.Impulse);
        transform.SetParent(null);
        yield return new WaitForSeconds(dashTime);
        StartCoroutine(SpellLifeTimeCoroutine(spellLifeTime));
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    public IEnumerator SpellLifeTimeCoroutine (float lifetime)
    {
        yield return new WaitForSeconds(lifetime);
        GameManager.instance.epeeAnimator.enabled = true;
        transform.SetParent(GameManager.instance.prefabPlayer.transform);
        eppeDashed = false;

    }

}




