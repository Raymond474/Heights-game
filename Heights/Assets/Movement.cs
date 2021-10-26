using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject player;
    public static float horizontalMovement;
    public static float verticalMovement;
    private bool left;
    private bool right;
    private bool up;
    private bool down;
    private float playerX;
    private float playerY;
    private float playerZ;
    private Vector3 position = new Vector3();
    private Quaternion quaternion = new Quaternion(0, 0, 0, 0);

    private void Start()
    {
        horizontalMovement = 6;
        verticalMovement = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.X))//change this to a button
        {
            right = true;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Z))//change this to a button
        {
            left = true;
        }
        /*
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))//change this to a button only allow at certain spots to prevent phasing
        {
            up = true;
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))//change this to a button
        {
            down = true;
        }
        */
    }

    private void FixedUpdate()
    {
        if (player.GetComponent<Rigidbody2D>().velocity.magnitude > DeathModel.maxFallSpeed)
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(DeathModel.horiGravMag, DeathModel.vertGravMag);
        }

        if (right)
        {
            moveRight();
        }
        if (left)
        {
            moveLeft();
        }
        if (up)
        {
            moveUp();
        }
        if (down)
        {
            moveDown();
        }
    }

    private void moveRight()
    {
        playerX = player.transform.localPosition.x;
        playerY = player.transform.localPosition.y;
        playerZ = player.transform.localPosition.z;

        playerX += horizontalMovement;

        position = new Vector3(playerX, playerY, playerZ);
        quaternion = new Quaternion(0, 0, 0, 0);
        player.transform.SetPositionAndRotation(position, quaternion);

        position.x = player.transform.localPosition.x;
        player.transform.SetPositionAndRotation(position, quaternion);
        right = false;
    }

    private void moveLeft()
    {
        playerX = player.transform.localPosition.x;
        playerY = player.transform.localPosition.y;
        playerZ = player.transform.localPosition.z;

        playerX -= horizontalMovement;

        position = new Vector3(playerX, playerY, playerZ);
        quaternion = new Quaternion(0, 0, 0, 0);
        player.transform.SetPositionAndRotation(position, quaternion);

        position.x = player.transform.localPosition.x;
        player.transform.SetPositionAndRotation(position, quaternion);
        left = false;
    }

    private void moveUp()
    {
        playerX = player.transform.localPosition.x;
        playerY = player.transform.localPosition.y;
        playerZ = player.transform.localPosition.z;

        playerY += verticalMovement;

        position = new Vector3(playerX, playerY, playerZ);
        quaternion = new Quaternion(0, 0, 0, 0);
        player.transform.SetPositionAndRotation(position, quaternion);

        position.y = player.transform.localPosition.y;
        player.transform.SetPositionAndRotation(position, quaternion);
        up = false;
    }

    private void moveDown()//if player moves down on spawn platform places them out of position for rest of the map
    {
        playerX = player.transform.localPosition.x;
        playerY = player.transform.localPosition.y;
        playerZ = player.transform.localPosition.z;

        playerY -= verticalMovement;

        position = new Vector3(playerX, playerY, playerZ);
        quaternion = new Quaternion(0, 0, 0, 0);
        player.transform.SetPositionAndRotation(position, quaternion);

        position.y = player.transform.localPosition.y;
        player.transform.SetPositionAndRotation(position, quaternion);
        down = false;
    }
}
