using UnityEngine;
using System.Collections;

 public class Util : MonoBehaviour {

	public void LoadScene(string levelName, float time){

		GameObject fader = GameObject.FindGameObjectWithTag("Fader");

		if(time == 0) {
			StartCoroutine(fadeElement("in",fader,1));
			StartCoroutine(LoadAfterDelay(levelName,1));
		} else {
			StartCoroutine(waitToSceneChange(fader,levelName,time));
		}
	}

	private IEnumerator waitToSceneChange(GameObject fader,string levelName, float time){
		//Delay
		yield return new WaitForSeconds(time);

		StartCoroutine(fadeElement("in",fader,1));
		StartCoroutine(LoadAfterDelay(levelName,1));
	}

	private IEnumerator LoadAfterDelay(string levelName, float time){
		//Delay
		yield return new WaitForSeconds(time);

		//Change Scene
		Application.LoadLevel(levelName);
	}

	public IEnumerator fadeElement(string types,GameObject obj, float time){
		CanvasGroup componetCanvasGroup = obj.GetComponent<CanvasGroup>();

		//Fade In
		if (types == "in") {
			while (componetCanvasGroup.alpha <= 1) {
				componetCanvasGroup.alpha += Time.deltaTime / time;
				yield return null;
			}
		}

		//Fade Out
		else if (types == "out") {
			while (componetCanvasGroup.alpha > 0) {
				componetCanvasGroup.alpha -= Time.deltaTime / time;
				yield return null;
			}
		}
	}

}
