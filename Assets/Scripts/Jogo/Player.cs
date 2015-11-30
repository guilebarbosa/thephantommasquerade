using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float m_MaxSpeed = 10f;         // The fastest the player can travel in the x axis.

    [SerializeField]
    private LayerMask m_LimitTop;           // A mask determining what is peak to the character

    [SerializeField]
    private LayerMask m_LimitBottom;        // A mask determining what is ground to the character

    [SerializeField]
    private LayerMask m_LimitX;             // A mask determining what is left and right limit to the character

    private Transform m_GroundCheck;        // A position marking where to check if the player is grounded.
    const float k_GroundedRadius = .3f;     // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;                // Whether or not the player is grounded.
    private bool m_AtMaxHeight;			    // Whether or not the player has hit the ceiling;
    const float k_CeilingRadius = .01f;     // Radius of the overlap circle to determine if the player can stand up

    private Animator m_Anim;                // Reference to the player animator component.
    private Rigidbody2D m_Rigidbody2D;      // Reference to the player Rigidbody component.
    private bool m_FacingRight = true;      // For determining which way the player is currently facing.
    private Vector3 originalScale;
    
    private void Awake()
    {
        // Setting up references.
        m_GroundCheck = transform.Find("GroundCheck");
        m_Anim        = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
       
        SetScale();
    }


    private void FixedUpdate()
    {
        m_Grounded = false;
        m_AtMaxHeight = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] groundCollliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_LimitBottom);
        for (int i = 0; i < groundCollliders.Length; i++){
            if (groundCollliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
            }
        }

        Collider2D[] peakColliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_LimitTop);
        for (int i = 0; i < peakColliders.Length; i++){
            if (peakColliders[i].gameObject != gameObject)
            {
                m_AtMaxHeight = true;
            }
        }
        
    }
    
    public void HandleHit(){
        m_Anim.SetTrigger("Hit");
    }

    public void HandleAttack(){
        m_Anim.SetTrigger("Attacking");
    }

    public void Move(float moveX, float moveY){
        float moveSpeed = (moveX != 0 ? moveX : moveY);

        // Will not call animation if the player is grounded and moving down or at the max Y position and moving up
        if (moveY > 0 && m_AtMaxHeight || moveY < 0 && m_Grounded){
            moveY = 0;
            moveSpeed = moveX;
        };
        
        // The Speed animator parameter is set to the absolute value of the horizontal input.
        m_Anim.SetFloat("Speed", Mathf.Abs(moveSpeed));

        // Move the character
        m_Rigidbody2D.velocity = new Vector2(moveX * m_MaxSpeed, moveY * m_MaxSpeed);
        
        if (moveX > 0 && !m_FacingRight){
            Flip();
        }
        else if (moveX < 0 && m_FacingRight){
            Flip();
        }

        if (moveY != 0){
            SetScale();
        }
    }

    private void SetScale(){
        float scaleFactor = 100 - transform.position.y * 7;
        var x = originalScale.x * scaleFactor / 100;
        var y = originalScale.y * scaleFactor / 100;

        x = m_FacingRight ? x : x * -1;
        
        transform.localScale = new Vector3(x, y, 1);
    }

    private void Flip(){
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

