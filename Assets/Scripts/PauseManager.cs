using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject pauseButton;
    public GameObject joystick;
    public GameObject nitroButton;

    public void Pause()
    {
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);

        if (joystick != null)
            joystick.SetActive(false);

        if (nitroButton != null)
            nitroButton.SetActive(false);

        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);

        if (joystick != null)
            joystick.SetActive(true);

        if (nitroButton != null)
            nitroButton.SetActive(true);

        Time.timeScale = 1f;
    }
}