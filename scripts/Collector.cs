using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    private string enemyTag = "Enemy";
    private string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(enemyTag) || collision.CompareTag(playerTag))
        {
            Destroy(collision.gameObject);
        }
    }


}
