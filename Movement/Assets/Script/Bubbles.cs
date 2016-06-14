using Assets.Script;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//be mindful of below
//it is a patchwerked mess, much of it coded free hand without much of a plan
// you hath been forewarned

public class Bubbles : MonoBehaviour
{
    public static int health = 3;        //hp of the player, 2 wrongs and they are out.
    public static string word = null;    //word holder, part of the old way, may be redundant.
    private string nxtletter;           //nxt letter to compare strike
    private bool wordspelt = false;     //completed word bool
    private static string speltword="";
    public Text wordformed;
    private static Words words = null;     //words class handler
    public Text score;


    /// <summary>
    /// sets up a static words
    /// </summary>
    /// <returns></returns>
    public Bubbles()
        {
        if(health == 0)
            {
            
        health = 3;        //hp of the player, 2 wrongs and they are out.
        word = null;    //word holder, part of the old way, may be redundant.          //nxt letter to compare strike
        wordspelt = false;     //completed word bool
        speltword = "";
        words = null;
            SceneManager.LoadScene(4);
        }
    }

    private static Words GetWords()
    {
        if (words == null)
        {
            //get the words
            if (words == null) words = new Words();
        }
        return words;
    }

    public static string getSpelling()
    {
        return speltword;
    }

    public static string GetWord()
    {
        if (word == null)
        {
            //get the words
            if (word == null) word = words.giveCurrent();
        }
        return word;
    }

    private void Start()
    {
       
}

    private void Awake()
    {
        

        if (words == null)
        {
            words = GetWords();
            Debug.Log("Words set");
        }

       // wordformed = gameObject.AddComponent<Text>();
    }

    private void OnTriggerEnter2D()
    {
        // Debug.Log("TRIGGERED!");    I know this works

        Die();
        //redundant

        //health--;

        //   if (health <= 0)
        // {
        //
        // }
    }

    /// <summary>
    /// kills the object
    /// </summary>
    private void Die()
    {
        spellWord();
        Destroy(gameObject);
    }

    /// <summary>
    /// checks if the hit letter is the next letter for the word that needs to be spelt
    /// </summary>
    /// 
    private void spellWord()
    {   //commenting out the below for another test

        string[] sArr = gameObject.name.ToString().Split('(');
        string objname = sArr[0];

        if (words != null)
        {
            
            word = words.giveCurrent();
            Debug.Log(word);
            word = words.giveCurrent();
            Debug.Log("Word set " + word);
            Debug.Log("Posc" + words.giveWordHead().ToString());

            //receives the head of the spelt word
            nxtletter = word[words.giveWordHead()].ToString();
            Debug.Log(nxtletter);
            Debug.Log(objname);

            if (nxtletter == (objname))
            {
                {
                    speltword += (objname);
                    if (words.giveWordHead() < words.giveCurrent().Length)
                    {
                        string modified = wordformed.text.Insert(wordformed.text.Length, (objname));
                        wordformed.text = modified;
                        //delete head of word
                        Debug.Log("virtual removed " + word[words.giveWordHead()]);

                        words.letterhit();
                        if (words.giveWordHead() >= words.giveCurrent().Length)
                        {
                            wordformed.text = "You done it pal";
                            getNextWord();
                        }
                    }
                    else
                    {
                        //may never hit this, but idc
                        wordformed.text = "You done it pal";
                        getNextWord();
                    }
                }
            }
            else
            {
                
                Debug.Log("Lost HP");
                health--;
            }
        }
        else
        {
            Debug.Log(objname);
            Debug.Log("Word is null, Calling head word");
            word = words.giveCurrent();
            Debug.Log("Word set "+ words.giveCurrent());
            Debug.Log("Posc" + words.giveWordHead().ToString());
            //receives the head of the spelt word
            nxtletter = word[words.giveWordHead()].ToString();

            
            
            

            if (nxtletter == (objname))
            {
                speltword += objname;
                if (words.giveWordHead() < word.Length)
                {
                    string modified = wordformed.text.Insert(wordformed.text.Length, (objname));
                    wordformed.text = modified;
                    //delete head of word
                    Debug.Log("virtual removed " + word[words.giveWordHead()]);
                    words.letterhit();
                    if (words.giveWordHead() >= words.giveCurrent().Length)
                    {
                        wordspelt = true;
                        wordformed.text = "You done it pal";
                        getNextWord();
                    }
                }
                else
                {
                    ///ru ru ru
                    wordformed.text = "You done it pal";
                    getNextWord();
                }
            }
            else
            {
                wordformed.text = "wrong :(";
                Debug.Log("Lost HP");
                health--;
            }
        }

        if (health <= 0)
        {
            Debug.Log("ded");
            Application.LoadLevel(Application.loadedLevel);
            //game over scripts
        }
        if (wordspelt == true)
        {
            Debug.Log("Wordspelt!!!");
            getNextWord();
        }

        //more relics
        /*   if (wordformed.text.Length == 4)
            {
                wordformed.text = "You done it pal";
                getNextWord();
            }
            */
        this.wordformed.text = speltword;
    }

    /// <summary>
    /// sets up the next word for the game
    /// </summary>
    private void getNextWord()
    {
        //change scripts
        Debug.Log("gib code");
        speltword = "";
        word = GetWords().getNextWord();
        Debug.Log("The next word is : " + word);
        wordspelt = false;
    }

    /// <summary>
    /// gets the letter at given index
    /// </summary>
    /// <param name="next"></param>
    /// <returns></returns>
    public string getNextLetter(int next)
    {
        if (word.Length < next)
        {
            return null;
        }
        else
        {
            return word[next].ToString();
        }
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

    /// <summary>
    /// Returns the number of lives the player has
    /// </summary>
    /// <returns>health</returns>
    public static int getNumberLives()
    {
        return health;
    }

    private void Update()
    {
        if (wordformed != null)
        {
              this.wordformed.text = Bubbles.getSpelling();
        }
        else
        {
            wordformed = gameObject.AddComponent<Text>();
        }
    }
}