using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NouveauSort", menuName = "Gui Felix Project/SpellScriptableObject", order = 1)]
public class SpellScriptableObject : ScriptableObject
{
    public string spellName;
    public int spellID;
    public Sprite spellIcon;
    public float spellTime;
    public string spellType;
    public string spellZone;
    public string spellEffect;
    public float attackRange;
    public float spellValue;
    private SpellsFusionUI displaySpell;
    public int spellIDButton;
    [SerializeField] SpellsUI spellUI;
    [SerializeField] SpellsFusionUI spellFusionUI;
    [SerializeField] BuildManagerScript buildManagerScript;



   
}