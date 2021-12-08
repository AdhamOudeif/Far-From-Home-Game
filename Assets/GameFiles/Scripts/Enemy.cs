using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	public int health = 100;

	public GameObject deathEffect;


	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Bullet")
		{
			TakeDamage(5);
			Debug.Log("Ouch! My health is: " + health);
		}
		if(collision.gameObject.tag == "Player")
        {
			Debug.Log("Killed the player!");
			this.health = 100;
        }
	}

	public void TakeDamage(int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

}
