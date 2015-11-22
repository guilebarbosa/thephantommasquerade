using UnityEngine;

public class Toggle : MonoBehaviour {

    public bool active;
	
    public void changeToOn () {
        gameObject.GetComponentInParent<OnOffToggle>().active = true;

        Camera.main.gameObject.GetComponent<AudioListener>().enabled = true;
    }

    public void changeToOff(){
        gameObject.GetComponentInParent<OnOffToggle>().active = false;

        Camera.main.gameObject.GetComponent<AudioListener>().enabled = false;
    }
}
