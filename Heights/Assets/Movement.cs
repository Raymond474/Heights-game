using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject player;
    public float horizontalMovement;
    private bool left;
    private bool right;
    private float playerX;
    private float playerY;
    private float playerZ;
    private Vector3 position = new Vector3();
    private Quaternion quaternion = new Quaternion(0, 0, 0, 0);

    void Update()
    {
        //float horizontalInt = Input.GetAxisRaw("Horizontal");
        /*
        float horizontalInt = Input.GetAxisRaw("Horizontal");

        if (horizontalInt == -1)
        {
            Debug.Log("left");
        }
        else if (horizontalInt == 1)
        {
            Debug.Log("right");
            //right = true;
        }
       
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            right = true;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            right = false;
        }
        */

        if (Input.GetKeyDown(KeyCode.D))//change this to a button
        {
            right = true;
        }
    }

    private void FixedUpdate()
    {

        if (right)
        {
            moveRight();
        }
    }

    private void moveRight()
    {
        Debug.Log("move");
        float playerX = player.transform.localPosition.x;//fix
        float playerY = player.transform.localPosition.y;
        float playerZ = player.transform.localPosition.z;

        playerX += 2;

        Vector3 position = new Vector3(playerX, playerY, playerZ);
        Quaternion quaternion = new Quaternion(0, 0, 0, 0);
        player.transform.SetPositionAndRotation(position, quaternion);

        position.x = player.transform.localPosition.x;
        player.transform.SetPositionAndRotation(position, quaternion);
        right = false;
        Debug.Log("moved");
    }
    //make camera follow player
}
