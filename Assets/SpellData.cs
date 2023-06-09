using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpellData", menuName = "gui-felix-projet-v2/SpellData")]
public class SpellData : ScriptableObject
{
    public Spell_CastType castType;
    public Spell_Target target;
    public Spell_Effect effect;

    public GameObject model;

    public float lifeTime; /* lifeTime = 0 -> temps infinie */

    [Header("SkillShot")]
    public float speed;

    [Header("Bump")]
    public float bump_velocity;
    public float bump_time;
    public Bump_Dir bump_Dir;

    [Header("Stat")]
    public float damage;
}
