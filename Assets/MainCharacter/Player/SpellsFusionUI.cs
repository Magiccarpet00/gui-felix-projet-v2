using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellsFusionUI : MonoBehaviour
{
    private Transform spellsFusionBar;
    private RectTransform spellsFusionBarRect;
  
    
    [SerializeField] float instantiatePositionx;
    [SerializeField] float instantiatePositiony;
    [SerializeField] GameObject Slot1;
    [SerializeField] GameObject Slot2;
    [SerializeField] GameObject Slot3;
    [SerializeField] GameObject Slot4;
    private int childCount;

    public Translate translateScript;

    [SerializeField] Transform playerTransform;
    public Camera cam;
    [SerializeField] float xOffset;
    [SerializeField] float yOffset;

    GameObject[] tableau;

    // Start is called before the first frame update



    void Start()
    {
        spellsFusionBar = GetComponent<Transform>();
        //spellsFusionBarRect = GetComponent<RectTransform>();


    }

    // Update is called once per frame
    void Update()
    {
        childCount = spellsFusionBar.childCount; //comptage du nombre d'enfants
        

        float width = cam.pixelWidth; // Permet d'ajuster la position de la barre au format de la caméra
        float height = cam.pixelHeight;

        Vector3 screenPosition = cam.WorldToScreenPoint(playerTransform.position); // récupère la position du player sur l'écran de la caméra
        transform.position = new Vector3(screenPosition.x + xOffset * width, screenPosition.y + yOffset * height, screenPosition.z); // place la barre des sorts sur le player

    }

    public void DisplaySpell(GameObject g)
    {

        GameObject s = Instantiate(g, spellsFusionBar);
        //s.transform.position = new Vector3(spellsFusionBar.position.x + instantiatePositionx, spellsFusionBar.position.y + instantiatePositiony, spellsFusionBar.position.z);
        //s.transform.rotation = g.gameObject.transform.rotation;


        GameObject[] instantiateSpells = new GameObject[childCount + 1];
        GameObject[] slots = new GameObject[]
        {
            Slot1,
            Slot2,
            Slot3,
            Slot4,
        };


        for (int i = 0; i <= childCount; i++)
        {
            
                instantiateSpells[i] = spellsFusionBar.GetChild(i).gameObject;
                translateScript.Translation(instantiateSpells[i].transform, slots[i].transform, slots[i + 1].transform);
            


            

                //if (instantiateSpells[i].GetComponent<Translate>().enabled == false)
                //{
                //    instantiateSpells[i].GetComponent<Translate>().enabled = true;

                //    StartCoroutine(TranslationCoroutineenabled(i));
                //}
                

                //IEnumerator TranslationCoroutineenabled(int i)
                //{
                //yield return new WaitForSeconds(0.2f);

                //    instantiateSpells[i].GetComponent<Translate>().enabled = false;

                //    for (int j = 4; j < childCount; j++)
                //    {
                //    Destroy(instantiateSpells[j - 4]);
                //    }
   
                //}
 
        }
        Debug.Log(instantiateSpells[0]);    

    }

 
}
