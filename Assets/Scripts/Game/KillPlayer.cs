using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private CheckpointMaster cpMaster;

    [HideInInspector]
    public bool isPlayerDead;

    private bool isColliding;

    void Start() {
        cpMaster = GameObject.FindGameObjectWithTag("cpMaster").GetComponent<CheckpointMaster>();
    }


    private void OnTriggerEnter2D(Collider2D coll) {
        if(isColliding) return;
        isColliding = true;
        

        if(coll.CompareTag("Player")) {
            isPlayerDead = true;
            gameObject.GetComponent<AudioSource>().Play();
        } else {
            isPlayerDead = false;
        }
    }

    private void OnTriggerExit2D(Collider2D coll) {
        if(coll.CompareTag("Player")) {
            isPlayerDead = false;
        }
    }

    
    void Update() {
        //Debug.Log("isPlayerDead: " + isPlayerDead);
        // Added to prevent if statemets that rely on isPlayerDead bool from running multipla times
        isColliding = false;
        if(!isColliding) isPlayerDead = false;
    }
}
