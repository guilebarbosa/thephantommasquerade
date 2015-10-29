using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Character : MonoBehaviour {
	private int health;
	private float time = 5f;

	public Slider healthSlider;

	public int Health {
		get {
			return health;
		}

		set {
			Debug.Log (value);
			health = value;
		}
	}

	public void Bleed(int amount) {
		health -= amount;

		healthSlider.value = health/10f; // Vida atual/Vida maxima

		if (health <= 0) {
			health = 0;
			Die();
		}
	}

	virtual public void Die() {
		Debug.Log("Character is dead");
	}
}