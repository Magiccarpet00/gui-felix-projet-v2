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

    public float duration = 1.0f; // Durée de l'interpolation en secondes
    private int upCount = 0 ;

    [SerializeField] float spellSpeed;

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
        GameObject[] instantiateSpells = new GameObject[childCount + 1];
        GameObject[] slots = new GameObject[]
        {
            Slot1,
            Slot2,
            Slot3,
            Slot4,
        };
        GameObject s = Instantiate(g, spellsFusionBar);
        if (upCount == 0)
        {
            s.transform.position = new Vector3(Slot1.transform.position.x, Slot1.transform.position.y, Slot1.transform.position.z);
            s.transform.rotation = g.gameObject.transform.rotation;
            upCount++;
        }
        else if(upCount > 0 && upCount < 4)
        {
            for (int i = upCount; i <= childCount; i++)
            {

                instantiateSpells[i] = spellsFusionBar.GetChild(i).gameObject;
                StartCoroutine(TranslationCoroutine(instantiateSpells[i].transform, slots[i-1].transform, slots[i].transform));

            }
            upCount++;
        }
        else if (upCount >= 4)
        {
          
            
        }

    }

    IEnumerator TranslationCoroutine (Transform spellToTranslate, Transform startTransform, Transform endTransform)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime * spellSpeed;
            float percentageComplete = elapsedTime / duration;
            spellToTranslate.position = Vector3.Lerp(startTransform.position, endTransform.position, percentageComplete);

            yield return null;
        }

    }

}
