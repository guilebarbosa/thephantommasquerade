using UnityEngine;
using System.Collections;

public class ScreenFader : Util {

	public float fadeOutTime = 1f;

	void Start () {
		gameObject.GetComponent<CanvasGroup>().alpha = fadeOutTime;
		StartCoroutine(fadeElement("out",gameObject,fadeOutTime));
	}
}