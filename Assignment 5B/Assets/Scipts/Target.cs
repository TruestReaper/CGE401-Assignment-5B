/*
* Name: John Chirayil
* CGE401 - Assignment 5B
* File: Target.cs
* Desc: Sets the health system for the targets.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public AudioSource hitSound, destroyedSound;

    public void TakeDamage(float amount)
    {
        health -= amount;

        hitSound.Play();

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        destroyedSound.Play();

        Destroy(gameObject);
    }
}
