
using System.Collections;
using Assets.Script;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelChooser : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    private void OnTriggerEnter2D()
    {
       //gets the gameobjects name to retrieve the correct array for the level
        Words.setLevel(gameObject.name);
        Debug.Log("Level is now " + gameObject.name);
        SceneManager.LoadScene("Game");
       


    }

}
