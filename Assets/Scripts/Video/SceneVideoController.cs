using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SceneVideoController : Util {

	//Scene
	public string loadScene;
	public float loadSceneDelay;

	//Video
	public GameObject videoEmbed;
	public MovieTexture movie;

	private void Start () {
		loadVideo();
	}

	private void Update(){
		//Change Scene on Press Space bar
		if (Input.GetButtonDown ("Jump")) {
			loadNextScene();
		}
	}

	private void loadVideo(){
		AudioSource audio;

		//Get video components
		videoEmbed.GetComponent<RawImage>().texture = movie as MovieTexture;
		audio = videoEmbed.GetComponent<AudioSource> ();
		audio.clip = movie.audioClip;
		
		//Start video and set audio equals
		movie.Play ();
		audio.Play ();
		
		//Find end
		StartCoroutine(FindEndVideo());
	}

	private IEnumerator FindEndVideo(){
		
		//Verifies that is running
		while(movie.isPlaying){
			yield return null;
		}
		
		//Change Scene on movie ending
		loadNextScene ();
	}

	private void loadNextScene(){
		LoadScene (loadScene, loadSceneDelay);
	}
}