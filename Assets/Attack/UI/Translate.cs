using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour
{

    [SerializeField] Vector3 moveAmount = new Vector3(1000f, 0f, 0f);
    private float speed = 100f;

    public float duration = 1.0f; // Dur�e de l'interpolation en secondes

    private float elapsedTime = 0.0f; // Temps �coul� depuis le d�but de l'interpolation

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       gameObject.transform.Translate(moveAmount * speed *  Time.deltaTime);

        
    }

    public void Translation(Transform spellToTranslate, Transform startTransform, Transform endTransform)
    {
        elapsedTime += Time.deltaTime;

        // V�rifiez si l'interpolation est termin�e
        if (elapsedTime >= duration)
        {
            elapsedTime = duration; // Assurez-vous que le temps �coul� ne d�passe pas la dur�e
        }

        // Calculez le facteur d'interpolation en fonction du temps �coul� et de la dur�e
        float t = elapsedTime / duration;

        // Interpole la position de l'empty entre les Transform de d�part et de destination
        spellToTranslate.position = Vector3.Lerp(startTransform.position, endTransform.position, t);
    }
}
