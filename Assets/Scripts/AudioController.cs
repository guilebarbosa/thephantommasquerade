using UnityEngine;

public class AudioController : MonoBehaviour {
    
    private int status;
    private AudioSource c_audio;

    void Start()
    {
        c_audio = GetComponent<AudioSource>();
    }

    void Update () {
        status = PlayerPrefs.GetInt("Musica Ativa");

        c_audio.mute = status == 1 ? false : true;
    }
}
