using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour
{
    public PlayerMovement playerMovement;

    public SpriteRenderer currentCharacter;
    public Sprite damageCharacter;
    public Sprite speedCharacter;
    public Sprite healerCharacter;

    public Transform player;

    public float damageCharacterMovementSpeed = 60f;
    public float speedCharacterMovementSpeed = 140f;
    public float healerCharacterMovementSpeed = 20f;

    public bool isDamage = true;
    public bool isSpeed = false;
    public bool isHealer = false;

    private void Update()
    {
        //if (Input.GetButtonDown("Fire2"))
        //{
        //    Switch();
        //}
    }
    public void Switch()
    {
            //Damage to Speed
            if (isDamage)
            {
                isDamage = false;
                isSpeed = true;
                isHealer = false;

                currentCharacter.sprite = speedCharacter;
                playerMovement.runSpeed = speedCharacterMovementSpeed;
            }

            //Speed to Healer
            else if (isSpeed)
            {
                isSpeed = false;
                isDamage = false;
                isHealer = true;

                currentCharacter.sprite = healerCharacter;
                playerMovement.runSpeed = healerCharacterMovementSpeed;
            }
            //Healer to Damage
            else if (isHealer)
            {
                isSpeed = false;
                isDamage = true;
                isHealer = false;

                currentCharacter.sprite = damageCharacter;
                playerMovement.runSpeed = damageCharacterMovementSpeed;
            }
    }
    
}
