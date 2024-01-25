using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioClip clip;
    public Rigidbody2D playerRb;

    public float bulletForce = 20f;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        var animator = gameObject.GetComponent<Animator>();
        var animatorInfo = animator.GetCurrentAnimatorClipInfo(0);
        
        var spawnedBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        var bulletRb = spawnedBullet.GetComponent<Rigidbody2D>();
        
        switch(animatorInfo[0].clip.name)
        {
            case "Player_walk_up":
            case "Player_idle":
                bulletRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                break;
            case "Player_walk_down":
                bulletRb.AddForce(-firePoint.up * bulletForce, ForceMode2D.Impulse);
                break;
            case "Player_walk_left":
                bulletRb.AddForce(-firePoint.right * bulletForce, ForceMode2D.Impulse);
                break;
            case "Player_walk_right":
                bulletRb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
                break;
        }
        
        AudioSource.PlayClipAtPoint(clip, this.gameObject.transform.position);
    }
}
