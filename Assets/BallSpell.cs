using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpell : MonoBehaviour
{
    public float speed = 7;

    Vector3 mousPosLocalPlayer;

    // Start is called before the first frame update
    void Start()
    {
        mousPosLocalPlayer = GameManager.instance.GetMousePosLocal(transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.Normalize(mousPosLocalPlayer) * speed * Time.deltaTime);
        
    }

    public void Setup()
    {
       
    }

}
