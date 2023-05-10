using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HostController : MonoBehaviour
{
	Rigidbody2D rb;
	Animator hostAnim;
	public float speed = 20f;
	bool isCaptureStart = false;
	bool isWalking=false;
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		hostAnim = GetComponent<Animator>();
	}

	private void FixedUpdate()
	{
		HostMove();
		HostTurn();
	}

	#region Host Move Controller
	void HostMove()
	{
		if (!PlayerController.isCapture)
		{
			return;

		}
		else if (PlayerController.isCapture)
		{
			if (!isCaptureStart)
			{
				StartCoroutine(HostCaptured());
				return;
			}
			else if(isCaptureStart)
			{
				if (Input.GetKey(KeyCode.D))
				{
					isWalking = true;
					transform.Translate(Vector2.right * speed * Time.deltaTime);
				}
				else if (Input.GetKey(KeyCode.A))
				{
					isWalking = true;					
					transform.Translate(Vector2.left * speed * Time.deltaTime);
				}
				else
				{
					isWalking = false;
				}
				hostAnim.SetBool("isWalk", isWalking);
			}
		}
		IEnumerator HostCaptured()
		{
			yield return new WaitForSeconds(2f);
			isCaptureStart = true;
		
		}
	
	}
	#endregion

	#region Host Turn
	void HostTurn()
	{
		if (Input.GetKey(KeyCode.D))
		{
			transform.localScale = new Vector2(1f, 1f);
		}
		else if(Input.GetKey(KeyCode.A))
		{
			transform.localScale = new Vector2(-1f, 1f);
		}
	}
	#endregion

	#region Level Up
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("OpenDoor"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
	#endregion
}
