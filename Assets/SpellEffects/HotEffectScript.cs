using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotEffectScript : MonoBehaviour
{
    public void HotEffect(SpellScriptableObject spell)
    {

        GameObject hot = GameObject.FindGameObjectWithTag("HOT");

        if (hot != null)
        {
            
            Image image = hot.GetComponentInChildren<Image>();

            StartCoroutine(HotActiveTime(image, spell.spellTime));

        }
    }

    IEnumerator HotActiveTime(Image image, float spellTime)
    {
      
        image.color = Color.red;
        yield return new WaitForSeconds(spellTime);
        image.color = Color.white;

    }
}
