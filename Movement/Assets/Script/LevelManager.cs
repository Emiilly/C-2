using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{


    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void LoadScene(int name)
    {
       //Gets the int of the screen that the user wants to load 
       //and sends them to the correct scene
       Application.LoadLevel(name);
    }
}
