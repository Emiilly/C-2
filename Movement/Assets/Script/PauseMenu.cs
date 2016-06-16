using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;

    private bool paused = false;

    /// <summary>
    /// Makes sure that the pause menu is inactive when loaded
    /// </summary>
    void Start()
    {
        PauseUI.SetActive(false);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
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

    /// <summary>
    /// When resume get to play again
    /// </summary>
    public void Resume()
    {
        paused = false;
    }

    /// <summary>
    /// Reloads the scene again
    /// </summary>
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    /// <summary>
    /// Returns back to the main menu scene
    /// </summary>
    public void MainMenu()
    {
        Application.LoadLevel(0);
    }

    /// <summary>
    /// Application quits and close when clicked on
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
