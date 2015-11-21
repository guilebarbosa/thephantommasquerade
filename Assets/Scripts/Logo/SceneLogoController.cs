using UnityEngine;
using System.Collections;

public class SceneLogoController:Util{
	private GameObject canvas;
	
	public float loadNavBarDelay;
	public float timeAnimationNavBar;
	public GameObject logo;
	public GameObject menu;

	bool menuIsLoad = false;

	void Start(){
		StartCoroutine (LoadMenu());
	}

	private IEnumerator LoadMenu(){
		//Delay
		yield return new WaitForSeconds (loadNavBarDelay);

		menuIsLoad = true;

	}
	void Update(){
		//Informaçoes do canvas
		canvas = GameObject.FindGameObjectWithTag("NavCanvas");


		if (menuIsLoad) {
			// Animate logo
			Vector3 logoCurrenPosition = logo.GetComponent<RectTransform>().localPosition;
			logo.GetComponent<RectTransform>().localPosition = Vector3.Lerp(logoCurrenPosition, new Vector3(-225f, 0f, 0f), timeAnimationNavBar * Time.deltaTime);

			//Animate Menu
			RectTransform menuRect = menu.GetComponent<RectTransform>();
			Vector3 menuCurrenPosition = menuRect.localPosition;
			float positionShowMenu = canvas.GetComponent<RectTransform>().rect.width/2 - menu.GetComponent<RectTransform>().rect.width/2; 

			menuRect.localPosition = Vector3.Lerp(menuCurrenPosition, new Vector3(positionShowMenu, 0f, 0f), 2f * Time.deltaTime);
		}else {
			//Esconder Menu
			float positionHideMenu = canvas.GetComponent<RectTransform>().rect.width/2 + menu.GetComponent<RectTransform>().rect.width / 2; 
			menu.GetComponent<RectTransform>().localPosition = new Vector3(positionHideMenu,0,0);
		}
	}

}