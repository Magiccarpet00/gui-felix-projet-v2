using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellPlacement : MonoBehaviour
{
    public Rigidbody rbSpell;
    public bool dash;
    public bool blink;
    private void Awake()
    {
        rbSpell = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (dash == false && blink == false)
        {
            transform.position = GameManager.instance.prefabPlayer.transform.position;
            transform.rotation = GameManager.instance.prefabPlayer.transform.rotation;
        }
    }

    public void DashSpell(float dashTime, float dashForce)
    {
        dash = true;
        rbSpell.AddForce(GameManager.instance.prefabPlayer.transform.forward * dashForce, ForceMode.Impulse);
        StartCoroutine(dashCoroutine(dashTime));
    }

    public IEnumerator dashCoroutine(float dashTime)
    {
       
        yield return new WaitForSeconds(dashTime);
        rbSpell.velocity = Vector3.zero;
       
    }
}
