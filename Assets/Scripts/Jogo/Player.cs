using System;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
//        [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character
	[SerializeField] private LayerMask m_WhatIsMaxHeight;                  // A mask determining what is peak to the character

    private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
    const float k_GroundedRadius = .3f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.
	private bool m_AtMaxHeight;			// Whether or not the player has hit the ceiling;
    private Transform m_CeilingCheck;   // A position marking where to check for ceilings
    const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
    private Animator m_Anim;            // Reference to the player's animator component.
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 originalScale;

	private float jumpDelay = 0.26f;
	private float jumpTime;
	private bool jumped;

    private void Awake()
    {
        // Setting up references.
        m_GroundCheck = transform.Find("GroundCheck");
        m_CeilingCheck = transform.Find("CeilingCheck");
        m_Anim = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
		originalScale = transform.localScale;

		Health = 10;

		SetScale ();
    }


    private void FixedUpdate()
    {
        m_Grounded = false;
		m_AtMaxHeight = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] groundCollliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < groundCollliders.Length; i++)
        {
			if (groundCollliders[i].gameObject != gameObject) {
                m_Grounded = true;
			}
        }

		Collider2D[] peakColliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsMaxHeight);
		for (int i = 0; i < peakColliders.Length; i++)
		{
			if (peakColliders[i].gameObject != gameObject) {
				Debug.Log("Peak");
				m_AtMaxHeight = true;
			}
		}

        m_Anim.SetBool("Ground", true);

        // Set the vertical animation
        m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
    }


    public void Move(float moveX, float moveY, bool crouch, bool jump)
    {
		float moveSpeed = (moveX != 0 ? moveX : moveY);

        // If crouching, check to see if the character can stand up

        if (!crouch && m_Anim.GetBool("Crouch"))
        {
            // If the character has a ceiling preventing them from standing up, keep them crouching
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
            {
                crouch = true;
            }
        }

		if (jump) {
			jumped = true;
			jumpTime = jumpDelay;
			m_Anim.SetBool ("Jumping", true);
		}

		jumpTime -= Time.deltaTime;

		if (jumpTime <= 0 && jumped) {
			m_Anim.SetBool("Jumping", false);
			jumped = false;
		}

        // Set whether or not the character is crouching in the animator
        m_Anim.SetBool("Crouch", crouch);

        //only control the player if grounded or airControl is turned on
        if (m_AirControl)
        {
            // Reduce the speed if crouching by the crouchSpeed multiplier
            moveX = (crouch ? moveX * m_CrouchSpeed : moveX);

			// Will not call animation if the player is grounded and moving down or at the max Y position and moving up
			if (moveY > 0 && m_AtMaxHeight || moveY < 0 && m_Grounded) {
				moveY = 0;
				moveSpeed = moveX;
			};

            
			// The Speed animator parameter is set to the absolute value of the horizontal input.
			m_Anim.SetFloat("Speed", Mathf.Abs(moveSpeed));
            
			// Move the character
            m_Rigidbody2D.velocity = new Vector2(moveX * m_MaxSpeed, moveY * m_MaxSpeed);


            // If the input is moving the player right and the player is facing left...
            if (moveX > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
                // Otherwise if the input is moving the player left and the player is facing right...
            else if (moveX < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }

			if (moveY != 0) {
				SetScale();
			}
        }
    }

	private void SetScale() {
		float scaleFactor = 100 - transform.position.y * 10;
		var x = originalScale.x * scaleFactor / 100;
		var y = originalScale.y * scaleFactor / 100;

		x = m_FacingRight ? x : x * -1;


		transform.localScale = new Vector3(x, y, 1);
	}

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

