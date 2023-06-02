using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvaRotation : MonoBehaviour
{
    private Transform healthBar;
    [SerializeField] float healthBarPosition;
    [SerializeField] Transform player;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.position = new Vector3(player.position.x, player.position.y + healthBarPosition, player.position.z) ;
    }
}
