using UnityEngine;
using System.Collections;

public class SceneIntroController:Util{
	
	public string loadScene;
	public float loadSceneDelay;
	
	void Start(){
		LoadScene(loadScene, loadSceneDelay);
	}

}
