using UnityEngine;
using System.Collections;

public class DamageHandler : MonoBehaviour {

    int health = 1;

    void OnTriggerEnter2D()
    {
        Debug.Log("Trigger!");
        health--;
        if (health<= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
