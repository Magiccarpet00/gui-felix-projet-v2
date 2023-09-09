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

    public SpellScriptableObject megaSpell;
    //public SpellScriptableObject SpellBuffer1;
    //public SpellScriptableObject SpellBuffer2;
    //public SpellScriptableObject SpellBuffer3;
    //public SpellScriptableObject SpellBuffer4;



    public List<float> spellEffectTime;
    public List<float> spellLifeTime;
    public List<string> spellZone;
    public List<string> spellEffect;
    public List<float> attackRange;
    public List<float> spellDommageValue;
    public List<float> spellDotValue;
    public List<float> spellHotValue;
    public List<float> spellSlowValue;
    public List<float> refreshSpellLifeTime;

    //public string[] spellEffectToCombineList = new string[GameManager.instance.spellBuildActif.Length];





    private void Start()
    {
        displaySpell = GameObject.Find("SpellsFusionBG").GetComponent<SpellsFusionUI>();
        ResetLists();
        //ResetBufferLists();
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
                CastSpell(GameManager.instance.spellBuildActif[0]);
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
                CastSpell(GameManager.instance.spellBuildActif[1]);
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
                CastSpell(GameManager.instance.spellBuildActif[2]);
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
                CastSpell(GameManager.instance.spellBuildActif[3]);
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
            


        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            anim5.SetActive(false);
            GameManager.instance.isCastingMegaSpell = false;

        }
 
    }

    public void CastSpell(SpellScriptableObject spell)
    {

        GameManager.instance.InstantiateNewSpell(transform);

        SpellLifeTime lifeTime = GameManager.instance.newSpell.AddComponent<SpellLifeTime>();
        lifeTime.SpellDie(spell.spellLifeTime);

        if (spell.spellLifeTime != 0)
        {
            GameManager.instance.newSpell.AddComponent<SpellPlacement>();
        }

        RegisterSpellCasted(spell);

        if (spell.spellZone == "Sphere")
        {          
            SpellZone spellZone = GameManager.instance.newSpell.AddComponent<SpellZone>();
            spellZone.Sphere(spell);
        }
        else if (spell.spellZone == "Cone")
        {
           
            SpellZone spellZone = GameManager.instance.newSpell.AddComponent<SpellZone>();
            spellZone.Cone(spell);
        }
        else if (spell.spellZone == "Ray")
        {
           
            SpellZone spellZone = GameManager.instance.newSpell.AddComponent<SpellZone>();
            spellZone.Ray(spell);
        }
    }

    public void CastMegaSpell(SpellScriptableObject megaSpell)
    {

        GameManager.instance.InstantiateNewSpell(transform);

        SpellLifeTime lifeTime = GameManager.instance.newSpell.AddComponent<SpellLifeTime>();
        lifeTime.SpellDie(megaSpell.spellLifeTime);

        if (!spellLifeTime.Contains(0))
        {
            GameManager.instance.newSpell.AddComponent<SpellPlacement>();
        }

        RegisterSpellCasted(megaSpell);

        if (megaSpell.spellZone == "Sphere")
        {

            SpellZone spellZone = GameManager.instance.newSpell.AddComponent<SpellZone>();
            spellZone.Sphere(megaSpell);
        }
        else if (megaSpell.spellZone == "Cone")
        {

            SpellZone spellZone = GameManager.instance.newSpell.AddComponent<SpellZone>();
            spellZone.Cone(megaSpell);
        }
        else if (megaSpell.spellZone == "Ray")
        {

            SpellZone spellZone = GameManager.instance.newSpell.AddComponent<SpellZone>();
            spellZone.Ray(megaSpell);
        }

        //ResetLists();
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
            spellEffect.Add(spell.spellEffect[0]);
            spellEffectTime.Add(spell.spellEffectTime);
            spellLifeTime.Add(spell.spellLifeTime);
            spellDommageValue.Add(spell.spellDommageValue);
            spellDotValue.Add(spell.spellDotValue);
            spellHotValue.Add(spell.spellHotValue);
            spellSlowValue.Add(spell.spellSlowValue);
            refreshSpellLifeTime.Add(spell.refreshSpellLifeTime);

    MegaSpellBuild(spell);
        }
        
    }

    public void ResetLists()
    {
        spellZone.Clear();
        spellEffect.Clear();
        attackRange.Clear();
        spellEffectTime.Clear();
        spellLifeTime.Clear();
        spellDommageValue.Clear();
        spellDotValue.Clear();
        spellHotValue.Clear();
        spellSlowValue.Clear();
        refreshSpellLifeTime.Clear();

        megaSpell.spellZone = "";
        megaSpell.spellEffect.Clear();
        megaSpell.attackRange = 0f;
        megaSpell.spellEffectTime = 0f;
        megaSpell.spellDommageValue = 0f;
        megaSpell.spellDotValue = 0f;
        megaSpell.spellHotValue = 0f;
        megaSpell.spellSlowValue = 0f;
        megaSpell.spellLifeTime = 0f;
        megaSpell.refreshSpellLifeTime = 0f;

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

    public void MegaSpellBuild(SpellScriptableObject spell)
    {
        //-----------Construction du MegaSpell-------------

            //spellTime : valeur la plus elevée des spells lancés

            megaSpell.spellLifeTime = Mathf.Max(spellLifeTime.ToArray());

            //spellZone : La première zone lancée

            megaSpell.spellZone = spellZone[0];

            //spellEffect : récupère la séquence lancée dans un llste pour analyse

            megaSpell.spellEffect.Add(spell.spellEffect[0]);

            //attackRange : multiplie par le nombre de spell lancés

            if (attackRange.Count > 0)
            {
                if(spell.spellLifeTime != 0)
                {
                    megaSpell.attackRange = attackRange[0] * attackRange.Count;
                }

            }

            //spellValue (toutes les values) : Prendre la moyenne des sorts lancés 

            if (spellDommageValue.Count > 0)
            {
                float sum = 0;

                foreach (float number in spellDommageValue)
                {
                    sum += number;
                }

                megaSpell.spellDommageValue = sum / spellDommageValue.Count;
            }

            if (spellDotValue.Count > 0)
            {
                float sum = 0;

                foreach (float number in spellDotValue)
                {
                    sum += number;
                }

                megaSpell.spellDotValue = sum / spellDotValue.Count;
            }
            if (spellHotValue.Count > 0)
            {
                float sum = 0;

                foreach (float number in spellHotValue)
                {
                    sum += number;
                }

                megaSpell.spellHotValue = sum / spellHotValue.Count;
            }
            if (spellSlowValue.Count > 0)
            {
                float sum = 0;

                foreach (float number in spellSlowValue)
                {
                    sum += number;
                }

                megaSpell.spellSlowValue = sum / spellSlowValue.Count;
            }

        // spellEffectTime  : valeur la plus elevée des spells lancés
        megaSpell.spellEffectTime = Mathf.Max(spellEffectTime.ToArray());

        //refresh Spell Life Time : Prendre la moyenne des sorts lancés 

        if (refreshSpellLifeTime.Count > 0)
        {
            float sum = 0;

            foreach (float number in refreshSpellLifeTime)
            {
                sum += number;
            }

            megaSpell.refreshSpellLifeTime = sum / refreshSpellLifeTime.Count;
        }



    }
}