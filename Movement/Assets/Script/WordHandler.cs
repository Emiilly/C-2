using Assets.Script;
using UnityEngine;
using UnityEngine.UI;

public class WordHandler : MonoBehaviour
{
    public Text wordformed;    //when do I use this?
    public Words words = new Words();    //setting up words
    private string word;                        //empty word
    private string nxtletter;
    private bool wordspelt = false;
    private int health = 3;     //totalplayer health

    // Use this for initialization
    private void Start()
    {
        word = null;
    }

    // Update is called once per frame
    private void Update()
    {
        if (health <= 0)
        {
            //run gameover routines
        }
        else
        {
            //just making sure that a word is set
            if (word == null && wordspelt == false)
            {
                Debug.Log("Word is null, Calling head word");
                word = words.giveCurrent();
            }
            else
            {
                if (wordspelt == true)
                {
                    word = words.getNextWord();
                }
            }
        }
    }
    
    /// <summary>
    /// gets an input and attempts to spell
    /// Failure results in a loss of life
    /// </summary>
    /// <param name="input"></param>
    private void AttemptSpelling(string input)
    {
        //receives the head of the spelt word
        nxtletter = word[words.giveWordHead()].ToString();
        Debug.Log("Next Letter to find is   " + word[words.giveWordHead()]);

        if (input == gameObject.name)
        {
            {
                string modified = wordformed.text.Insert(wordformed.text.Length, gameObject.name);
                wordformed.text = modified;
                //delete head of word

                Debug.Log("virtual moved removed " + word[words.giveWordHead()]);
                words.letterhit();
                Debug.Log("NextLetter to find is   " + getNextLetter(words.giveWordHead()));
            }
        }
        else
        {
            wordformed.text = "wrong :(";
            health--;
        }

        if (wordformed.text.Length == 4)
        {
            wordformed.text = "You done it pal";
            getNextWord();
        }
    }

    /// <summary>
    /// Gets next word and sets it to the local word handle
    /// </summary>
    private void getNextWord()
    {
        //what?
        /*
        for (int i = 1; i < words.Size(); i++)
        {
            word = words.getNextWord();
        }
        */
        word = words.getNextWord();
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
        foreach (char x in word)
        {
            if (x == search)
            {
                return counter;
            }
            counter++;
        }
        return 0;
    }
}