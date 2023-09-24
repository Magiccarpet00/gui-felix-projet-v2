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

    public Animator epeeAnimator;
    
    private bool idledroitRunning;
    private bool idlegaucheRunning;



    // Start is called before the first frame update
    void Start()
    {
       
        epeeCollider = GetComponent<CapsuleCollider>();
        epeeCollider.enabled = false;
        playerDeplacement = GameManager.instance.prefabPlayer.GetComponent<PlayerDeplacement>();


    }

    // Update is called once per frame
    void Update()
    {
        idledroitRunning = epeeAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle");
        idlegaucheRunning = epeeAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idlegauche");


        if (!idledroitRunning && !idlegaucheRunning) //&& epeeBlinked == false)
        {
            playerDeplacement.enabled = false;
            epeeCollider.enabled = true;
            playerDeplacement.agent.SetDestination(GameManager.instance.prefabPlayer.transform.position);
            
        }

        if (idledroitRunning || idlegaucheRunning)
        {
            epeeCollider.enabled = false;
            playerDeplacement.enabled = true;
        }

        if (epeeBlinked == true)
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
        epeeCollider.enabled = true;
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

}




