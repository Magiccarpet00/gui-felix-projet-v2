using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpellLifeTime : MonoBehaviour
{

    PlayerAttack playerAttack;

    private void Start()
    {
        playerAttack = GameManager.instance.prefabPlayer.GetComponent<PlayerAttack>();
    }

    public void SpellDie(float time)
    {
        if(GameManager.instance.isCastingMegaSpell == false)
        {
            StartCoroutine(SpellTime(time));
        }
        else if (GameManager.instance.isCastingMegaSpell == true)
        {
            StartCoroutine(MegaSpellTime(time));
        }
    }

    IEnumerator SpellTime(float time)
    {

        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    IEnumerator MegaSpellTime(float time)
    {
        yield return new WaitForSeconds(time);
        playerAttack.ResetLists();
        Destroy(gameObject);

    }
}
