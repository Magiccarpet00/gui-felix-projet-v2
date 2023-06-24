using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour
{

    [SerializeField] Vector3 moveAmount = new Vector3(1000f, 0f, 0f);
    private float speed = 1;

    public float duration = 1.0f; // Durée de l'interpolation en secondes

    private float elapsedTime = 1.0f; // Temps écoulé depuis le début de l'interpolation

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
        float t = 0f;

        while(t < duration)
        { 
        t += Time.deltaTime;

        // Interpole la position de l'empty entre les Transform de départ et de destination
        Vector3 currentPosition = Vector3.Lerp(startTransform.position, endTransform.position, t / duration);
        spellToTranslate.position = currentPosition;
        }
    }
}
