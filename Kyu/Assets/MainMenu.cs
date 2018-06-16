using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


	public void PlayGame()
    {
        //Carga la siguiente escena en la cola.  File/Build Settings
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       // SceneManager.LoadScene(gameScene.buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
