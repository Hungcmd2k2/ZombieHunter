using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float movespeed = 5f;
    private Rigidbody2D rb;
    public Vector3 moveinput;
    public Animator animator;
    public SpriteRenderer character;
    public Slider slider;
    public int HP = 100;
    public int Kill_Enemy = 0;
    public GameObject UI_DIE;
    public GameObject Crosshair;
    public GameObject Gun;
    void Start()
    {
        slider.value = HP;
    }
    private void FixedUpdate()
    {

    }
    void Update()
    {
        Move();
    }
    public void AddHP(int hp)
    {
        HP = HP + hp;
        slider.value = HP;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item_HP"))
        {
            AddHP(10);
            Destroy(collision.gameObject);
        }
    }
    public void CalculateKill(int kill)
    {
        Kill_Enemy += kill;
    }
    public void CalculateHp(int dame)
    {
        HP = HP - dame;
        slider.value = HP;
        animator.SetTrigger("Hit");
        if (HP <= 0)
        {

            Die();
        }
    }
    void Die()
    {
        animator.SetTrigger("Die");
        Invoke("ShowUI", 5f);
        Cursor.visible = true;
    }
    public void ShowUI()
    {
        Time.timeScale = 0;
        UI_DIE.SetActive(true);
        Crosshair.SetActive(false);
        Gun.SetActive(false);
    }
    public void Move()
    {
        moveinput.x = Input.GetAxis("Horizontal");
        moveinput.y = Input.GetAxis("Vertical");
        transform.position += moveinput * movespeed * Time.deltaTime;
        animator.SetFloat("Walk", moveinput.sqrMagnitude);
        if (moveinput.x != 0)
        {
            if (moveinput.x > 0)
            {
                character.transform.localScale = new Vector3(1, 1, 0);

            }
            else
            {
                character.transform.localScale = new Vector3(-1, 1, 0);

            }
        }
    }
}
