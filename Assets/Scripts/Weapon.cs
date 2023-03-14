using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Weapon : MonoBehaviour
{
    public Rigidbody2D rb;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject stethoscopePrefab;

    public SwitchCharacter currentCharacter;

    public DashBar dashBar;

    public float dashDistance = 100f;
    public float dashCooldown = 5f;
    private float nextDash = 0f;


    public float attackCooldown = 0.5f;
    private float nextAttack = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && currentCharacter.isDamage)
        {
            Shoot();
        }

        if (Input.GetButtonDown("Fire1") && currentCharacter.isSpeed)
        {
            if(Time.time > nextDash)
            {
                Dash();
                nextDash = Time.time + dashCooldown;
            }
        }

        dashBar.SetDashCooldown(nextDash);

        if (Input.GetButtonDown("Fire1") && currentCharacter.isHealer)
        {
            if (Time.time > nextAttack)
            {
                Attack();
                nextAttack = Time.time + attackCooldown;
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        FindObjectOfType<AudioManager>().Play("Apple");
    }

    void Dash()
    {
        rb.velocity = transform.right * dashDistance;
        FindObjectOfType<AudioManager>().Play("Dash");
    }

    void Attack()
    {
        Instantiate(stethoscopePrefab, firePoint.position, firePoint.rotation);
        FindObjectOfType<AudioManager>().Play("Stethoscope");
    }
}
