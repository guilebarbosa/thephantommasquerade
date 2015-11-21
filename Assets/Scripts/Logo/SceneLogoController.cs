using UnityEngine;
using System.Collections;

public class SceneLogoController:Util{

	public float loadNavBarDelay;
	public GameObject logo;

	void Start(){
		StartCoroutine (LoadMenu ());
	}

	private IEnumerator LoadMenu(){
		//Delay
		yield return new WaitForSeconds(loadNavBarDelay);

		logo.GetComponent<RectTransform> ().localPosition = new Vector3(-225f, 0, 0);

		Debug.Log(logo);

		//-225px

	}
}