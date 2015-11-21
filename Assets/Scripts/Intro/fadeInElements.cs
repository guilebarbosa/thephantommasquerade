using UnityEngine;
using System.Collections;

public class fadeInElements:Util {

	public float timeToShowLabel;
	public float timeToFadeInLabel;

	void Start () {
		gameObject.GetComponent<CanvasGroup> ().alpha = 0;
		StartCoroutine(callLabel());
	}

	private IEnumerator callLabel(){
		//Delay
		yield return new WaitForSeconds(timeToShowLabel);
		
		StartCoroutine(fadeElement("in",gameObject,timeToFadeInLabel));
	}

}
