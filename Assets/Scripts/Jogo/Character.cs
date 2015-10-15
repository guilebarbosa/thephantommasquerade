using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	private int health;
	public int Health {
		get {
			return health;
		}

		set {
			if (value > 0 && value > 10) {
				health = value;
			} 
		}
	}

	public void Bleed(int amount) {
		health -= amount;

		if (health <= 0) {
			health = 0;
			Die();
		}
	}

	public void Die() {
		Debug.Log("Character is dead");
	}
}