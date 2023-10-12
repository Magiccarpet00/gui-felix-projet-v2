using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemySpellPlacement : MonoBehaviour
{
    public Rigidbody rbSpell;
    public Transform ownerEnnemy;
    public bool dash;
    public bool blink;
    private void Awake()
    {
        rbSpell = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (dash == false && blink == false && ownerEnnemy != null)
        {
            transform.position = ownerEnnemy.transform.position;
        }
    }

    public void DashSpell(float dashTime, float dashForce)
    {
        dash = true;
        rbSpell.AddForce(GameManager.instance.prefabEnemmy.transform.forward * dashForce, ForceMode.Impulse);
        StartCoroutine(dashCoroutine(dashTime));
    }

    public IEnumerator dashCoroutine(float dashTime)
    {

        yield return new WaitForSeconds(dashTime);
        rbSpell.velocity = Vector3.zero;

    }
}
