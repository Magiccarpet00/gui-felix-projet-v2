using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NouveauSort", menuName = "Gui Felix Project/SpellScriptableObject", order = 1)]
public class SpellScriptableObject : ScriptableObject
{
    public string spellName;
    public int spellID;
    public Sprite spellIcon;

}