using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int damage = 40;
    public float walkSpeed = 10f;

    public PlayerHealth player;

    void Update()
    {
        transform.Translate(Vector2.left * -walkSpeed * Time.deltaTime);

        if (health <= 0)
        {
            FindObjectOfType<AudioManager>().Play("EnemyDied");
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage, bool isHealer) //new healer
    {
        if(isHealer)
        {
            health = health - damage;
            FindObjectOfType<AudioManager>().Play("Hit");
            player.Heal(damage / 2);
        }

        else
        {
            health = health - damage;
            FindObjectOfType<AudioManager>().Play("Hit");
        }

    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            player.TakeDamage(damage);
        }

        else
        {
            //walkSpeed *= -1;
            transform.Rotate(0f, 180f, 0f);
        }
    }

}
