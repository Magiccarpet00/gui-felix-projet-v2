using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    private float speed = 1;

    public float duration = 5f; // Dur�e de l'interpolation en secondes

    private float elapsedTime = 0f; // Temps �coul� depuis le d�but de l'interpolation

    public Transform test;
    public Transform d�marrage;
    public Transform arriv�e;
    // Start is called before the first frame update
    void Start()
    {
        //while (elapsedTime < duration)
        //{
        //    elapsedTime += Time.deltaTime;
        //    float percentageComplete = elapsedTime / duration;
        //    gameObject.transform.position = Vector3.Lerp(d�marrage.position, arriv�e.position, percentageComplete);
        //}
        

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(elapsedTime);
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / duration;
        gameObject.transform.position = Vector3.Lerp(d�marrage.position, arriv�e.position, percentageComplete);

    }
}
