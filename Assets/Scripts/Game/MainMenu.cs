using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    public GameObject optionCanvas;
    public float fadeTime;
    private bool isFadeStart;
    private VolumeMaster volumeMaster;

    void Start() {        
        optionCanvas.SetActive(false);
        volumeMaster = GameObject.FindGameObjectWithTag("VolumeMaster").GetComponent<VolumeMaster>();        
    }

    void Update() {
        if(isFadeStart == true) {
            SceneManager.LoadScene(1);
            isFadeStart = true;
        }
    }

    public void LoadFirstLevel() {
        isFadeStart = true;
    }

    public void Exit() {
        Application.Quit();
    }

    public void OpenOptions() {
        optionCanvas.SetActive(true);
    }
}
