using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Script;

public class Bubbles : MonoBehaviour {
    int health = 1;

    public Text wordformed;
    public Words words = new Words();
    string word;
    string nxtletter;

    void Awake()
    {
        wordformed = gameObject.AddComponent<Text>();
    }

    void OnTriggerEnter2D()
    {
        Debug.Log("TRIGGERED!");
        health--;
        word = words.giveCurrent();
        if (health<= 0)
        {            
            Die();
        }
    }
    /// <summary>
    /// kills the object
    /// </summary>
    void Die()
    {
        spellWord();
        Destroy(gameObject);
        
    }


    /// <summary>
    /// checks if the hit letter is the next letter for the word that needs to be spelt
    /// </summary>
    void spellWord()
    {
        if (word == null)
        {
            Debug.Log("Word is null, Calling next word");
            word = words.getNextWord();
        }

        Debug.Log("I hit  " + gameObject.name);
        //receives the head of the spelt word
        nxtletter = getNextLetter(0);
        Debug.Log("NextLetter to find is   " + word[0]);
        if (nxtletter == gameObject.name)
        {
            {

                string modified = wordformed.text.Insert(wordformed.text.Length, gameObject.name);
                wordformed.text = modified;
                //delete head of word
                if(word.Length>=1)
                {
                    Debug.Log("removed " + word[0]);

                    Debug.Log("full word " + word);


                    word.Remove(0,1);
                    Debug.Log("full word after remove" + word);
                    Debug.Log("NextLetter to find is   " + word[0]);
                }
                else
                {
                    Debug.Log("get fucked kid, the word check is not filled");
                }
              
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


    /// <summary>
    /// gets next word in the series of words
    /// </summary>
    void getNextWord()
    {
            for (int i = 1; i < words.Size(); i++)
            {
                word = words.getNextWord();
            }
        
    }

    /// <summary>
    /// gets the letter at given index
    /// </summary>
    /// <param name="next"></param>
    /// <returns></returns>
    public string getNextLetter(int next)
    {
        return word[next].ToString();
    }


    /// <summary>
    /// a way to seach the word to see if the char exists
    /// No use for it yet, but it's there.
    /// </summary>
    /// <param name="search"></param>
    /// <returns></returns>
    public int giveCharIndex(char search)
    {
        int counter = 0;
        foreach(char x in word)
        {
            if (x == search)
            {
                return counter;
            }
            counter++;
        }
        return 0;

    }
    void Update()
    {
        wordformed.text = words.giveCurrent();
    }
}
