using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class SpellZoneDisplay : MonoBehaviour
{
    public Sprite Cone;
    public Sprite Sphere;
    public Sprite Ray;
    public Sprite Allonge;

    private Image image;

    public string spellZone;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spellZone == "Sphere")
        {
            image.sprite = Sphere;
            image.preserveAspect = true;
        }
        else if (spellZone == "Cone")
        {
            image.sprite = Cone;
            image.preserveAspect = true;

        }
        else if (spellZone == "Ray")
        {
            image.sprite = Ray;
            image.preserveAspect = true;



        }
        else if (spellZone == "Allonge")
        {
            image.sprite = Allonge;
            image.preserveAspect = true;

        }
        else if (spellZone == "")
        {
            image.sprite = null;
            image.preserveAspect = true;

        }

    }
}
