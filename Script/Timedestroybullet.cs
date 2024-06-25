using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timedestroybullet : MonoBehaviour
{
    public float time = 5f;
    public int DameAmount = 20;
    void Start()
    {

    }
    void Update()
    {
        Destroy(this.gameObject, time);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            AnimationEnemy animationEnemy = collision.gameObject.GetComponent<AnimationEnemy>();
            EnemyTargetPlayer enemyTargetPlayer = collision.gameObject.GetComponent<EnemyTargetPlayer>();
            if (animationEnemy != null)
            {
                animationEnemy.CalculateHp(DameAmount);
            }
            if (enemyTargetPlayer != null)
            {
                enemyTargetPlayer.CalculateHp(DameAmount);
            }
            Destroy(this.gameObject);

        }
    }
}
