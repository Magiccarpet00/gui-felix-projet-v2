using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public List<int> currentDotSpell = new List<int>();
    public float maxHealth = 100f; // Points de vie maximum de l'ennemi
    private float currentHealth; // Points de vie actuels de l'ennemi
    public Image healthBar;
    public Color healthBarColor;

    void Start()
    {
        currentHealth = maxHealth;
        healthBarColor = healthBar.color;
    }
    public void PlayerTakeDamage(float damage)
    {
        currentHealth -= damage; // Réduit les points de vie actuels de l'ennemi
        healthBar.fillAmount = currentHealth / maxHealth;


        if (currentHealth <= 0)
        {
            PlayerDie();
        }
    }

    private void PlayerDie()
    {
        // Code à exécuter lorsque l'ennemi est vaincu
        // Par exemple, jouer une animation de mort, détruire l'ennemi, etc.
        Destroy(gameObject);
    }

    public void TakeDamageOnTime(float damage, float spellTime, float spellEffectTime, int spellID)
    {
        if (currentDotSpell.Contains(spellID))
        {
            Debug.Log("spell déjà lancé");

        }
        else
        {
            healthBar.color = Color.yellow;
            currentDotSpell.Add(spellID);
            StartCoroutine(DotCoroutine(damage, spellTime, spellEffectTime, spellID));


            if (currentHealth <= 0)
            {
                PlayerDie();
            }
        }

    }

    IEnumerator DotCoroutine(float damage, float duredevie, float frequence, int spellID)
    {


        if (duredevie < 0)
        {
            currentDotSpell.Remove(spellID);
            healthBar.color = healthBarColor;
            yield return new WaitForSeconds(0);
        }
        else
        {
            PlayerTakeDamage(damage);

            yield return new WaitForSeconds(frequence);

            StartCoroutine(DotCoroutine(damage, duredevie - frequence, frequence, spellID));
        }
    }


}
