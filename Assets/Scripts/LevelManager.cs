using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    
	public void LoadLevel(string name)
	{
        Debug.Log("Level load requested for : " + name);
        //For changing scenes use the new functions under scenemanager works in same way.
        SceneManager.LoadSceneAsync(name);
        
        //DEPRETIATED
        //Application.LoadLevel(name);   
    }

    public void QuitGame()
    {
        //Debug.Log("The User Has requested to Quit");
        Application.Quit();
    }
    
	public void LoadNextLevel()
	{
		SceneManager.LoadSceneAsync (Application.loadedLevel + 1);
		//Application.loadedLevel (Application.loadedLevel + 1);
	}
}
