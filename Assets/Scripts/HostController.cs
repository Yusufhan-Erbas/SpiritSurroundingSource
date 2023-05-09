using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostController : MonoBehaviour
{
	Rigidbody2D rb;
	public float speed = 20f;
	bool isCaptureStart = false;
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
			if (!isCaptureStart)
			{
				StartCoroutine(HostCaptured());
				return;
			}
			else if(isCaptureStart)
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
		}
		IEnumerator HostCaptured()
		{
			yield return new WaitForSeconds(2f);
			isCaptureStart = true;
		
		}
	
	}
	#endregion
}
