using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
	[SerializeField]
	GameObject restartPanel;

	public static bool  isRestart = false;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			//RestartPanel is Open first
			RestartPanel();
		}
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
		isRestart = true;
		RestartPanel();
	}

	#region Restart Panel
	void RestartPanel()
	{		
		if (!isRestart)
		{
			StartCoroutine(PanelGrowAnim());
			isRestart = true;
		}
		else if (isRestart)
		{
			StartCoroutine(PanelReduceAnim());
			isRestart = false;
		}
		IEnumerator PanelGrowAnim()
		{
			float increase = 0.05f;
			restartPanel.SetActive(true);
			restartPanel.gameObject.transform.localScale = new Vector2(0f, 0f);
			for (int i = 0; i < 20; i++)
			{
				yield return new WaitForSeconds(0.05f);
				restartPanel.gameObject.transform.localScale = new Vector2((0f + increase), (0f + increase));
				increase += 0.05f;
			}
		}
		IEnumerator PanelReduceAnim()
		{
			float reduce = 0.05f;
			for (int i = 0; i < 20; i++)
			{
				yield return new WaitForSeconds(0.05f);
				restartPanel.gameObject.transform.localScale = new Vector2((1f - reduce), (1f - reduce));
				reduce += 0.05f;
			}
			restartPanel.SetActive(false);

		}
	}
	#endregion
}
