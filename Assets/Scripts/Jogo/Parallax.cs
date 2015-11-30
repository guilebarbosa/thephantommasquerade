using UnityEngine;

public class Parallax : MonoBehaviour {
	public Transform[] backgrounds;
	public float smoothing = 1f;

	private float[] parallaxScales;
	private Transform cam;
	private Vector3 previousCameraPosition;

	void Awake () {
		cam = Camera.main.transform;
	}

	// Use this for initialization
	void Start () {
		previousCameraPosition = cam.position;
		parallaxScales = new float[backgrounds.Length];

		for (int i = 0; i < backgrounds.Length; i++) {
			parallaxScales[i] = backgrounds[i].position.z;
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < backgrounds.Length; i++) {
			Transform background = backgrounds[i];
			float parallax = (previousCameraPosition.x - cam.position.x) * parallaxScales[i];
			float backgroundTargetPositionX = background.position.x - parallax;
			Vector3 backgroundTargetPosition = new Vector3(backgroundTargetPositionX, background.position.y, background.position.z);

			background.position = Vector3.Lerp(background.position, backgroundTargetPosition, smoothing * Time.deltaTime);
		}

		previousCameraPosition = cam.position;
	}
}
