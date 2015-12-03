using UnityEngine;
public class EnemiesTrigger : MonoBehaviour
{
    public GameObject EnemyPrefab;

    void OnTriggerEnter2D(Collider2D col)
    {
        //Instantiate(EnemyPrefab, transform.position + (transform.right * 10), Quaternion.identity);
        Debug.Log("Enemies spawned");
        Destroy(this.gameObject);
    }

}
