using UnityEngine;
using UnityEngine.UI;

public class OnOffToggle : MonoBehaviour {

    public GameObject buttonOn;
    public GameObject buttonOff;
    public Sprite OnActive;
    public Sprite OnInactive;
    public Sprite OffActive;
    public Sprite OffInactive;
    public bool active = true;
    
    void Start () {
        if (active) {
            buttonOn.GetComponent<Image>().sprite = OnActive;
            buttonOff.GetComponent<Image>().sprite = OffInactive;
        }

        buttonOff.GetComponent<Toggle>().active =
        buttonOn.GetComponent<Toggle>().active = active;
    }
	
	void Update () {
        if (active) {
            buttonOn.GetComponent<Image>().sprite = OnActive;
            buttonOff.GetComponent<Image>().sprite = OffInactive;
        }
        else{
            buttonOn.GetComponent<Image>().sprite = OnInactive;
            buttonOff.GetComponent<Image>().sprite = OffActive;
        }

        buttonOff.GetComponent<Toggle>().active =
        buttonOn.GetComponent<Toggle>().active = active;
    }
}
