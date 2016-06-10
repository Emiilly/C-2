using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public RawImage img;
    public string[] words;
    public Bubbles bubbles = new Bubbles();
    // Use this for initialization
    void Start ()
    {
        words = new string[10];
        words[0] = "banana";
        words[1] = "apple";
        words[2] = "kiwi";
        words[3] = "mango";
        //turns off the image until it is called from the changePicture class
        img.enabled = false;

     //   string word = bubbles.GetWord();

    }
	
	// Update is called once per frame
	void Update ()
    {
        //ChangePicture();
    }

    /// <summary>
    /// This class
    /// </summary>
    public void ChangePicture(string word)
    {
        img.enabled = true;
     //   string word = "";
        int index = Random.Range(0, 3);
        word = words[index];

        GetComponent<RawImage>().texture = Resources.Load<Texture2D>(word);
    }
}
