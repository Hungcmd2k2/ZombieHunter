using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.IO;

public class AnimationEnemy : MonoBehaviour
{
    public int HP = 100;
    private AIPath aIPath;
    private Animator animator;
    public Transform player;
    public float DistanceAttack = 2f;
    public float bulletSpeed = 10f;
    public float fireRate = 2f;
    private float nextFireTime = 0f;
    public GameObject bulletPrefab;
    public Transform muzzlePoint;
    public GameObject bulletFire;
    public Transform pointFire;
    private Player playersendkill;

    void Start()
    {
        aIPath = GetComponent<AIPath>();
        animator = GetComponent<Animator>();
        GameObject playerObject = GameObject.Find("PointDame");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player object not found. Please check the playerName.");
        }
        GameObject playerkill = GameObject.Find("Player");
        playersendkill = playerkill.GetComponent<Player>();
    }

    void Update()
    {
        float DistanceToPlayer = Vector3.Distance(transform.position, player.position);
        float speed = aIPath.desiredVelocity.magnitude;
        if (DistanceToPlayer < DistanceAttack)
        {
            animator.SetBool("Walk", false);

            if (Time.time >= nextFireTime)
            {
                Shot();
                nextFireTime = Time.time + fireRate;
            }

        }
        else
        {

        }
        flip();
    }
    void Shot()
    {
        GameObject bullet = Instantiate(bulletPrefab, muzzlePoint.position, Quaternion.identity);
        Vector2 direction = (player.position - muzzlePoint.position).normalized;
        // Xoay viên đạn để hướng về player (nếu cần thiết)
        bullet.transform.right = direction;
        Instantiate(bulletFire, pointFire.position, transform.rotation, transform);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
    }
    public void CalculateHp(int dame)
    {
        HP = HP - dame;
        animator.SetTrigger("Hit");
        if (HP < 0)
        {

        }
        if (HP == 0)
        {
            SendKill();
            Die();
        }
    }
    void Die()
    {
        animator.SetTrigger("Die");
        Destroy(this.gameObject, 1.5f);
    }
    public void SendKill()
    {
        playersendkill.CalculateKill(1);
    }
    void flip()
    {
        if (transform.position.x < player.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
