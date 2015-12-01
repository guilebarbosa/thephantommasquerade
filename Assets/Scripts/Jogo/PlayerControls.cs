using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Player))]
public class PlayerControls : MonoBehaviour
{
    private Player      m_Character;        // Script Player.cs
    private Animator    m_Animator;         // Componente Animator
    private int         health = 10;        // Character Heath max
    private float       lifeBarSpeed = 10f; // Speed animator lifeBar
    private bool        die;                // True -> die; False -> Live 

    public Slider       healthSlider;       // Object Slider
    public string       gameOverSceneName;  // Scene Load after game over

    //?
    private GameObject  childTrigger;
    private Collider2D  coliderAtaque;
    private bool        atacando;
    private float       atackCD = 0.3f;
    private float       atackTimer = 0f;

    private void Awake()
    {
        m_Character = GetComponent<Player>();
        m_Animator = GetComponent<Animator>();

        //?
        childTrigger = transform.FindChild("AtackTrigger").gameObject;
        coliderAtaque = childTrigger.GetComponent<Collider2D>();
        coliderAtaque.enabled = false;
    }

    private void FixedUpdate()
    {
        m_Animator.SetBool("Attacking", atacando);
        if (!die)
        {
            // Attack
            if (Input.GetButtonDown("Fire1"))
            {
                coliderAtaque.enabled = true;
                atackTimer = atackCD;
                atacando = true;
            }
            else
            {
                atacando = false;
                coliderAtaque.enabled = false;
            }

            // Movimentation
            if (!m_Animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack") && !m_Animator.GetCurrentAnimatorStateInfo(0).IsTag("Hit"))
            {
                m_Character.Move(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));
            }

            // Health Controller
            ChangeHealthStats();
        }
        else
        {
            // Call to Game Over Scene
            StartCoroutine(GameOver(gameOverSceneName, 1));
        }
    }

    private void takingHITS(int dmg)
    {
        Debug.Log("tomando porrada");
        health -= dmg;
        m_Character.HandleHit();
    }

    private void ChangeHealthStats()
    {
        healthSlider.value = Mathf.Lerp(healthSlider.value, health, lifeBarSpeed * Time.deltaTime);

        if (health <= 0)
        {
            health = 0;
            die = true;
            m_Animator.SetTrigger("Dead");
        }
    }

    private IEnumerator GameOver(string levelName, float time)
    {
        if (!m_Animator.GetCurrentAnimatorStateInfo(0).IsTag("Die"))
        {
            //Delay
            yield return new WaitForSeconds(time);

            //Change Scene
            Application.LoadLevel(levelName);
        }
    }

}