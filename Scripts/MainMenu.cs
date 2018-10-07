using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    void Start()
    {
        
    }

    public void PlayGame()
	{
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		SceneManager.LoadScene(1);
        ScoreScript.ScoreValue = 0;
	}
	
	public void QuitGame()
	{
		Application.Quit();
	}
	
	public void BackToMenu()
	{
		SceneManager.LoadScene(0);
        ScoreScript.ScoreValue = 0;
    }
}
