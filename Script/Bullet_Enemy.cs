using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Enemy : MonoBehaviour
{
    public float time_Destroy = 3f;
    public int DameAmount = 5;

    void Start()
    {

    }

    void Update()
    {
        Destroy(this.gameObject, time_Destroy);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.CalculateHp(DameAmount);
            }
            Destroy(this.gameObject);
        }
    }
}
