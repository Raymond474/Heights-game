using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public GameOver gameOver;
    public static int deaths;

    void Start()
    {
        if (!PlayerPrefs.HasKey("pyrDeathCount"))
        {
            PlayerPrefs.SetInt("pyrDeathCount", 0);
            deaths = 0;
        }
        else
        {
            deaths = PlayerPrefs.GetInt("pyrDeathCount");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameOver.Setup(collision);
    }
}
