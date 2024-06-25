using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wepon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzlePoint;
    public GameObject bulletFire;
    public Transform pointFire;
    public float bulletSpeed = 20f;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;
    public AudioSource audiosoure;
    public AudioClip[] audioClips;
    public Toggle musicgun;
    public bool MusicMeme = false;
    private void Start()
    {
        musicgun.onValueChanged.AddListener(delegate
        {
            ToggleGunValueChanged(musicgun);
        });
    }
    public void ToggleGunValueChanged(Toggle change)
    {
        if (change.isOn == true && MusicMeme == true)
        {
            audiosoure.PlayOneShot(audioClips[Random.Range(1, audioClips.Length)]);
        }
        if (change.isOn == true && MusicMeme == false)
        {
            audiosoure.PlayOneShot(audioClips[0]);
        }
        if (change.isOn == false)
        {
            audiosoure.Stop();
        }

    }

    void Update()
    {
        RotateGun();
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, muzzlePoint.position, Quaternion.identity);

        Instantiate(bulletFire, pointFire.position, transform.rotation, transform);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
        ToggleGunValueChanged(musicgun);

    }
    public void RotateGun()
    {
        // Lấy vị trí của chuột trên màn hình
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Chuyển đổi vị trí chuột thành 2D và loại bỏ trục Z
        mousepos.z = 0;

        // Tính toán vector từ GunPivot đến vị trí của chuột
        Vector2 lookdir = mousepos - transform.position;

        // Tính toán góc quay dựa trên vector direction
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg;


        // Giới hạn góc quay
        //angle = Mathf.Clamp(angle, minAngle, maxAngle);

        // Quay GunPivot theo góc tính được
        transform.rotation = Quaternion.Euler(0, 0, angle);
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            transform.localScale = new Vector3(1, -1, 0);

        }
        else
        {
            transform.localScale = new Vector3(1, 1, 0);

        }
    }
}
