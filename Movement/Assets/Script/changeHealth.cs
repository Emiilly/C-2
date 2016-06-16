using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class changeHealth : MonoBehaviour {
    /// <summary>
    /// Variables containing the sprites to change the health
    /// they are set in the unity GUI
    /// </summary>
    public Sprite fullHp;
    public Sprite twoHp;
    public Sprite oneHp;
    public Sprite dead;
    public Image sprite;
	// Use this for initialization
	void Start ()
    {
        sprite = GetComponent<Image>(); //refer to the Image box on the field
    }
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update ()
    {
        CheckHealth();//call check health method every frame
    }

    /// <summary>
    /// Method that checks the lives variable from Bubbles class and shows 
    /// different sprite dependng on the lives
    /// </summary>
    public void CheckHealth()
    {
        //get value for lives
        int lives = Bubbles.getNumberLives();
        if (lives == 3)
        {
            sprite.sprite = fullHp;
        }
        else if(lives == 2)
        {
            sprite.sprite = twoHp;
        }
        else if(lives == 1)
        {
            sprite.sprite = oneHp;
        }
        //if no lives left, the game ends and goes to the end game screen
        else
        {
            sprite.sprite = dead;
            Application.LoadLevel(4);//end game screen
        }
    }
}

