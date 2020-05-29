using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMaster : MonoBehaviour
{
    private CameraControler camControler;
    private TimeMaster timeMaster;
    private CheckpointMaster cpMaster;
    private ResetLevel resetLevel;
    private GameObject levelBlockade;

    public Transform newCheckpoint;
    public float newTime;

    void Start() {
        camControler = GameObject.FindGameObjectWithTag("CameraController").GetComponent<CameraControler>();
        timeMaster = GameObject.FindGameObjectWithTag("TimeMaster").GetComponent<TimeMaster>();
        cpMaster = GameObject.FindGameObjectWithTag("cpMaster").GetComponent<CheckpointMaster>();
        resetLevel = GameObject.FindGameObjectWithTag("LevelReset").GetComponent<ResetLevel>();
        levelBlockade = GameObject.FindGameObjectWithTag("LevelBlockade");
        levelBlockade.SetActive(false);
    }

    void Update() {
        if(camControler.isTutorialOver == true) {
            Debug.Log("Next part of the tuorial.");
            timeMaster.RestartTimer(newTime);
            timeMaster.isTimerActivated = true;
            cpMaster.NewCheckpoint(newCheckpoint);
            resetLevel.newFirstCheckpoint(newCheckpoint);
            levelBlockade.SetActive(true);
            camControler.isTutorialOver = false;
        }
    }
}
