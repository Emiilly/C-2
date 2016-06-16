using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
   
    //Speed of the bullet
    public float speed = 3.0f;
    private Rigidbody2D rigi;

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void FixedUpdate()
    {
        rigi = GetComponent<Rigidbody2D>();
        rigi.velocity = new Vector2(0.0f, speed);
    }

    /// <summary>
    /// Function called when the object goes out of the screen
    /// </summary>
    void OnBecameInvisible()
    {
        // Destroy the bullet 
        Destroy(gameObject);
    }
}
