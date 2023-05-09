using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostController : MonoBehaviour
{
	Rigidbody2D rb;
	public float speed = 20f;
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		HostMove();
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
			StartCoroutine(HostCaptured());
		}
		IEnumerator HostCaptured()
		{
			yield return new WaitForSeconds(1f);
			if (Input.GetKey(KeyCode.D))
			{
				transform.Translate(Vector2.right * speed * Time.deltaTime);
			}
			else if (Input.GetKey(KeyCode.A))
			{
				transform.Translate(Vector2.left * speed * Time.deltaTime);
			}
		}
	
	}
	#endregion
}
