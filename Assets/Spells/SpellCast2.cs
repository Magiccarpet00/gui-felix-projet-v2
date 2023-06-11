using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCast2 : MonoBehaviour
{
    public Camera cam;
    public List<GameObject> spells = new List<GameObject>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
            Vector3 mousePos = GameManager.instance.GetMousePos();

            if(spells[0].GetComponent<Spell2>().isInRange(transform.position, mousePos))
            {
                GameObject spell = Instantiate(spells[0], transform.position, Quaternion.identity);
                spells[0].GetComponent<Spell2>().SendSetting(mousePos, this.gameObject);
                spells[0].GetComponent<Spell2>().Load();
            }
            
            
        }
    }
}
