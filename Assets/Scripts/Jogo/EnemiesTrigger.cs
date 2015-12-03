using UnityEngine;
public class EnemiesTrigger : MonoBehaviour
{
    public GameObject EnemyPrefab;
<<<<<<< HEAD
    
    

    void OnTriggerEnter2D (Collider2D col) {
        for (int i = 0; i < 4; i++)
        {
            if (i == 0)
            {
                
                    Instantiate(EnemyPrefab, (transform.position + (transform.right*25) +(transform.up*3)), Quaternion.identity);
            }
            if (i == 1)
            {
                    Instantiate(EnemyPrefab, (transform.position + (transform.right * 25) + (transform.up * (-3))), Quaternion.identity);
            }
            if (i == 2)
            {
                    Instantiate(EnemyPrefab, (transform.position + (transform.right * (-25)) + (transform.up * (-3))), Quaternion.identity);
            }
            if (i == 3)
            {
                    Instantiate(EnemyPrefab, (transform.position + (transform.right * (-25)) + (transform.up * (+3))), Quaternion.identity);
            }

        }
        Destroy(this.gameObject);
    }
    
=======

    void OnTriggerEnter2D(Collider2D col)
    {
        //Instantiate(EnemyPrefab, transform.position + (transform.right * 10), Quaternion.identity);
        Debug.Log("Enemies spawned");
        Destroy(this.gameObject);
    }

>>>>>>> origin/master
}
