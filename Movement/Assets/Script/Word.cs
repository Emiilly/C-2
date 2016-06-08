using UnityEngine;
using System.Collections;

public class Word
{

    private string myWordString;
    ArrayList myLetters = new ArrayList();
    /// <summary>
    /// sets up the intial letters for the word
    /// </summary>
    /// <param name="initialword"></param>
    public Word(string initialword)
    {
        this.myWordString = initialword;
        foreach (char x in initialword)     //just seperating the letters can be changed to an actuall class of letter
        {
            myLetters.Add(x);
        }
    }

    int getLetteratPoint()
    {
        return 0;
    }

    public string giveSelf()
    {
        return this.myWordString;
    }
    /// <summary>
    /// removes the letter at position
    /// </summary>
    /// <param name="position"></param>
    void RemoveLetter(int position)
    {   //we can maybe use remove if we know the object
        myLetters.RemoveAt(position);
    }
}
