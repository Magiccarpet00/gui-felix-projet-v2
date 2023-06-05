using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeplacementPointAndClick : MonoBehaviour
{
    public Camera cam; // Référence à la caméra
    public NavMeshAgent agent; // Référence à l'agent de navigation
    public LayerMask groundLayer; // Couche du sol
    //bool isSelected = false;
    bool rayCast;
    private Vector3 mousePosition;

    
    void Update()
    {

        mousePosition = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(mousePosition); // Crée un rayon à partir de la position de la souris
        RaycastHit hit;   // Variable pour stocker les informations sur l'intersection avec le sol
        rayCast = Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer);
        //agent.SetDestination(gameObject.transform.position);

        if (Input.GetMouseButtonDown(1))
        {
            if (rayCast)
            {
                //Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer); // Lance un rayon et vérifie s'il intersecte le sol
                agent.SetDestination(hit.point); // Définit la destination de l'agent de navigation sur le point d'intersection
            }
            else
            {
                agent.destination = gameObject.transform.localPosition;
            }
            // isSelected = true;
        }

        //if (Input.GetMouseButtonUp(0))
        //{
        //    isSelected = false;
        //    agent.destination = gameObject.transform.localPosition;
        //}

        //if (rayCast == false)
        //{
        //    agent.destination = gameObject.transform.localPosition;
        //}

        

        ////attack

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    fire.SetActive(true);

        //}

        //if (Input.GetKeyUp(KeyCode.A))
        //{
        //    fire.SetActive(false);
        //    Debug.Log("Attack");

        //}



    }
}

