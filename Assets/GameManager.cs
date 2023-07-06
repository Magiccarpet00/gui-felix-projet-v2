using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Camera cam;

    public GameObject[] prefabElements;
    public List<Element> speelQueue = new List<Element>();

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.A))
        {
            AddElementsInSpellQueue(0);
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            AddElementsInSpellQueue(1);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            AddElementsInSpellQueue(2);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            AddElementsInSpellQueue(3);
        }

        
        if(Input.GetKeyUp(KeyCode.S))
        {
            ExecuteSpellQueue();
        }


    }

    public void AddElementsInSpellQueue(int i)
    {
        speelQueue.Add(prefabElements[i].GetComponent<Element>());
    }
    
    public void ExecuteSpellQueue()
    {
        foreach (Element element in speelQueue)
        {
            element.Cast();
        }
        speelQueue.Clear();
    }

    public Vector3 GetMousePos()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        Vector3 mousePos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        return mousePos;
    }

    
}
