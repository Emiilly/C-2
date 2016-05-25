using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadScene(int name)
    {
        Application.LoadLevel(name);
    }
}
