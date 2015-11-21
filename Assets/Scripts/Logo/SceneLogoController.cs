using UnityEngine;
using System.Collections;

public class SceneLogoController:Util{
	private GameObject canvas;

	public float loadNavBarDelay;
	public GameObject logo;
	public GameObject menu;

	bool menuIsLoad = false;

	void Start(){

		StartCoroutine (LoadMenu ());
	}

	private IEnumerator LoadMenu(){
		//Delay
		yield return new WaitForSeconds (loadNavBarDelay);

		menuIsLoad = true;

	}
	void Update(){
		if (menuIsLoad) {
			// Animate logo
			Vector3 currenPosition = logo.GetComponent<RectTransform> ().localPosition;
			logo.GetComponent<RectTransform> ().localPosition = Vector3.Lerp (currenPosition, new Vector3 (-225f, 0, 0), 2f * Time.deltaTime);

			//Animate Menu

		}else {
			//Esconder Menu
			canvas = GameObject.FindGameObjectWithTag("NavCanvas");
			float positionHideMenu = canvas.GetComponent<RectTransform>().rect.width + menu.GetComponent<RectTransform>().rect.width / 2; 

			Debug.Log (canvas.GetComponent<RectTransform>().rect.width);

			menu.GetComponent<RectTransform>().localPosition = new Vector3(positionHideMenu,0,0);

		}
	}

}