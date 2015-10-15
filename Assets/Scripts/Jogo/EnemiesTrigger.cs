using UnityEngine;
using System.Collections;

public class EnemiesTrigger : MonoBehaviour {
	public GameObject SpawnPoint;
	private bool IsActivated = false;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (!IsActivated) {
			IsActivated = true;
			SpawnPoint.GetComponent<EnemiesSpawnPointController>().Spawn();
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
