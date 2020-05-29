using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNo1 : MonoBehaviour
{
    [Header("Weapon")]
    public GameObject projectile;
    public Transform firePoint;
    public float fireFrequency = 2;
    private float nextFire = 0;

    void LateUpdate() {
        if(Time.time > nextFire) {
            nextFire = Time.time + fireFrequency;
            Shoot();
        }
    }

    private void Shoot() {
        Instantiate(projectile, firePoint.position, firePoint.rotation);
        gameObject.GetComponent<AudioSource>().Play();
    }
}
