using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkEffectScript : MonoBehaviour
{
    public virtual void BlinkEffect(SpellScriptableObject spell, Vector3 endPoint)
    {
        if (GameManager.instance.isCastingMegaSpell == false)
        {

            PlayerDeplacement playerDeplacement = GameManager.instance.prefabPlayer.GetComponent<PlayerDeplacement>();
            playerDeplacement.BlinkPlayer(spell.spellEffectTime, endPoint);

        }
        else if (GameManager.instance.isCastingMegaSpell == true)
        {
            BlinkSpell(spell.spellEffectTime, endPoint);
        }

}

    public void BlinkSpell(float blinkTime, Vector3 newPos)
    {
        StartCoroutine(BlinkSpellCoroutine(blinkTime, newPos));
    }

    public IEnumerator BlinkSpellCoroutine(float blinkTime, Vector3 newPos)
    {
        GameManager.instance.newSpell.transform.position = newPos;

        yield return new WaitForSeconds(blinkTime);
    }
}
