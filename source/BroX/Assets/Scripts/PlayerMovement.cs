using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float sideForce = 3f;
	public float updirection = 5f;


	public Rigidbody playerBody;

	private bool canMove = true;
	private CharacterController controller;
    private Animator playerAnimation;
    private Vector3 direction;
	private float gravity = -10f;

	// Use this for initialization
	void Start()
	{
		playerBody = GetComponent<Rigidbody>();
		controller = GetComponent<CharacterController>();
		playerAnimation = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (canMove)
		{
			// for horizontal move
			direction.x = Input.GetAxis("Horizontal") * sideForce;

			// for gravity
			if (direction.y > -8) direction.y += gravity * Time.deltaTime;

			// rotate to the face direction
			transform.forward = new Vector3(-direction.x, 0, -(float)(Mathf.Abs(direction.x) - 3f));

			if (Input.GetButtonDown("Jump") && controller.isGrounded)
			{
				direction.y = updirection;
			}

			// for jump animation.
			if(controller.isGrounded) playerAnimation.SetBool("makeJump", false);
			else playerAnimation.SetBool("makeJump", true);

			playerAnimation.SetFloat("VerticalSpeed", direction.y);
			// for run animation
			playerAnimation.SetFloat("Speed", direction.x);

			controller.Move(direction * Time.deltaTime);
		}
	}

    private void FixedUpdate()
    {
		
	}
}
