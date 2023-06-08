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
    [SerializeField] float instantiatePositionx;
    [SerializeField] float instantiatePositiony;
    private int childCount;






    // Start is called before the first frame update



    void Start()
    {
        spellsFusionBar = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        childCount = spellsFusionBar.childCount;
        spellsFusionBar.position = new Vector3(player.position.x + spellsFusionBarPositionx, player.position.y + spellsFusionBarPositiony, player.position.z);
    }

    public void DisplaySpell(GameObject g)
    {
  
        GameObject s = Instantiate(g, spellsFusionBar);
        s.transform.position = new Vector3(spellsFusionBar.position.x + instantiatePositionx, spellsFusionBar.position.y + instantiatePositiony, spellsFusionBar.position.z);
        s.transform.rotation = g.gameObject.transform.rotation;
      

        GameObject[] instantiateSpells = new GameObject[childCount + 1];

        for (int i = 0; i < childCount; i++)
        {
  
            instantiateSpells[i] = spellsFusionBar.GetChild(i).gameObject;

            if (instantiateSpells[i].GetComponent<Translate>().enabled == false)
            {
                instantiateSpells[i].GetComponent<Translate>().enabled = true;

                StartCoroutine(TranslationCoroutineenabled(i));
            }

            IEnumerator TranslationCoroutineenabled(int i)
            {

                yield return new WaitForSeconds(0.2f);

                instantiateSpells[i].GetComponent<Translate>().enabled = false;

            }
            //else
            //{
            //    StartCoroutine(TranslationCoroutinedisabled(i));
            //}

            //Debug.Log(instantiateSpells[i]);
        }

        

        //IEnumerator TranslationCoroutinedisabled(int i)
        //{

        //    yield return new WaitForSeconds(1f);

        //    instantiateSpells[i].GetComponent<Translate>().enabled = false;

        //}
    }

 
}
