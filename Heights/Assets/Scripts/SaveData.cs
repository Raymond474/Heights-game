using System.Collections;
using TMPro;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public GameObject countdownMenu;
    public GameObject player;
    public TMP_Text timerText;
    void Start()
    {
        if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
        {   
            PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);
            Time.timeScale = 0f;
            countdownMenu.SetActive(true);
            StartCoroutine(WaitResume());
        }
        else
        {
        }

        if (PlayerPrefs.HasKey("pyrX"))
        {
            if (PlayerPrefs.GetFloat("pyrY") != 5 || PlayerPrefs.GetFloat("pyrX") != (float)-9.323)
            {
                Vector3 position = new Vector3(PlayerPrefs.GetFloat("pyrX"), PlayerPrefs.GetFloat("pyrY"), -1);
                Quaternion quaternion = new Quaternion(0, 0, 0, 0);
                player.transform.SetPositionAndRotation(position, quaternion);
                Time.timeScale = 0f;
                countdownMenu.SetActive(true);
                StartCoroutine(WaitResume());
            }
            else
            {
            }
        }

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
        AudioSource song = player.GetComponentInChildren<AudioSource>();
        song.time = PlayerPrefs.GetFloat("songTime");
        song.Play();
        StartMusic.songStartTime = PlayerPrefs.GetFloat("songTime");
        countdownMenu.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    private void countdown(int second)
    {
        timerText.text = second.ToString();
    }
}
