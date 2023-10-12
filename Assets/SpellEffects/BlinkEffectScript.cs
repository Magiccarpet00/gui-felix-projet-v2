using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkEffectScript : MonoBehaviour
{
    public bool isBlinking = false;
    public virtual void BlinkEffect(SpellScriptableObject spell, Vector3 endPoint)
    {
        if (GameManager.instance.isCastingMegaSpell == false)
        {
            PlayerDeplacement playerDeplacement = GameManager.instance.prefabPlayer.GetComponent<PlayerDeplacement>();
            playerDeplacement.BlinkPlayer(spell.spellEffectTime, endPoint);

        }
        if (GameManager.instance.isCastingMegaSpell == true)
        {
            BlinkSpell(spell.spellEffectTime, endPoint);
        }
        if (GameManager.instance.isCastingMegaSpell == true && spell.spellZone == "Allonge")
        {
            epeeMovement epeeMovement = GameManager.instance.prefabPlayer.GetComponentInChildren<epeeMovement>();
            epeeMovement.BlinkEpee(endPoint);
        }
    }

    public void BlinkSpell(float blinkTime, Vector3 newPos)
    {
        SpellPlacement spellPlacement = GameManager.instance.newSpell.GetComponent<SpellPlacement>();
        spellPlacement.blink = true;
        isBlinking = true;
        StartCoroutine(BlinkSpellCoroutine(spellPlacement,blinkTime, newPos));
    }

    public IEnumerator BlinkSpellCoroutine(SpellPlacement spellPlacement, float blinkTime, Vector3 newPos)
    {
        GameManager.instance.newSpell.transform.position = newPos;

        yield return new WaitForSeconds(blinkTime);
        spellPlacement.blink = false;
    }
}
