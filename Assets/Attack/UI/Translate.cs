using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour
{

    [SerializeField] Vector3 moveAmount = new Vector3(1000f, 0f, 0f);
    private float speed = 100f;

    public float duration = 1.0f; // Durée de l'interpolation en secondes

    private float elapsedTime = 0.0f; // Temps écoulé depuis le début de l'interpolation

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

        // Vérifiez si l'interpolation est terminée
        if (elapsedTime >= duration)
        {
            elapsedTime = duration; // Assurez-vous que le temps écoulé ne dépasse pas la durée
        }

        // Calculez le facteur d'interpolation en fonction du temps écoulé et de la durée
        float t = elapsedTime / duration;

        // Interpole la position de l'empty entre les Transform de départ et de destination
        spellToTranslate.position = Vector3.Lerp(startTransform.position, endTransform.position, t);
    }
}
