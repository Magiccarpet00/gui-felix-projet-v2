using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEffectScript : MonoBehaviour
{
    private float dashForce;
    private Vector3 playerForward;

    public PlayerAttack playerAttack;

    public void DashEffect(SpellScriptableObject spell, Vector3 endPoint)
    {
        if (GameManager.instance.isCastingMegaSpell == false)
        {

            PlayerDeplacement playerDeplacement = GameManager.instance.prefabPlayer.GetComponent<PlayerDeplacement>();
            playerDeplacement.DashPlayer(spell.spellEffectTime);
            dashForce = playerDeplacement.dashForce;

        }
        if (GameManager.instance.isCastingMegaSpell == true)
        {
            if(playerAttack.instantiateSpellPlacement != null)
            {
                playerAttack.instantiateSpellPlacement.DashSpell(spell.spellEffectTime, dashForce);              
            }
        }
        if (GameManager.instance.isCastingMegaSpell == true && spell.spellZone == "Allonge")
        {
            epeeMovement epeeMovement = GameManager.instance.prefabPlayer.GetComponentInChildren<epeeMovement>();
            epeeMovement.DashEpee(spell.spellEffectTime,spell.spellLifeTime, dashForce);

        }
    }

   
}
