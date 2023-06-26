using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    private float speed = 1;

    public float duration = 5f; // Durée de l'interpolation en secondes

    private float elapsedTime = 0f; // Temps écoulé depuis le début de l'interpolation

    public Transform test;
    public Transform démarrage;
    public Transform arrivée;
    // Start is called before the first frame update
    void Start()
    {
        //while (elapsedTime < duration)
        //{
        //    elapsedTime += Time.deltaTime;
        //    float percentageComplete = elapsedTime / duration;
        //    gameObject.transform.position = Vector3.Lerp(démarrage.position, arrivée.position, percentageComplete);
        //}
        

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(elapsedTime);
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / duration;
        gameObject.transform.position = Vector3.Lerp(démarrage.position, arrivée.position, percentageComplete);

    }
}
