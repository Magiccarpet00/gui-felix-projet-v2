using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpellData", menuName = "gui-felix-projet-v2/SpellData")]
public class SpellData : ScriptableObject
{
    public Spell_CastType castType;
    public GameObject model;

    public float lifeTime;

    [Header("SkillShot")]
    public float speed;
    



}
