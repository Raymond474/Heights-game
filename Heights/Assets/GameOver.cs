using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public AudioSource song;
    public TMP_Text deathsText;

    public void Setup(Collider2D collision)
    {
        destroyObjects(collision);//make death animation and game over screen allowing to restart
        DeathModel.deaths++;
        deathsText.text = "Deaths: " + DeathModel.deaths.ToString();
        gameObject.SetActive(true);
    }

    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene("Game2.0");
    }

    public void setSong(AudioSource song)
    {
        this.song = song;
    }

    private void destroyObjects(Collider2D collision)
    {
        Destroy(collision.GetComponent<SpriteRenderer>());//make death animation and game over screen allowing to restart
        Destroy(collision.GetComponent<Rigidbody2D>());
        Destroy(collision.GetComponent<Movement>());
        song = collision.GetComponentInChildren<AudioSource>();
        song.Stop();
    }

    
}
