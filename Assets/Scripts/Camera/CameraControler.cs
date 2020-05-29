using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public Transform futureCameraPosition;
    public Transform mainCameraParentTransform;

    [HideInInspector]
    public bool isLevelFinished;

    [HideInInspector]
    public bool isTutorialOver;

    public float transitionSpeed;
    private bool hasCollided;

    void Start() {
        mainCameraParentTransform = GameObject.FindGameObjectWithTag("MainCameraParent").transform;
        hasCollided = false;
    }

    void LateUpdate() {
        if(isLevelFinished == true) {
            TranslateCamera();
        }
    }

    private void OnTriggerEnter2D(Collider2D coll) {
        if(coll.CompareTag("Player") && hasCollided == false) {
            isLevelFinished = true; 
            isTutorialOver = true;
            hasCollided = true;
            Debug.Log("isTutorialOver: " + isTutorialOver);           
        } else {
            isLevelFinished = false;
        }
    }

    private void TranslateCamera() {
        mainCameraParentTransform.position = Vector3.Lerp(mainCameraParentTransform.position, futureCameraPosition.position, transitionSpeed * Time.deltaTime);
    }
}
