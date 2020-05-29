using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [Header("Chekpoint")]
    public Sprite spriteWhenChecked;
    public Sprite spriteWhenUnchecked;

    private CheckpointMaster cpMaster;
    private TimeMaster timeMaster;
    private bool isLastCheckpoint;
    
    void Start() {
        cpMaster = GameObject.FindGameObjectWithTag("cpMaster").GetComponent<CheckpointMaster>();
        timeMaster = GameObject.FindGameObjectWithTag("TimeMaster").GetComponent<TimeMaster>();
    }

    void Update() {
        if(cpMaster.lastCheckpointPos != new Vector2(transform.position.x, transform.position.y)) {
            isLastCheckpoint = false;
        }

        if(isLastCheckpoint) {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteWhenChecked;
        } else {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteWhenUnchecked;
        }
    }

    private void OnTriggerEnter2D(Collider2D coll) {
        if(coll.CompareTag("Player")) {
            if(cpMaster.lastCheckpointPos != new Vector2(transform.position.x, transform.position.y)) {
                timeMaster.AddTime(2);
            }
            cpMaster.lastCheckpointPos = transform.position;
            isLastCheckpoint = true;
        }
    }
}
