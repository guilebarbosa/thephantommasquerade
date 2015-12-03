using UnityEngine;

public class Toggle : MonoBehaviour {

    public bool active;

    void Start() {
        int status = PlayerPrefs.GetInt("Musica Ativa");

        if (status == 1 || status == 0)
        {
            changeToOn();
        }
        else {
            changeToOff();
        }
    }

    public void changeToOn() {
        gameObject.GetComponentInParent<OnOffToggle>().active = true;
        Camera.main.gameObject.GetComponent<AudioListener>().enabled = true;
        PlayerPrefs.SetInt("Musica Ativa",1);
    }

    public void changeToOff(){
        gameObject.GetComponentInParent<OnOffToggle>().active = false;
        Camera.main.gameObject.GetComponent<AudioListener>().enabled = false;
        PlayerPrefs.SetInt("Musica Ativa", 2);
    }
}
