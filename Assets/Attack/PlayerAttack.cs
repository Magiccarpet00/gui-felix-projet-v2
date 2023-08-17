using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{  
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
    private SpellsFusionUI displaySpell;
    public GameObject prefabSpell;

    public SpellScriptableObject megaSpell;

    public List<float> spellTime;
    public List<string> spellZone;
    public List<string> spellEffect;
    public List<float> attackRange;
    public List<float> spellValue;

    
   



    private void Start()
    {
        displaySpell = GameObject.Find("SpellsFusionBG").GetComponent<SpellsFusionUI>();
        ResetLists();

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

                CastSpell(spellUI.spellBuildActif[0]);
                DisplaySpellCast(targetImage1);

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
                CastSpell(spellUI.spellBuildActif[1]);
                DisplaySpellCast(targetImage2);
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
                CastSpell(spellUI.spellBuildActif[2]);
                DisplaySpellCast(targetImage3);

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
                CastSpell(spellUI.spellBuildActif[3]);
                DisplaySpellCast(targetImage4);

            }

            if (Input.GetKeyUp(KeyCode.R))
            {
                anim4.SetActive(false);
            }

        }

        if (Input.GetKeyDown(KeyCode.S)) // Megaspell 
        {
            GameManager.instance.isCastingMegaSpell = true;
            spellFusionUI.ResetSpellBar();
            CastMegaSpell(megaSpell);
            ResetLists();


        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            anim5.SetActive(false);
            GameManager.instance.isCastingMegaSpell = false;

        }

        ////-----------Construction du MegaSpell-------------

        ////spellTime : valeur la plus elevée des spells lancés

        //megaSpell.spellTime = Mathf.Max(spellTime.ToArray());

        ////spellZone : La première zone lancée

        //if (spellZone.Count > 0)
        //{
        //    megaSpell.spellZone = spellZone[0];
        //}

        ////spellEffect : récupère la séquence lancée pour analyse

        //for (int i = 0; i <= spellEffect.Count; i++)
        //{
        //    megaSpell.spellEffect.Add(spellEffect[i]);

        //}
        ////megaSpell.spellEffect [0] = string.Join("-", spellEffect.ToArray()); 

        ////attackRange : Prendre la moyenne des sorts lancés 

        //if (attackRange.Count > 0)
        //{
        //    float sum = 0;

        //    foreach (float number in attackRange)
        //    {
        //        sum += number;
        //    }

        //    megaSpell.attackRange = sum / attackRange.Count;    
        //}

        ////spellValue : Prendre la moyenne des sorts lancés 

        //if (spellValue.Count > 0)
        //{
        //    float sum = 0;

        //    foreach (float number in spellValue)
        //    {
        //        sum += number;
        //    }

        //    megaSpell.spellValue = sum / spellValue.Count;
        //}

    }

    public void CastSpell (SpellScriptableObject spell)
    {

        GameObject newSpell = Instantiate(prefabSpell, transform.position, Quaternion.identity);
        SpellLifeTime lifeTime = newSpell.AddComponent<SpellLifeTime>();
        lifeTime.SpellDie(spell.spellTime);

        RegisterSpellCasted(spell);

        if (spell.spellZone == "Sphere")
        {
            SpellZone spellZone = newSpell.AddComponent<SpellZone>();
            spellZone.Sphere(spell);
        }
        else if (spell.spellZone == "Cone")
        {
            SpellZone spellZone = newSpell.AddComponent<SpellZone>();
            spellZone.Cone(spell);
        }
        else if (spell.spellZone == "Ray")
        {
            SpellZone spellZone = newSpell.AddComponent<SpellZone>();
            spellZone.Ray(spell);
        }
       
    }

    public void CastMegaSpell(SpellScriptableObject megaSpell)
    {


       CastSpell(megaSpell);


    }

    

    public void DisplaySpellCast(GameObject g)
    {
        displaySpell.DisplaySpell(g); //DisplaySpell déclarée dans SpellsFusionUI.cs
    }

    public void RegisterSpellCasted(SpellScriptableObject spell)
    {
        if (GameManager.instance.isCastingMegaSpell == false)
        {
            spellZone.Add(spell.spellZone);
            attackRange.Add(spell.attackRange);
            spellTime.Add(spell.spellTime);
            spellValue.Add(spell.spellValue);

            //-----------Construction du MegaSpell-------------

            //spellTime : valeur la plus elevée des spells lancés

            megaSpell.spellTime = Mathf.Max(spellTime.ToArray());

            //spellZone : La première zone lancée

            megaSpell.spellZone = spellZone[0];

            //spellEffect : récupère la séquence lancée dans un llste pour analyse

            megaSpell.spellEffect.Add(spell.spellEffect[0]);

            //attackRange : Prendre la moyenne des sorts lancés 

            if (attackRange.Count > 0)
            {
                float sum = 0;

                foreach (float number in attackRange)
                {
                    sum += number;
                }

                megaSpell.attackRange = sum / attackRange.Count;
            }

            //spellValue : Prendre la moyenne des sorts lancés 

            if (spellValue.Count > 0)
            {
                float sum = 0;

                foreach (float number in spellValue)
                {
                    sum += number;
                }

                megaSpell.spellValue = sum / spellValue.Count;
            }
        }
        
    }

    public void ResetLists()
    {
        spellZone.Clear();
        spellEffect.Clear();
        attackRange.Clear();
        spellTime.Clear();
        spellValue.Clear();

        megaSpell.spellZone = "";
        megaSpell.spellEffect.Clear();
        megaSpell.attackRange = 0f;
        megaSpell.spellTime = 0f;
        megaSpell.spellValue = 0f;
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