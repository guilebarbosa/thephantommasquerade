using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class AI_ENEMY : MonoBehaviour
{
    public bool         ataque;
    public Vector2      moveDirection;
    public TriggerChild shortcut;
    public GameObject   childTrigger;

    private Collider2D  coliderAtaque;
    private bool        atacando = false;
    private Enemy       m_Character;        // Script Enemy.cs
    private Animator    m_Animator;         // Componente Animator    
    private bool        die;                // True -> die; False -> Live 
    private int         currentHealth = 2;

    void Start()
    {
        shortcut = gameObject.GetComponentInChildren<TriggerChild>();
        coliderAtaque = childTrigger.GetComponent<Collider2D>();
        coliderAtaque.enabled = false;
    }

    private void Awake()
    {
        m_Character = GetComponent<Enemy>();
        m_Animator = GetComponent<Animator>();
        ataque = true;
    }

    private void FixedUpdate()
    {
        m_Animator.SetBool("Attacking", atacando);

        if (!die)
        {
            // Movimentation
            if (!m_Animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack") && !m_Animator.GetCurrentAnimatorStateInfo(0).IsTag("Hit"))
            {
                if (shortcut.state)
                {
                    m_Character.Move(shortcut.moveDirection.normalized.x / 4, shortcut.moveDirection.normalized.y / 4);
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
            atacando = false;
            coliderAtaque.enabled = false;
        }
    }

    private IEnumerator Attack(float time)
    {
        yield return new WaitForSeconds(time);
        coliderAtaque.enabled = true;
        atacando = true;
        ataque = false;
    }

    private void takingHITS(int dmg)
    {
        currentHealth -= dmg;
        m_Character.HandleHit();
        if (currentHealth < 1)
        {
            die = true;
        }
    }


}

