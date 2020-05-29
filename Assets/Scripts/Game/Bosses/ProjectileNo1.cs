using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileNo1 : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody2D rb;
    private KillPlayer killPlayer;
    private PlayerMovement playerManager;
    private TimeMaster timeMaster;
    private Shake camShaker;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        killPlayer = gameObject.GetComponent<KillPlayer>();
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        timeMaster = GameObject.FindGameObjectWithTag("TimeMaster").GetComponent<TimeMaster>();
        camShaker = GameObject.FindGameObjectWithTag("CameraShaker").GetComponent<Shake>();
    }

    private void OnTriggerEnter2D(Collider2D coll) {
        if(coll.CompareTag("Player")) {
            killPlayer.isPlayerDead = true;
            playerManager.RespawnPlayer();
            camShaker.camShake();
            timeMaster.CutTimeInHalf();
            timeMaster.IncrementNumOfResets();
        }
    }

}
