using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEffect : MonoBehaviour
{
    public float domage;
    public float time;

    public void SetUp(float d, float t)
    {
        domage = d;
        time = t;

        StartCoroutine(LifeTime());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<Character>().TakeDamage(domage);
        }
    }

    public IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }

}
