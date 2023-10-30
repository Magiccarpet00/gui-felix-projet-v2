using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NouveauSpell", menuName = "Gui Felix Project/SpellScriptableObject", order = 1)]
public class SpellScriptableObject : ScriptableObject
{
    [Header("General Settings")]
    public Sprite spellIcon;
    public List<string> spellEffect = new List<string>();
    public float spellEffectTime;
    public float spellLifeTime;
    public float refreshSpellZoneTime;
    public string spellZone;
    public float attackRange;
    public int spellID;
    public GameObject spellBody;
    public Color spellBodyColor;
    [Header("Dommage")]
    public float spellDommageValue;
    [Header("Dot")]
    public float spellDotValue;
    public float spellDotLifeTime;
    [Header("Hot")]
    public float spellHotValue;
    public float spellHotLifeTime;
    [Header("Slow")]
    public float spellSlowValue;

    private PlayerAttack playerAttack;

   
    
}