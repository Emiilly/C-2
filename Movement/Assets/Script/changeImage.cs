using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class changeImage : MonoBehaviour {
    /// <summary>
    /// variables that store the image reference and the current word
    /// </summary>
    public RawImage img;
    public string currentWord;
    public string word;
    public float elapsedTime;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start ()
    {
        img = GetComponent<RawImage>();//refer to the Raw Image box on the field
        img.enabled = false; //hide image untill new word is given
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update ()
    {
        word = Bubbles.GetWord();
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 5)
        {
            img.enabled = false;
        }
        //if the current word is different from the previous the image is changing 
        //
        if (word != currentWord)
        {
            img.enabled = true;
            ChangePicture();
            for(int i =1; i>=5; i++)
            {
                elapsedTime += Time.deltaTime;
            }
        }  
    }

    /// <summary>
    /// Method that changes the image for the current word
    /// </summary>
    public void ChangePicture()
    {
        currentWord = Bubbles.GetWord();
        GetComponent<RawImage>().texture = Resources.Load<Texture2D>(currentWord);
        img.enabled = true;
        elapsedTime = 0;
    }

}
