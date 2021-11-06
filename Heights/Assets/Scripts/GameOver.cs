using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TMP_Text deathsText;
    public GameObject optionMenuUI;

    public void Setup(Collider2D collision)
    {
        Model.isDead = true;
        destroyObjects(collision);
        DeathZone.deaths++;
        PlayerPrefs.SetInt("pyrDeathCount", DeathZone.deaths);
        PlayerPrefs.SetFloat("pyrX", (float)-9.323);
        PlayerPrefs.SetFloat("pyrY", 5);
        float songTime = (float)StartMusic.songStartTime;
        PlayerPrefs.SetFloat("songTime", 0);
        deathsText.text = "Deaths: " + DeathZone.deaths.ToString();
        gameObject.SetActive(true);       
    }

    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void Retry()
    {
        Model.isDead = false;
        SceneManager.LoadScene("Game2.0");
    }

    private void destroyObjects(Collider2D collision)
    {
        Destroy(collision.GetComponent<SpriteRenderer>());
        Destroy(collision.GetComponent<Rigidbody2D>());
        Destroy(collision.GetComponent<Movement>());
        AudioSource song = collision.GetComponentInChildren<AudioSource>();
        song.Stop();
    }

    public void OpenOptionMenu()
    {
        optionMenuUI.GetComponent<OptionMenu>().SetBackMenuUI(this.gameObject);
        this.gameObject.SetActive(false);
        optionMenuUI.SetActive(true);       
    }

    public void Quit()
    {
        PlayerPrefs.SetInt("pyrDeathCount", DeathZone.deaths);
        Application.Quit();
    }
}
