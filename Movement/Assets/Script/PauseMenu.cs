using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;

    private bool paused = false;
    //Makes sure that the pause menu is inactive when loaded
    void Start()
    {
        PauseUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }
        //if paused the game will pause, characters stop moving
        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        //when unpaused you can move again
        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    //When resume get to play again
    public void Resume()
    {
        paused = false;
    }
    //Reloads the scene again
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    //Returns back to the main menu scene
    public void MainMenu()
    {
        Application.LoadLevel(0);
    }
    //Application quits and close when clicked on
    public void Quit()
    {
        Application.Quit();
    }
}
