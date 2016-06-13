using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class changeImage : MonoBehaviour {
    public RawImage img;
    public string currentWord;

    // Use this for initialization
    void Start ()
    {
        img = GetComponent<RawImage>();//
        img.enabled = false; //hide image untill new word is given
    }
	
	// Update is called once per frame
	void Update ()
    {
        ChangePicture();
	}

    /// <summary>
    /// Method that changes the image for the current word
    /// </summary>
    public void ChangePicture()
    {
        string word = Bubbles.GetWord();
        GetComponent<RawImage>().texture = Resources.Load<Texture2D>(word);
        img.enabled = true;
    }
}
