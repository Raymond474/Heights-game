using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public GameOver gameOver;
    //public Sprite player2;
    //public static bool easyMode;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameOver.Setup(collision);
        /*
        if (!easyMode)
        {
            
        }
        else
        {
            //collision.GetComponent<SpriteRenderer>().sprite = player2;
        }
        */
    }
}
