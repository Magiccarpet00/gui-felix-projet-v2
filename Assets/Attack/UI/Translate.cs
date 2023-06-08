using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour
{

    [SerializeField] Vector3 moveAmount = new Vector3(10f, 0f, 0f);
    private float speed = 8f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       gameObject.transform.Translate(moveAmount * speed *  Time.deltaTime);
    }
}
