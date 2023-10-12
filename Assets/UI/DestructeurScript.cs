using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructeurScript : MonoBehaviour
{
    private Transform spellsFusionBar;
    public float xOffset;


    private void Start()
    {
        spellsFusionBar = GameObject.Find("SpellsFusionBG").transform;
    }
    private void Update()
    {
        gameObject.transform.position = new Vector3(spellsFusionBar.position.x + xOffset , spellsFusionBar.position.y, spellsFusionBar.position.z);
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpellToDestroy"))
        {
            Destroy(other.gameObject);
        }
        
    }
}
