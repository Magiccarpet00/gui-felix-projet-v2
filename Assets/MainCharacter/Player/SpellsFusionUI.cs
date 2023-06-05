using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellsFusionUI : MonoBehaviour
{
    private Transform spellsFusionBar;
    [SerializeField] float spellsFusionBarPositiony;
    [SerializeField] float spellsFusionBarPositionx;
    [SerializeField] Transform player;

    // Start is called before the first frame update
    void Start()
    {
        spellsFusionBar = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        spellsFusionBar.position = new Vector3(player.position.x + spellsFusionBarPositionx, player.position.y + spellsFusionBarPositiony, player.position.z);
      
    }

    
}
