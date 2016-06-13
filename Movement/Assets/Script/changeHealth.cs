using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class changeHealth : MonoBehaviour {
    public Sprite fullHp;
    public Sprite twoHp;
    public Sprite oneHp;
    public Sprite dead;
    public Image sprite;
	// Use this for initialization
	void Start ()
    {
        sprite = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        CheckHealth();
    }

    public void CheckHealth()
    {
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
        else
        {
            sprite.sprite = dead;
            Application.LoadLevel(4);
        }
    }
}

