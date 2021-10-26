using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCollider : MonoBehaviour
{
    public Victory victory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        victory.Setup();
        destroyObjects(collision);
    }

    private void destroyObjects(Collider2D collision)
    {
        Destroy(collision.GetComponent<SpriteRenderer>());//make death animation and game over screen allowing to restart
        Destroy(collision.GetComponent<Rigidbody2D>());
        Destroy(collision.GetComponent<Movement>());
    }
}
