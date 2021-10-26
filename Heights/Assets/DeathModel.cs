using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathModel : MonoBehaviour
{
    public static int deaths = 0;
    public static int maxFallSpeed = 1;
    public static int vertGravMag = -9;
    public static int horiGravMag = 0;//need to unfreeze x then freeze y and change how far you can move
}
