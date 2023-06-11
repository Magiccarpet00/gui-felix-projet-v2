using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell_throw : Spell2
{
    public override void Cast()
    {
        LinearSkillShotCast();
    }

    public override void Effect()
    {
        
    }

    public override void Load()
    {
        _LoadCancelMove(spellData.loadDelay);
    }

    public override void OnTriggerEnter(Collider other)
    {
        
    }
}
