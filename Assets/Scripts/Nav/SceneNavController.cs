using UnityEngine;
using System.Collections;

public class SceneNavController : Util {
	public string sceneName;
	public static float loadSceneDelay = 0f;

	public void changeScene(){
		LoadScene (sceneName, loadSceneDelay);
	}
}
