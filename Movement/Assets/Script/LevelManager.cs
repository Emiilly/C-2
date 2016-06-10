using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour {

	public void LoadScene(int name)
    {

        //SceneManager.LoadScene(name);   maybe change to this in the future at some point
       Application.LoadLevel(name);
       
    }
}
