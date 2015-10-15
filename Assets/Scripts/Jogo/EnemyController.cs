using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	private Rigidbody2D m_RidgidBody2D;
	// Use this for initialization
	void Start () {
		m_RidgidBody2D = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
