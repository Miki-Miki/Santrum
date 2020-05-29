using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VolumeMaster : MonoBehaviour
{
    public float musicVolume;
    private AudioSource musicSource;
    private Slider volumeSlider;

    [HideInInspector]
    public float sliderInitialValue;

    private float initialVolume;

    [HideInInspector]
    public bool finishedFadingOut = false;

    public AudioClip mainSoundTrack;

    private bool sceneChanged;

    void Awake() {
        volumeSlider = GameObject.FindGameObjectWithTag("musicSlider").GetComponent<Slider>();
        volumeSlider.value = musicVolume;    
            
    }

    void OnEnable() {
        musicSource = gameObject.GetComponent<AudioSource>();
        sceneChanged = true;
    }

    void Update() {
        //volumeSlider = GameObject.FindGameObjectWithTag("musicSlider").GetComponent<Slider>();

        if(volumeSlider != null && finishedFadingOut == false) {
            musicVolume = volumeSlider.value;
        } else {
            sliderInitialValue = musicVolume;
        }
        
        musicSource.volume = musicVolume;

        if(SceneManager.GetActiveScene().buildIndex == 1 && sceneChanged) {
            musicSource.clip = mainSoundTrack;
            musicSource.Play();
            StartCoroutine(FadeIn(0.01f));
            //musicSource.volume = sliderInitialValue;
             
            sceneChanged = false;
        }

        if(Input.GetKey(KeyCode.RightAlt)) {
            Debug.Log("Initial Slider Value: " + sliderInitialValue);
            Debug.Log("Initial Volume: " + initialVolume);
        }
    }

    public void OnVolumeChange(float volume) {
        musicVolume = volume;
    }

    public IEnumerator FadeOut(float speed) {
        initialVolume = musicVolume;
        while(musicVolume >= 0.01f && finishedFadingOut == false) {
            musicVolume -= speed;
            musicSource.volume = musicVolume;
            yield return new WaitForSeconds(0.1f);
        }

        if(musicVolume <= 0.1f) {
            finishedFadingOut = true;  
            sliderInitialValue = initialVolume;          
        }
    }

    public IEnumerator FadeIn(float speed) {        
        float initialSliderValue = musicVolume;
        musicVolume = 0;
        while(musicVolume < initialSliderValue) {
            musicVolume += speed;
            musicSource.volume = musicVolume;
            Debug.Log("music volume: " + musicVolume);
            yield return new WaitForSeconds(0.1f);
        }
    }

    
}
