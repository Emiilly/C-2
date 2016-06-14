using UnityEngine;
using System.Collections;

public class SpaceShipmovement : MonoBehaviour {

    public GameObject furball2;


    public float speed = 10.0f;
    public float minX = -5.0f;
    public float maxX = 5.0f;
    
    

    // Update is called once per frame
    void Update()
    {
        
        

        float delta = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.position += new Vector3(delta, 0.0f);

        
        // When the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Create a new bullet at “transform.position” 
            // Which is the current position of the ship
            // Quaternion.identity = add the bullet with no rotation
            Instantiate(furball2, transform.position, Quaternion.identity);

        }
        

    }

    
    
}
