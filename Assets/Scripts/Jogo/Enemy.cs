using UnityEngine;

public class Enemy : MonoBehaviour {
    private float       m_MaxSpeed = 10f;       // The fastest the player can travel in the x axis.
    private Animator    m_Anim;                 // Reference to the player animator component.
    private Rigidbody2D m_Rigidbody2D;          // Reference to the player Rigidbody component.
    private bool        m_FacingRight = true;   // For determining which way the player is currently facing.
    private Vector3     originalScale;
  
    private void Awake()
    {
        // Setting up references.
        m_Anim = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;        
        SetScale();
    }
  
    public void Move(float moveX, float moveY)
    {
        // Move the character
        m_Rigidbody2D.velocity = new Vector2(moveX * m_MaxSpeed, moveY * m_MaxSpeed);

        if (moveX > 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (moveX < 0 && m_FacingRight)
        {
            Flip();
        }

        if (moveY != 0) { SetScale(); }
    }

    private void SetScale()
    {
        float scaleFactor = 100 - transform.position.y * 7;
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

    public void HandleHit()
    {
        m_Anim.SetTrigger("Hit");
    }
}
