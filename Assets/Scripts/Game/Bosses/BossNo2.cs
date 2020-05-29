using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNo2 : MonoBehaviour
{
    [Header("Weapon")]
    public GameObject projectile;
    public Transform[] firePoints;
    public Transform fireRing;
    public float frRotationSpeed;
    private float trueFRRotatiosSpeed;
    public float fireFrequency = 2;
    private float trueFF;
    private float nextFire = 0;

    [Header("Weapon Randomness")]
    public float rateOfFireFrom;
    public float rateOfFireTo;
    private float randomROF;
    public float rotationSpeedFrom;
    public float rotationSpeedTo;
    private float randomRotationSpeed;
    public float randomnessFrequency;
    private float trueRanFrequency;
    public float randomnessDuration;
    private bool isBeingRandomized;

    void Start() {
        trueRanFrequency = randomnessFrequency;
        trueFRRotatiosSpeed = frRotationSpeed;
        trueFF = fireFrequency;
    }

    void Update()
    {        
        if(Time.time > nextFire) {
            nextFire = Time.time + fireFrequency;
            Shoot();
        }

        fireRing.transform.Rotate(Vector3.forward * frRotationSpeed * Time.deltaTime);

        randomnessFrequency -= Time.deltaTime;
        if(randomnessFrequency <= 0.1f) {
            if(isBeingRandomized == false) {
                randomROF = Random.Range(rateOfFireFrom, rateOfFireTo);
                randomRotationSpeed = Random.Range(rotationSpeedFrom, rotationSpeedTo);
                isBeingRandomized = true;
            }
            StartCoroutine(RandomizeShooting());
        }
    }

    private void Shoot() {
        Debug.Log("Shooting");
        foreach(var pof in firePoints) {
            Instantiate(projectile, pof.position, pof.rotation);
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    IEnumerator RandomizeShooting() {
        fireFrequency = randomROF;
        frRotationSpeed = randomRotationSpeed;
        yield return new WaitForSeconds(randomnessDuration);
        randomnessFrequency = trueRanFrequency;
        fireFrequency = trueFF;
        frRotationSpeed = trueFRRotatiosSpeed;
        isBeingRandomized = false;
    }
}
