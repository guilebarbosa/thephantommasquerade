using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Player))]
public class PlayerControls : MonoBehaviour
{
    private Player      m_Character;
    private Animator    m_Animator;
    private int         health = 10;
    private float       lifeBarSpeed = 10f;

    public bool         die;
    public Slider       healthSlider;
    public string       gameOverSceneName;

    private void Awake()
    {
        m_Character = GetComponent<Player>();
        m_Animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (!die)
        {
            // Attack
            if (Input.GetButtonDown("Fire1"))
            {
                m_Character.HandleAttack();
            }

            // Movimentation
            if (!m_Animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack") && !m_Animator.GetCurrentAnimatorStateInfo(0).IsTag("Hit"))
            {
                m_Character.Move(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));
            }

            // Health Controller
            ChangeHelthStats();
        }
        else
        {
            // Call to Game Over Scene
            StartCoroutine(GameOver(gameOverSceneName, 1));
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
            m_Character.HandleHit();
        }
    }

    private void ChangeHelthStats()
    {
        healthSlider.value = Mathf.Lerp(healthSlider.value, health, lifeBarSpeed * Time.deltaTime);

        if (health <= 0)
        {
            health  = 0;
            die     = true;
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