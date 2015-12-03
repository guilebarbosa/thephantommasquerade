using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyControls : MonoBehaviour
{
    public bool         ataque;
    public bool         InAtaque;
    public Vector2      moveDirection;
    public TriggerChild shortcut;
    public GameObject   childTrigger;

    private Collider2D  coliderAtaque;
    private Enemy       m_Character;        // Script Enemy.cs
    private Animator    m_Animator;         // Componente Animator    
    private bool        die;                // True -> die; False -> Live 
    private int         currentHealth = 10;
    private bool        playerIsDeath;

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
        ataque = false;
    }

    private void FixedUpdate()
    {
        // Verify character is alive
        playerIsDeath = !GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>().die;
        
        // Movimentation
        if (shortcut.state)
        {
            m_Character.Move(shortcut.moveDirection.normalized.x / 4, shortcut.moveDirection.normalized.y / 4);
        }
        else
        {
            m_Character.Move(0f, 0f);

            if (shortcut.isPlayerOnSight)
            {
                if (!ataque)
                {
                    ataque = true;
                    StartCoroutine("Attack", 1f);
                }
                else
                {
                    coliderAtaque.enabled = false;
                }
            }
        }
    }

    private IEnumerator Attack(float time)
    {
        yield return new WaitForSeconds(time);
        if (!die && playerIsDeath && !m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
        {
            coliderAtaque.enabled = true;
            m_Animator.SetTrigger("Attacking");
        }

        ataque = false;
    }
    
    private void takingHITS(int dmg)
    {
        if (currentHealth <= 0)
        {
            if (!die) {
                currentHealth = 0;
                die = true;
                m_Animator.SetTrigger("Dead");
                StartCoroutine(removeObject(.5f));
            }
        }
        else {
            currentHealth -= dmg;
            m_Character.HandleHit();
        }
    }

    private IEnumerator removeObject(float time)
    {
        if (!m_Animator.GetCurrentAnimatorStateInfo(0).IsTag("Die"))
        {
            //Delay
            yield return new WaitForSeconds(time);

            //Destroy
            Destroy(gameObject);
        }
    }
}

