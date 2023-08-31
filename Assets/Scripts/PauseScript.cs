using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PauseScript : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
    private void Start()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
        OnPause();
    }
    public void OnPause()
    {
        if (Time.timeScale == 1 && Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        }

        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
        }
    }
}
