using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Script;

public class Bubbles : MonoBehaviour {
    int health = 1;

    public Text wordformed;
    public Words words = new Words();
    string word = "";
    string nxtletter = "B";

    void Awake()
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
        spellWord();
        Destroy(gameObject);
        
    }


    void spellWord()
    {
        if (word == null)
        {
            word = words.getNextWord();
        }

        nxtletter = getNextLetter(wordformed.text.Length);

        if (nxtletter == gameObject.name)
        {
            {
                string modified = wordformed.text.Insert(wordformed.text.Length, gameObject.name);
                wordformed.text = modified;
            }
        }
        else
        {
            wordformed.text = "wrong :(";
        }

        if (wordformed.text.Length == 4)
        {
            wordformed.text = "You done it pal";
            getNextWord();
        }
    }

    void getNextWord()
    {
            for (int i = 1; i < words.Size(); i++)
            {
                word = words.getNextWord();
            }
        
    }

    public string getNextLetter(int next)
    {
        return word[next].ToString();
    }

    void Update()
    {
        wordformed = gameObject.GetComponent<Text>();

        wordformed.text = words.giveCurrent();

    }
}
