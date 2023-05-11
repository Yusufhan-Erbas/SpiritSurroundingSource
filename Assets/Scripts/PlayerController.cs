using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	Rigidbody2D rb;
	Transform parentHost;
	Animator ghostAnim;
	[SerializeField]
	Text scoreText;
	[SerializeField]
	GameObject restartPanel;

	public float speed;
	public static bool isCapture = false;
	int score = 0;
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		ghostAnim = GetComponent<Animator>();
		parentHost = GameObject.FindWithTag("Host").transform;
	}

	private void Start()
	{
		PlayerPrefs.SetString("Score", score.ToString());
		PlayerPrefs.Save();

		scoreText.text = "SCORE " + PlayerPrefs.GetString("Score");
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			RestartGame();
		}
	}
	private void FixedUpdate()
	{
		MoveHorizontal();
		MoveVertical();
	}


	#region Ghost Move
	void MoveHorizontal()
	{
		if (Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector2.right * speed * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.A))
		{
			transform.Translate(Vector2.left * speed * Time.deltaTime);
		}
	}

	void MoveVertical()
	{
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector2.up * speed * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector2.down * speed * Time.deltaTime);
		}
	}
	#endregion

	#region Ghost Capture Host
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Host"))
		{
			isCapture = true;
			StartCoroutine(Capture());
		}
		else
		{
			isCapture = false;
		}
	}

	IEnumerator Capture()
	{
		ghostAnim.SetBool("isCapture", true);
		yield return new WaitForSeconds(1f);
		gameObject.transform.SetParent(parentHost);
		yield return new WaitForSeconds(1f);
		gameObject.SetActive(false);
	}
	#endregion

	#region Ghost Second Form
	void Evolve()
	{

	}
	#endregion

	#region Restart Game
	void RestartGame()
	{
		if (GameManager.isRestart == false ? GameManager.isRestart = true : GameManager.isRestart = false) ;
		if (GameManager.isRestart)
		{
			StartCoroutine(PanelGrowAnim());
		}
		else if (!GameManager.isRestart)
		{
			StartCoroutine(PanelReduceAnim());
		}
		IEnumerator PanelGrowAnim()
		{
			float increase = 0.05f;
			restartPanel.SetActive(true);
			restartPanel.gameObject.transform.localScale = new Vector2(0f,0f);
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
