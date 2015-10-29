using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	private int health;
	public int Health {
		get {
			return health;
		}

		set {
			Debug.Log (value);
			if (value > 0 && value < 11) {
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

		Debug.Log ("Hit!");
		Debug.Log (health);
	}

	virtual public void Die() {
		Debug.Log("Character is dead");
	}
}