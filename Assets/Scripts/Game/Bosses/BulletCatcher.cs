using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCatcher : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll) {
        if(coll.CompareTag("Projectile")) {
            Object.Destroy(coll.gameObject);
        }
    }
}
