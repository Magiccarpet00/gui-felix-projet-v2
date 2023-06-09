using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterData characterData;

    public float currentLife;
    public float currentMoveSpeed;
    public float currentPower;

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

    
}
