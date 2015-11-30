using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject canvas;

    public GameObject pauseObject;

    private bool pause;
    private CanvasGroup pauseObj;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            pauseObj = pauseObject.GetComponent<CanvasGroup>();

            if (pause)
            {
                Time.timeScale = 1;
                pause = false;
                pauseObj.alpha = 0;
            }
            else
            {
                Time.timeScale = 0;
                pause = true;
                pauseObj.alpha = 1;
            }
        }
    }
}
