using Assets.Script;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
/// Bubbles scripter class
/// </summary>
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
    /// bubbles class
    /// </summary>
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

	/// <summary>
	/// Gets the words, set up in this way if we ever need to access the word from outside the bubbles class.
	/// </summary>
	/// <returns>The words.</returns>
    private static Words GetWords()
    {
        if (words == null)
        {
            //get the words
            if (words == null) words = new Words();
        }
        return words;
    }
	/// <summary>
	/// Gets the spelling.
	/// </summary>
	/// <returns>The spelling.</returns>
    public static string getSpelling()
    {
        return speltword;
    }


	/// <summary>
	/// Gets the word.
	/// </summary>
	/// <returns>The word.</returns>
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
	/// <summary>
	/// Awake this instance: wakes the obeject attached.
	/// </summary>
    private void Awake()
    {
        if (words == null)
        {
            words = GetWords();
            Debug.Log("Words set");
        }
    }

    private void OnTriggerEnter2D()
    {
        Die();
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
    { 
        string[] sArr = gameObject.name.ToString().Split('(');
        string objname = sArr[0];

        if (words != null)		//Grabs the current word and sets the next letter to find
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

            if (nxtletter == (objname))		//compares the letter of the object hit with the head letter
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
                        wordformed.text = "You done it pal";		//if the length is 0, the word has been spelt
                        getNextWord();
                    }
                }
            }
            else   //if it gets here, then you hit the wrong word, then hp gets modified
            {
                
                Debug.Log("Lost HP");
                health--;
            }
        }
        else  //nullword, word not set?!  Gets new word, then compare
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

        if (health <= 0)//dead check
        {
            Debug.Log("ded");
            Application.LoadLevel(Application.loadedLevel);
            //game over scripts
        }
        if (wordspelt == true) //victory check
        {
            Debug.Log("Wordspelt!!!");
            getNextWord();
        }
			
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

	/// <summary>
	/// Update this instance.
	/// </summary>
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