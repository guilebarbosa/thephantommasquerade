using UnityEngine;

public class TriggerChild : MonoBehaviour
{
    public bool state;
    public bool isPlayerOnSight;
    public Vector2 moveDirection;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        IsPlayerOnSight();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == player)
        {
            isPlayerOnSight = true;
            state = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject == player)
        {
            isPlayerOnSight = false;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject == player)
        {

            if (Vector2.Distance(this.transform.position, player.transform.position) > 1.5f)
            {
                state = true;
            }

            if (Vector2.Distance(this.transform.position, player.transform.position) < 1.5f)
            {
                state = false;
            }
        }
    }

    void IsPlayerOnSight()
    {
        if (isPlayerOnSight)
        {
            moveDirection = player.transform.position - transform.position;
        }
    }
}
