using UnityEngine;
using System.Collections;

public class labelVideo:Util {

	public float timeToShowLabel;
	public float timeToFadeInLabel;

	void Start () {
		StartCoroutine(callLabel());
	}

	private IEnumerator callLabel(){
		//Delay
		yield return new WaitForSeconds(timeToShowLabel);
		
		StartCoroutine(fadeElement("in",gameObject,timeToFadeInLabel));
	}

}
