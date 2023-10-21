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

    public SpellPlacement instantiateSpellPlacement;


    public int spellIDButton;
    [SerializeField] SpellsUI spellUI;
    [SerializeField] SpellsFusionUI spellFusionUI;
    private SpellsFusionUI displaySpell;

    public SpellScriptableObject megaSpell;
    public SpellZoneDisplay spellZoneDisplay;


    public List<float> spellEffectTime;
    public List<float> spellLifeTime;
    public List<string> spellZone;
    public List<string> spellEffect;
    public List<string> spellEffectUnique;
    public List<float> attackRange;
    public List<float> spellDommageValue;
    public List<float> spellDotValue;
    public List<float> spellDotLifeTime;
    public List<float> spellHotValue;
    public List<float> spellHotLifeTime;
    public List<float> spellSlowValue;
    public List<float> refreshSpellZoneTime;

    public SpellZone instantiateSpellZone;


    //public string[] spellEffectToCombineList = new string[GameManager.instance.spellBuildActif.Length];





    private void Start()
    {
        displaySpell = GameObject.Find("SpellsFusionBG").GetComponent<SpellsFusionUI>();
        spellZoneDisplay = GameObject.Find("SpellZoneImage").GetComponent<SpellZoneDisplay>();
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
            spellFusionUI.ResetSpellBar();
            CastMegaSpell(megaSpell);
            


        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            //anim5.SetActive(false);
            GameManager.instance.isCastingMegaSpell = false;

        }

    }

    public void CastSpell(SpellScriptableObject spell)
    {
        GameManager.instance.InstantiateNewSpell(transform);

        SpellLifeTime lifeTime = GameManager.instance.newSpell.AddComponent<SpellLifeTime>();
        lifeTime.SpellDie(spell.spellLifeTime);
        instantiateSpellZone = GameManager.instance.newSpell.AddComponent<SpellZone>();
        instantiateSpellZone.ownerSpellZone = transform;

        if (spell.spellLifeTime != 0)
        {
            instantiateSpellPlacement = GameManager.instance.newSpell.AddComponent<SpellPlacement>();
        }

        RegisterSpellCasted(spell);

        if (spell.spellZone == "Sphere")
        {
            instantiateSpellZone.Sphere(spell);
        }
        else if (spell.spellZone == "Cone")
        {
            instantiateSpellZone.Cone(spell);
        }
        else if (spell.spellZone == "Ray")
        {
            instantiateSpellZone.Ray(spell);
        }
        else if (spell.spellZone == "Allonge")
        {

            instantiateSpellZone.Allonge(spell);
        }
        else if (spell.spellZone == "")
        {
            instantiateSpellZone.NoZone(spell);
        }
    }

    public void CastMegaSpell(SpellScriptableObject megaSpell)
    {
        GameManager.instance.isCastingMegaSpell = true;
        GameManager.instance.InstantiateNewSpell(transform);

        SpellLifeTime lifeTime = GameManager.instance.newSpell.AddComponent<SpellLifeTime>();
        lifeTime.SpellDie(megaSpell.spellLifeTime);

        instantiateSpellZone = GameManager.instance.newSpell.AddComponent<SpellZone>();
        instantiateSpellZone.ownerSpellZone = transform;

        if (!spellLifeTime.Contains(0))
        {
            instantiateSpellPlacement = GameManager.instance.newSpell.AddComponent<SpellPlacement>();
        }

        RegisterSpellCasted(megaSpell);

        if (megaSpell.spellZone == "Sphere")
        {

            instantiateSpellZone.Sphere(megaSpell);
        }
        else if (megaSpell.spellZone == "Cone")
        {

            instantiateSpellZone.Cone(megaSpell);
        }
        else if (megaSpell.spellZone == "Ray")
        {

            instantiateSpellZone.Ray(megaSpell);
        }
        else if (megaSpell.spellZone == "Allonge")
        {
            instantiateSpellZone.Allonge(megaSpell);
        }


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
           
            if(spell.attackRange != 0)
            {
                attackRange.Add(spell.attackRange);
            }
            spellEffect.Add(spell.spellEffect[0]);
            spellEffectTime.Add(spell.spellEffectTime);
            spellLifeTime.Add(spell.spellLifeTime);
            if (spell.spellDommageValue != 0)
            {
                spellDommageValue.Add(spell.spellDommageValue);
            }
            if (spell.spellDotValue != 0)
            {
                spellDotValue.Add(spell.spellDotValue);
            }
            if (spell.spellDotLifeTime != 0)
            {
                spellDotLifeTime.Add(spell.spellDotLifeTime);
            }
            if (spell.spellHotValue != 0)
            {
                spellHotValue.Add(spell.spellHotValue);
            }
            if (spell.spellHotLifeTime != 0)
            {
                spellHotLifeTime.Add(spell.spellHotLifeTime);
            }
            if (spell.spellSlowValue != 0)
            {
                spellSlowValue.Add(spell.spellSlowValue);
            }
            if (spell.refreshSpellZoneTime != 0)
            {
                refreshSpellZoneTime.Add(spell.refreshSpellZoneTime);
            }
            spellEffectUnique = RemoveDuplicates(spellEffect);

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
        refreshSpellZoneTime.Clear();

        megaSpell.spellZone = "";
        megaSpell.spellEffect.Clear();
        megaSpell.attackRange = 0f;
        megaSpell.spellEffectTime = 0f;
        megaSpell.spellDommageValue = 0f;
        megaSpell.spellDotValue = 0f;
        megaSpell.spellHotValue = 0f;
        megaSpell.spellSlowValue = 0f;
        megaSpell.spellLifeTime = 0f;
        megaSpell.refreshSpellZoneTime = 0f;

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

        foreach (string spellzone in spellZone)
        {
            if(!string.IsNullOrEmpty(spellzone))
            {
                megaSpell.spellZone = spellzone;
                spellZoneDisplay.spellZone = megaSpell.spellZone;
                break;
            }

        }   

        //spellEffect : récupère la séquence lancée dans un llste pour analyse

        megaSpell.spellEffect = spellEffectUnique;

            //attackRange : multiplie par le nombre de spell lancés

            if (attackRange.Count > 0)
            {
                if(spell.spellLifeTime != 0)
                {
                    if( attackRange[0] == 0 && spellZone.Count > 1)
                    {
                     megaSpell.attackRange = attackRange[1] * attackRange.Count;
                    }
                    else
                    {
                    megaSpell.attackRange = attackRange[0] * attackRange.Count;
                    }

            }

            }

        //spellValue (toutes les values) : Prendre la moyenne des sorts lancés 

        megaSpell.spellDommageValue = CalculateSpellValue(spellDommageValue, spell);
        megaSpell.spellDotValue = CalculateSpellValue(spellDotValue, spell);
        megaSpell.spellHotValue = CalculateSpellValue(spellHotValue, spell);
        megaSpell.spellSlowValue = CalculateSpellValue(spellSlowValue, spell);

        // spellEffectTime  : valeur la plus elevée des spells lancés
        megaSpell.spellEffectTime = Mathf.Max(spellEffectTime.ToArray());

       

        // spellEffectTime  : valeur la plus elevée des spells lancés
        megaSpell.spellEffectTime = Mathf.Max(spellEffectTime.ToArray());
        megaSpell.spellDotLifeTime = Mathf.Max(spellDotLifeTime.ToArray());
        megaSpell.spellHotLifeTime = Mathf.Max(spellHotLifeTime.ToArray());

        //refresh Spell Life Time : Prendre la moyenne des sorts lancés 

        if (refreshSpellZoneTime.Count > 0)
        {
            float sum = 0;
            float divider = 0;


            foreach (float number in refreshSpellZoneTime)
            {
                sum += number;

                if (number != 0)
                {
                    divider += 1;
                }
            }

            megaSpell.refreshSpellZoneTime = sum / divider;
        }



    }

    private float CalculateSpellValue(List<float> spellValueList, SpellScriptableObject spell)
    {
        float spellValue = 0;

        if (spellValueList.Count > 0)
        {
            float sum = 0;
            float divider = 0;


            foreach (float number in spellValueList)
            {

                if (number != 0)
                {
                    sum += number;
                    divider += 1;
                }

            }

            spellValue = spellValueList.Count + sum / divider;
        }

        return spellValue;

    }

    private List<string> RemoveDuplicates(List<string> inputList)
    {
        // Créez un HashSet pour stocker les valeurs uniques
        HashSet<string> uniqueValues = new HashSet<string>();

        // Créez une nouvelle liste pour stocker les valeurs uniques
        List<string> uniqueList = new List<string>();

        foreach (string value in inputList)
        {
            // Si la valeur n'est pas déjà dans le HashSet, ajoutez-la au HashSet et à la liste des valeurs uniques
            if (uniqueValues.Add(value))
            {
                uniqueList.Add(value);
            }
        }

        return uniqueList;
    }
}