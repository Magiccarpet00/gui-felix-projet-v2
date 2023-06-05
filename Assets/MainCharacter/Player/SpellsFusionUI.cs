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
    [SerializeField] float instantiatePositionx;
    [SerializeField] float instantiatePositiony;
    private Animator spellIconTranslation;

  

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

        if (transform.childCount > 0)
        {
            spellIconTranslation = GameObject.Find("Spell(Clone)").GetComponent<Animator>();
        }
    }

    public void DisplaySpell(GameObject g)
    {

        IEnumerator SpellMovementCoroutine() // Coroutine pour changement couleur bouton
        {
            // suspend execution for 2 seconds

            spellIconTranslation.SetTrigger("Translation");
            yield return new WaitForSeconds(1f);
            GameObject s = Instantiate(g);
            s.transform.position = new Vector3(spellsFusionBar.position.x + instantiatePositionx, spellsFusionBar.position.y + instantiatePositiony, spellsFusionBar.position.z);
            s.transform.rotation = g.gameObject.transform.rotation;
            s.transform.SetParent(spellsFusionBar);

        }   


        if (transform.childCount > 0)
        {
            StartCoroutine(SpellMovementCoroutine());
        }
        else 
        { 
        GameObject s = Instantiate(g);

        s.transform.position = new Vector3(spellsFusionBar.position.x + instantiatePositionx, spellsFusionBar.position. y + instantiatePositiony, spellsFusionBar.position.z);
        s.transform.rotation = g.gameObject.transform.rotation;
        s.transform.SetParent(spellsFusionBar);
        }


    }   


}
