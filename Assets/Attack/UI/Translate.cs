using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour
{

    [SerializeField] Vector3 moveAmount = new Vector3(1000f, 0f, 0f);
    private float speed = 1;

    public float duration = 1.0f; // Dur�e de l'interpolation en secondes

    private float elapsedTime = 1.0f; // Temps �coul� depuis le d�but de l'interpolation

    public Transform test;
    public Transform d�marrage;
    public Transform arriv�e;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Translation(test, d�marrage, arriv�e);

    

    }

    public void Translation(Transform spellToTranslate, Transform startTransform, Transform endTransform)
    {
        float elapsedTime = 0f;

        while(elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / duration;
            spellToTranslate.position = Vector3.Lerp(startTransform.position, endTransform.position, percentageComplete);
        }
    }
}
