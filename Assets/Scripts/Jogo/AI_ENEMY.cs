using System.Collections;
using UnityEngine;
using UnityEngine.UI;

	[RequireComponent(typeof (Enemy))]
	public class AI_ENEMY : MonoBehaviour {	

		public bool ataque;
		public Vector2 moveDirection;		
		public TriggerChild shortcut;
		private Enemy m_Character;        // Script Enemy.cs
        private Animator m_Animator;         // Componente Animator    
        private bool die;                // True -> die; False -> Live 
        private int currentHealth = 2;


        void Start () 
		{
			shortcut = gameObject.GetComponentInChildren<TriggerChild> ();		
		}
        private void Awake()
        {
            m_Character = GetComponent<Enemy>();
            m_Animator = GetComponent<Animator>();
            ataque = true;
        }

        private void FixedUpdate()
        {
            
            if (!die)
            {         
              // Movimentation
                if (!m_Animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack") && !m_Animator.GetCurrentAnimatorStateInfo(0).IsTag("Hit"))
                    {
                    if (shortcut.state)
                        {
                            m_Character.Move(shortcut.moveDirection.normalized.x/4, shortcut.moveDirection.normalized.y/4);
                        }
                    else
                        {
                         m_Character.Move(0f, 0f);
                         if (shortcut.isPlayerOnSight)
                            {
                               StartCoroutine("Attack", 1f);
                            }
                        }
                ataque = true;
                    }
                
            }
            else
            {
                Destroy(this.gameObject);
            }
        if (!ataque)
        {
            StopCoroutine("Attack");
        }
    }
    private IEnumerator Attack  (float time)
    {
        yield return new WaitForSeconds(time);
        m_Character.HandleAttack();
        ataque = false; 
    }

    private void  takingHITS(int dmg)
    {
        Debug.Log("tomando porrada");
        currentHealth -= dmg;
        m_Character.HandleHit();
        if (currentHealth < 1)
        {
            die = true;
        }
    }
    

}

