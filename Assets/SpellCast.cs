using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCast : MonoBehaviour
{
    public Camera cam;
    
    public List<GameObject> spells = new List<GameObject>();


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //PROVISOIRE
            //il faudra regarder la range du speel
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            Vector3 mousePos = new Vector3(hit.point.x, transform.position.y, hit.point.z);

            GameObject spell =  Instantiate(spells[0], transform.position, Quaternion.identity);
            spell.GetComponent<Spell>().Cast(mousePos, this.gameObject);
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            //PROVISOIRE
            //il faudra regarder la range du speel
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            Vector3 mousePos = new Vector3(hit.point.x, transform.position.y, hit.point.z);

            Debug.DrawRay(cam.transform.position, mousePos- cam.transform.position, Color.red, 3f);

            GameObject spell = Instantiate(spells[1], transform.position, Quaternion.identity);
            spell.GetComponent<Spell>().Cast(mousePos, this.gameObject);
        }
    }
}
