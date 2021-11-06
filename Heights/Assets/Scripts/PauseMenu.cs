using System.Collections;
using TMPro;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject player;
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject countdownMenu;
    public TMP_Text timerText;
    public GameObject optionMenuUI;

    void Update()
    {
        if (!Model.isDead && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space)))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        countdownMenu.SetActive(true);
        StartCoroutine(WaitResume());
    }

    IEnumerator WaitResume()
    {
        int countdownTime = 3;
        countdown(countdownTime);
        yield return new WaitForSecondsRealtime(1);
        countdownTime--;
        countdown(countdownTime);
        yield return new WaitForSecondsRealtime(1);
        countdownTime--;
        countdown(countdownTime);
        yield return new WaitForSecondsRealtime(1);
        ResumeGame();
    }

    void ResumeGame()
    {
        countdownMenu.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        gameIsPaused = false;
    }

    private void countdown(int second)
    {
        timerText.text = second.ToString();
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
        gameIsPaused = true;
    }

    public void OpenOptionMenu()
    {
        optionMenuUI.GetComponent<OptionMenu>().SetBackMenuUI(pauseMenuUI);
        optionMenuUI.SetActive(true);   
        pauseMenuUI.SetActive(false);
    }

    public void Quit()
    {
        PlayerPrefs.SetFloat("pyrX", player.transform.localPosition.x);
        PlayerPrefs.SetFloat("pyrY", player.transform.localPosition.y);

        AudioSource song = player.GetComponentInChildren<AudioSource>();
        float songTime = (float)song.time;
        PlayerPrefs.SetFloat("songTime", songTime);
        Application.Quit();
    }
}
