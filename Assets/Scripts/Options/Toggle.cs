using UnityEngine;

public class Toggle : MonoBehaviour {

    public bool active;
	
    public void changeToOn () {
        gameObject.GetComponentInParent<OnOffToggle>().active = true;
    }

    public void changeToOff(){
        gameObject.GetComponentInParent<OnOffToggle>().active = false;
    }
}
