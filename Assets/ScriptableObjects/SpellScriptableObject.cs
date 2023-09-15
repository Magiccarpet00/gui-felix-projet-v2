using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NouveauSpell", menuName = "Gui Felix Project/SpellScriptableObject", order = 1)]
public class SpellScriptableObject : ScriptableObject
{
   
    public Sprite spellIcon;
    public float spellEffectTime;
    public float spellLifeTime;
    public float refreshSpellZoneTime;
    public float dotLifeTime;
    public string spellZone;
    [Header("General Settings")]
    public List<string> spellEffect = new List<string>();
    public float attackRange;
    public float spellDommageValue;
    public float spellDotValue;
    public float spellDotLifeTime;
    public float spellHotValue;
    public float spellSlowValue;
    public int spellID;
 




   
}