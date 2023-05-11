using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
	
   public static bool  isRestart = false;

	private void Awake()
	{
		
	}

	public void RestartGame()
	{
		isRestart = true;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void CloseWindow()
	{
		isRestart = false;
	}
}
