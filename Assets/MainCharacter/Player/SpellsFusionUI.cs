using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellsFusionUI : MonoBehaviour
{
    private Transform spellsFusionBar;
    private Transform spellsFusionBarRect;


    [SerializeField] float instantiatePositionx;
    [SerializeField] float instantiatePositiony;
    [SerializeField] GameObject Slot1;
    [SerializeField] GameObject Slot2;
    [SerializeField] GameObject Slot3;
    [SerializeField] GameObject Slot4;
    public int childCount;

    [SerializeField] Transform playerTransform;
    public Camera cam;
    [SerializeField] float xOffset;
    [SerializeField] float yOffset;

    public float duration = 1.0f; // Durée de l'interpolation en secondes
    private int upCount = 0;

    [SerializeField] float spellSpeed;

    Image BGImage;

 
   

    // Start is called before the first frame update



    void Start()
    {
        spellsFusionBar = GetComponent<Transform>();
        BGImage = gameObject.GetComponent<Image>();
        spellsFusionBarRect = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {

        float width = cam.pixelWidth; // Permet d'ajuster la position de la barre au format de la caméra
        float height = cam.pixelHeight;

        Vector3 screenPosition = cam.WorldToScreenPoint(playerTransform.position); // récupère la position du player sur l'écran de la caméra
        transform.position = new Vector3(screenPosition.x + xOffset * width, screenPosition.y + yOffset * height, screenPosition.z); // place la barre des sorts sur le player

        childCount = spellsFusionBar.childCount; //comptage du nombre d'enfants


    }

    public void ResetSpellBar()
    {
        foreach (Transform child in spellsFusionBarRect) // destroy les spell dans le BGFusion
        {
            GameObject.Destroy(child.gameObject);
            upCount = 0;
            BGImage.color = Color.white;
        }
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
        
        if (upCount == 0)
        {
            GameObject s = Instantiate(g, spellsFusionBar);
            s.transform.position = new Vector3(Slot1.transform.position.x, Slot1.transform.position.y, Slot1.transform.position.z);
            s.transform.rotation = g.gameObject.transform.rotation;

            BGImage.color = Color.green; //gestion des couleur du BG

            upCount++;
        }
        else if (upCount > 0 && upCount < 4)
        {
            Instantiate(g, spellsFusionBar);
            for (int i = upCount; i <= childCount; i++)
            {
               
                instantiateSpells[i] = spellsFusionBar.GetChild(i).gameObject;
                StartCoroutine(TranslationCoroutine(instantiateSpells[i].transform, slots[i - 1].transform, slots[i].transform));

            }
            upCount++;

            //gestion des couleur du BG

            if (upCount > 1)
            {
                BGImage.color = Color.yellow;
            }

            if (upCount > 2)
            {
                BGImage.color = new Color(1f, 0.5f, 0f);
            }

            if (upCount > 3)
            {
                BGImage.color = Color.red;
            }

        }
       

        IEnumerator TranslationCoroutine(Transform spellToTranslate, Transform startTransform, Transform endTransform)
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
}
