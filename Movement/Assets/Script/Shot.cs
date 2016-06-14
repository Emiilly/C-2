using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
   
    //Speed of the bullet
    public float speed = 3.0f;
    private Rigidbody2D rigi;

    // Update is called once per frame
    void FixedUpdate()
    {
        rigi = GetComponent<Rigidbody2D>();
        rigi.velocity = new Vector2(0.0f, speed);

    }
    // Function called when the object goes out of the screen
   void OnBecameInvisible()
    {
        // Destroy the bullet 
        Destroy(gameObject);
    }
}
