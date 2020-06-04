using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class PlayerKiller : MonoBehaviour
{
    private PlayerMovement playerManager;
    private TimeMaster timeMaster;
    private Shake camShaker;
    private AudioSource deathSound;

    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        timeMaster = GameObject.FindGameObjectWithTag("TimeMaster").GetComponent<TimeMaster>();
        camShaker = GameObject.FindGameObjectWithTag("CameraShaker").GetComponent<Shake>();
        deathSound = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D coll) {
        if(coll.CompareTag("Player")) {
            playerManager.RespawnPlayer();
            camShaker.camShake();
            timeMaster.CutTimeInHalf();
            timeMaster.IncrementNumOfResets();
            deathSound.Play();
        }
    }
}
