
using UnityEngine;

public class EnemyTargetPlayer : MonoBehaviour
{
    private Transform player;
    public float moveSpeed = 2f;
    public float stoppingDistance = 2f;
    public float maxSpeed = 5f;
    private Animator animator;
    public int HP = 100;
    private Rigidbody2D rb;
    public GameObject bulletPrefab;
    public Transform muzzlePoint;
    public float bulletSpeed = 10f;
    public GameObject bulletFire;
    public Transform pointFire;
    public float fireRate = 2f;
    private float nextFireTime = 0f;
    private Player playersendkill;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    public void CalculateHp(int dame)
    {
        HP -= dame;
        animator.SetTrigger("Hit");
        if (HP == 0)
        {
            playersendkill.CalculateKill(1);
            Die();
        }
    }
    public void Die()
    {
        animator.SetTrigger("Die");
        Destroy(this.gameObject, 1.5f);
    }

    void FixedUpdate()
    {
        Move();
        Flip();
        Shot();
    }

    private void Move()
    {
        if (player != null)
        {
            // Tính toán vị trí mới của enemy
            Vector2 newPosition = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            // Cập nhật vị trí của enemy
            transform.position = newPosition;

        }
    }
    private void Flip()
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
    void Shot()
    {
        if (Time.time >= nextFireTime)
        {

            GameObject bullet = Instantiate(bulletPrefab, muzzlePoint.position, Quaternion.identity);
            Vector2 direction = (player.position - muzzlePoint.position).normalized;
            // Xoay viên đạn để hướng về player (nếu cần thiết)
            bullet.transform.right = direction;
            Instantiate(bulletFire, pointFire.position, transform.rotation, transform);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
            nextFireTime = Time.time + fireRate;
        }

    }

}
