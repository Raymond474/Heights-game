using TMPro;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public TMP_Text deathsText;

    public void Setup()
    {
        gameObject.SetActive(true);
        deathsText.text = "Deaths: " + DeathZone.deaths.ToString();
    }
}
