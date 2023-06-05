using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackProjectileTest : MonoBehaviour
{
    public GameObject shellPrefab;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            GameObject newProj = Instantiate(shellPrefab, transform.position, Quaternion.identity);
            newProj.GetComponent<Projectile>().SetUpProjectile(transform.forward, 15f, 1f);
            
        }
    }
}
