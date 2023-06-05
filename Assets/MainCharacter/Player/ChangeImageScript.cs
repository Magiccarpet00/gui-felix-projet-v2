using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageScript : MonoBehaviour
{
    public Image imageComponent;
    public Button button1;
    private Sprite newSprite;

    // Start is called before the first frame update
    void Start()
    {
        imageComponent = GetComponent<Image>();
        newSprite = button1.GetComponent<Image>().sprite;
        ChangeImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeImage()

    {
        // Vérifier si le composant Image existe
        if (imageComponent != null)
        {
            // Changer la sprite du composant Image
            imageComponent.sprite = newSprite;
        }
        else
        {
            Debug.LogError("Le composant Image n'est pas référencé !");
        }
    }
}
