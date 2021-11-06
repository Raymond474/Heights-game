using UnityEngine;

public class Gimble : MonoBehaviour
{
    [SerializeField] Transform target;

    void Update()
    {
        transform.position = new Vector3(0, target.position.y, -10);
    }
}
