using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour{
    private int health;
    private float time = 5f;
    private float flashSpeed = 3f;
    private float lifeBarSpeed = 10f;
    private Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    public Slider healthSlider;
    public Image damageImage;

    bool damaged;

    public int Health{
        get { return health; }

        set{
            Debug.Log(value);
            health = value;
        }
    }

    public void Bleed(int amount){
        health -= amount;

        damaged = true;
    }

    virtual public void Die(){
        Debug.Log("Character is dead");
    }

    void Update(){
        if (damaged){
            damageImage.color = flashColour;
        }
        else{
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        healthSlider.value = Mathf.Lerp(healthSlider.value, health, lifeBarSpeed * Time.deltaTime);

        if (health <= 0){
            health = 0;
            Die();
        }
        damaged = false; 
    }

}