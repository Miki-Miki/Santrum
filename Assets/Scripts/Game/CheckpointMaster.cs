using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointMaster : MonoBehaviour
{
    // This script stores the position of the last passed checkpoint
    public Transform lastCPTransform;
    [HideInInspector]
    public  Vector2 lastCheckpointPos;

    void Start() {
        if(lastCPTransform != null) {
            lastCheckpointPos = lastCPTransform.position;
        }
    }

    public void NewCheckpoint(Transform newCp) {
        lastCheckpointPos = newCp.position;
    }

    
}
