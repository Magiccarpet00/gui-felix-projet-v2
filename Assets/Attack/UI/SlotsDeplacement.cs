using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsDeplacement : MonoBehaviour
{
    private Transform spellsFusionBG;
    [SerializeField] float xOffset;
    [SerializeField] float yOffset;

    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        spellsFusionBG = GameObject.Find("SpellsFusionBG").transform;

    }

    // Update is called once per frame
    void Update()
    {
        float width = cam.pixelWidth;
        float height = cam.pixelHeight;

        transform.position = new Vector3(spellsFusionBG.position.x + xOffset * width, spellsFusionBG.position.y + yOffset * height, spellsFusionBG.position.z);
    }
}
