using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Rigidbody2D rb;

	public float speed;
	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
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
}
