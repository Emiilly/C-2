using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
    //The fireball object linked to the cat to shoot it
    public GameObject furball2;

    //Speed of the cat
    public float speed = 10.0f;
    //The min and max of how far the cat can go on screen
    public float minX = -7.5f;
    public float maxX = 7.5f;
    
    // Update is called once per frame
    void Update()
    {
        //Movement of sir spelling cat
        float delta = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        if (transform.position.x < minX)
        {
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > maxX)
        {
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        }
        transform.position += new Vector3(delta, 0.0f);

        
        // When the spacebar is pressed shoot fireball
        if (Input.GetKeyDown(KeyCode.Space))
        {
      
            Instantiate(furball2, transform.position, Quaternion.identity);

        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

}
