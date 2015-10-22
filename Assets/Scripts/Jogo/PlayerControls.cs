using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof (Player))]
public class PlayerControls : MonoBehaviour
{
    private Player m_Character;
    private bool m_Jump;
	private bool m_Attack;


    private void Awake()
    {
        m_Character = GetComponent<Player>();
    }


    private void Update()
    {
        if (!m_Jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            m_Jump = Input.GetKey(KeyCode.Space);
        }

		m_Attack = Input.GetMouseButtonDown(0);
    }


    private void FixedUpdate()
    {
        // Read the inputs.
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis("Vertical");
//		float h = Input.GetAxisRaw ("Horizontal");
//		float v = Input.GetAxisRaw ("Vertical");

        // Pass all parameters to the character control script.
        m_Character.Move(h, v, crouch, m_Jump);
        m_Jump = false;
		 
		if (m_Attack) {
			m_Character.Attack ();
		}
    }
}