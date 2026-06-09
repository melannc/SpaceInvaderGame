using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 1f;      // bullets per second
    public float bulletSpeed = 10f;
    public Transform firePoint;      // where bullet spawns

    private float nextFireTime = 0f;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + (1f / fireRate);
        }
    }

    void Shoot()
    {
        AudioManager.Instance.PlayShoot(); // add this
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = -firePoint.up * bulletSpeed; // use firePoint.right for horizontal
        Destroy(bullet, 3f); // auto-destroy after 3 seconds
    }
}