using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Player))]
public class PlayerControls : MonoBehaviour
{
    private Player  m_Character;
    private float   moveHorizontal;
    private float   moveVertical;

    private void Awake()
    {
        m_Character = GetComponent<Player>();
    }
    
    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Call character atack
            m_Character.HandleAttack();
        }
        else {
            // Movimentation
            moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
            moveVertical = CrossPlatformInputManager.GetAxis("Vertical");
            m_Character.Move(moveHorizontal, moveVertical);
        }
    }
}