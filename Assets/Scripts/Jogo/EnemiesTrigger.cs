using UnityEngine;
public class EnemiesTrigger : MonoBehaviour
{
	public GameObject enemyPrefab;
	public GameObject[] enemySpawnPoints;
	public int numberOfEnemies;

	private Transform spawnPoint;

	void Awake() {

	}


    void OnTriggerEnter2D(Collider2D col)
    {
		for (int i = 0; i < enemySpawnPoints.Length; i++) {
			spawnEnemies(enemySpawnPoints[i].transform);
		}

        Destroy(this.gameObject);
    }

	private void spawnEnemies(Transform spawnPoint)
	{
		for (int i = 0; i < numberOfEnemies; i++)
		{
			var posX = Random.Range(spawnPoint.position.x - 1f, spawnPoint.position.x + 1f);
			var posY = Random.Range(spawnPoint.position.y - 1f, spawnPoint.position.y + 1f);
			
			Instantiate(enemyPrefab, new Vector3(posX, posY, 0), Quaternion.identity);
		}
	}
}
