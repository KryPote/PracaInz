using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool paused;
    public GameObject PauseUI;

    private void Start()
    {
        PauseUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause")) paused = !paused;
        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }
}