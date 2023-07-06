using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Element
{
    public float damage;
    public GameObject prefabAreaEffect;
    public Vector3 offSet;

    public override void Cast()
    {
        base.Cast();
        GameObject areaEffect = Instantiate(prefabAreaEffect, offSet, Quaternion.identity);
        areaEffect.GetComponent<AreaEffect>().SetUp(damage, time);
    }

}
