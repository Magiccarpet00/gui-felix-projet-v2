using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellPlacement : MonoBehaviour
{
    private void Update()
    {
       
        transform.position = GameManager.instance.prefabPlayer.transform.position;
        //transform.rotation = GameManager.instance.prefabPlayer.transform.rotation;
      

    }
}
