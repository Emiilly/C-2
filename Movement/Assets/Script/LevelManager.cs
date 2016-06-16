using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
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
    /// Gets the int of the screen that the user wants to load and sends them to the correct scene
    /// </summary>
    /// <param name="name"></param>
    public void LoadScene(int name)
    {
       Application.LoadLevel(name);
    }
}