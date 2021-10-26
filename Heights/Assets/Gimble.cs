using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimble : MonoBehaviour
{
    [SerializeField] Transform target;
    //might add variables for each position for when rotating the screen

    void Update()
    {
        transform.position = new Vector3(0, target.position.y, -10); //transform.position.x
    }
}
