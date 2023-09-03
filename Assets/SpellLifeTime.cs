using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpellLifeTime : MonoBehaviour
{
  

   

    public void SpellDie(float time)
    {
        StartCoroutine(SpellTime(time));
    }

    IEnumerator SpellTime(float time)
    {
       
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    
}
