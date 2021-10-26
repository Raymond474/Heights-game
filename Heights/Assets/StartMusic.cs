using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
    public AudioSource song;
    public static double songStartTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        songStartTime = Time.realtimeSinceStartupAsDouble;
        song.Play();
        
    }
}
