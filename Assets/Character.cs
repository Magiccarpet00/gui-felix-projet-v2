using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public CharacterData characterData;

    public float currentLife;
    public float currentMoveSpeed;
    public float currentPower;

    public Image healthBar;

    private void Start()
    {
        SetUp();
    }

    public void SetUp() 
    {
        currentLife = characterData.Life;
        currentMoveSpeed = characterData.Life;
        currentPower = characterData.Life;
    }

    public void TakeDamage(float damage)
    {
        currentLife -= damage; // R�duit les points de vie actuels de l'ennemi
        healthBar.fillAmount = currentLife / characterData.Life;

        if (currentLife <= 0)
            Die();
    }

    private void Die()
    {
        // Code � ex�cuter lorsque l'ennemi est vaincu
        // Par exemple, jouer une animation de mort, d�truire l'ennemi, etc.
        Destroy(gameObject);
    }

}
