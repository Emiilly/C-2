using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Script;

public class DamageHandler : MonoBehaviour {

    int health = 1;

    public Text wordformed;
    public Words ball = new Words();

    void start()
    {
        wordformed = gameObject.GetComponent<Text>();
    }

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

        string nxtLetter = ball.getNext(wordformed.text.Length);
        if (nxtLetter == gameObject.name)
        {
            string modified = wordformed.text.Insert(wordformed.text.Length, gameObject.name);
            wordformed.text = modified;
        }
        else
        {
            wordformed.text = "wrong :(";
        }


        Destroy(gameObject);
        
    }
}
