using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Rigidbody2D rb;
	Transform parentHost;
	Animator ghostAnim;

	public float speed;
	public static bool isCapture = false;
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		ghostAnim = GetComponent<Animator>();
		parentHost = GameObject.FindWithTag("Host").transform;
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
			transform.Translate(Vector2.right*speed*Time.deltaTime);
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
			transform.Translate(Vector2.down*speed*Time.deltaTime);
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
		ghostAnim.SetBool("isCapture",true);
		yield return new WaitForSeconds(1f);
        gameObject.transform.SetParent(parentHost);
		yield return new WaitForSeconds(1f);
		gameObject.SetActive(false);
    }
    #endregion
}
