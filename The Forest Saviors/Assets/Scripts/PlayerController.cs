﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	private Animator playerAnimator;
	private Rigidbody2D playerRb;

	private bool lookLeft;

	public float speed, jumpForce;

	private int idAnimation;

	private float h, v;
	

	// Use this for initialization
	void Start ()
	{
		playerAnimator = GetComponent<Animator>();
		playerRb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		playerRb.velocity = new Vector2(h*speed, playerRb.velocity.y);
	}

	// Update is called once per frame
	void Update ()
	{
		h = Input.GetAxisRaw("Horizontal");
		v = Input.GetAxisRaw("Vertical");

		if (h < 0 && !lookLeft)
		{
			flip();
		}
		else if (h > 0 && lookLeft)
		{
			flip();
		}

		if (v < 0)
		{
			idAnimation = 2;
		}
		else if (h != 0)
		{
			idAnimation = 1;
		}
		else
		{
			idAnimation = 0;
		}
		playerAnimator.SetInteger("idAnimation", idAnimation);
	}
	void flip(){
		lookLeft = !lookLeft;
		float x = transform.localScale.x;
		x *= -1;
		transform.localScale = new Vector3 (x, transform.localScale.y, transform.localScale.z);
	
	}
}


