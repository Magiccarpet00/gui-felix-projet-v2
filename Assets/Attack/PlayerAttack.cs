using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public float attackDamage = 10f; // Dégâts infligés par l'attaque
    
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;

    public GameObject anim1;
    public GameObject anim2;
    public GameObject anim3;
    public GameObject anim4;
    public GameObject anim5;


    public int spellIDButton;
    [SerializeField] SpellsUI spellUI;
    [SerializeField] SpellsFusionUI spellFusionUI;
    [SerializeField] BuildManagerScript buildManagerScript;

    private SpellsFusionUI displaySpell;
    private LayerMask enemyLayer; // Couche des ennemis

    


   

    public GameObject prefabSpell;



    private void Start()
    {
        displaySpell = GameObject.Find("SpellsFusionBG").GetComponent<SpellsFusionUI>();
       

    }

    private void Update()
    {
        if (spellFusionUI.childCount < 4)
            {

            if (Input.GetKeyDown(KeyCode.A)) //attaque 1
            {
                GameObject targetImage1;
                targetImage1 = GameObject.Find("TargetImage1");

                anim1.SetActive(true);
                PressButtonColorChange(button1);


                CastSpell(targetImage1,spellUI.spellBuildActif[0]);

            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                anim1.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Z)) // attaque 2 
            {
                GameObject targetImage2;
                targetImage2 = GameObject.Find("TargetImage2");

                anim2.SetActive(true);
                PressButtonColorChange(button2);
                CastSpell(targetImage2, spellUI.spellBuildActif[1]);
            }

            if (Input.GetKeyUp(KeyCode.Z))
            {
                anim2.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.E)) // attaque 3 
            {
                GameObject targetImage3;
                targetImage3 = GameObject.Find("TargetImage3");

                anim3.SetActive(true);
                PressButtonColorChange(button3);
                CastSpell(targetImage3, spellUI.spellBuildActif[2]);

            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                anim3.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.R)) // attaque 4 
            {
                GameObject targetImage4;
                targetImage4 = GameObject.Find("TargetImage4");

                anim4.SetActive(true);
                PressButtonColorChange(button4);
                CastSpell(targetImage4, spellUI.spellBuildActif[3]);

            }

            if (Input.GetKeyUp(KeyCode.R))
            {
                anim4.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.S)) // attaque 4 
            {

                anim5.SetActive(true);

            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                anim5.SetActive(false);
            }


        }
     
    }

    public void CastSpell (GameObject g, SpellScriptableObject spell)
    {

        displaySpell.DisplaySpell(g); //DisplaySpell déclarée dans SpellsFusionUI.cs
        GameObject newSpell = Instantiate(prefabSpell, transform.position, Quaternion.identity);
        SpellLifeTime lifeTime = newSpell.AddComponent<SpellLifeTime>();
        lifeTime.SpellDie(spell.spellTime);

        if (spell.spellZone == "sphere")
        {
            SpellZone spellZone = newSpell.AddComponent<SpellZone>();
            spellZone.SphereAttack(spell);
        }
        else if (spell.spellZone == "cone")
        {
            SpellZone spellZone = newSpell.AddComponent<SpellZone>();
            spellZone.ConeAttack(spell);
        }
        else if (spell.spellZone == "ray")
        {
            SpellZone spellZone = newSpell.AddComponent<SpellZone>();
            spellZone.RayAttack(spell);
        }
        else if (spell.spellZone == "ball")
        {
            SpellZone spellZone = newSpell.AddComponent<SpellZone>();
            spellZone.BallAttack(spell);

            BallSpell ball = newSpell.AddComponent<BallSpell>();
        }


        spellIDButton = spell.spellID; // récupère l'ID du scriptableobject spell lancé 
        buildManagerScript.spellCombinaisonList.Add(spellIDButton); // l'ajoute à la combinaison de quatre éléments (liste dans le BuildManager)

    }


    
    IEnumerator ButtonColorCoroutine(Button button) // Coroutine pour changement couleur bouton

    {
        // suspend execution for 2 seconds
        yield return new WaitForSeconds(0.1f);
        SetNormalColor(button);
       
    }

    public void PressButtonColorChange(Button button)
    {
        SetPressedColor(button);
        StartCoroutine(ButtonColorCoroutine(button));

    }

    void SetPressedColor(Button button)
    {
        button.image.color = button.colors.pressedColor;
    }

    void SetNormalColor(Button button)
    {
        button.image.color = button.colors.normalColor;
    }


   
}