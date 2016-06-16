
using System.Collections;
using Assets.Script;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelChooser : MonoBehaviour
{
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    /// <summary>
    /// gets the gameobjects name to retrieve the correct array for the level
    /// </summary>
    private void OnTriggerEnter2D()
    {
        Words.setLevel(gameObject.name);
        Debug.Log("Level is now " + gameObject.name);
        SceneManager.LoadScene("Game");
    }

}
