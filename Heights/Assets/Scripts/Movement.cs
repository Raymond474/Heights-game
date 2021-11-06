using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject player;
    public static float horizontalMovement;
    public static float verticalMovement;
    private bool left;
    private bool right;
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
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.X))
        {
            right = true;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Z))
        {
            left = true;
        }
    }

    private void FixedUpdate()
    {
        if (player.GetComponent<Rigidbody2D>().velocity.magnitude > Model.maxFallSpeed)//ensures the player falls at a constant speed
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(Model.horiGravMag, Model.vertGravMag);
        }

        if (right)
        {
            MoveRight();
        }
        if (left)
        {
            MoveLeft();
        }
    }

    private void MoveRight()
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

    private void MoveLeft()
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
}
