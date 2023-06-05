using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellsFusionUI : MonoBehaviour
{
    private Transform spellsFusionBar;
    [SerializeField] float spellsFusionBarPositiony;
    [SerializeField] float spellsFusionBarPositionx;
    [SerializeField] Transform player;
    [SerializeField] GameObject spell;
    [SerializeField] float instantiatePosition;



    // Start is called before the first frame update
    void Start()
    {
        spellsFusionBar = GetComponent<Transform>();

        //DisplaySpell(spell);


    }

    // Update is called once per frame
    void Update()
    {
        spellsFusionBar.position = new Vector3(player.position.x + spellsFusionBarPositionx, player.position.y + spellsFusionBarPositiony, player.position.z);
      
    }

    public void DisplaySpell(GameObject g)
    {
        GameObject s = Instantiate(g);

        s.transform.position = new Vector3(g.transform.position.x + instantiatePosition, g.transform.position.y , player.position.z);
        s.transform.rotation = g.transform.rotation;
        s.transform.SetParent(g.transform.parent);  


    }   


}
