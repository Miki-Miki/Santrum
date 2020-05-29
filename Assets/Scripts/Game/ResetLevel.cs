using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevel : MonoBehaviour
{
    // Resets player to this position
    public Transform firstCheckpoint;
    public Transform player;

    private TimeMaster timeMaster;

    [HideInInspector]
    public bool isLevelReset;

    void Start() {
        timeMaster = GameObject.FindGameObjectWithTag("TimeMaster").GetComponent<TimeMaster>();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.R)) {
            if(firstCheckpoint != null) {
                player.position = firstCheckpoint.position;
                timeMaster.RestartTimer();
                isLevelReset = true;
                Debug.Log("IsLevelReset: " + isLevelReset);
            }
        }
    }

    public void newFirstCheckpoint(Transform newFirstCp) {
        firstCheckpoint = newFirstCp;
    }
}
