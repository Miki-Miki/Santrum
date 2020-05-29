using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveVolume : MonoBehaviour
{
    private VolumeMaster volumeMaster;

    void Start() {
        volumeMaster = GameObject.FindGameObjectWithTag("VolumeMaster").GetComponent<VolumeMaster>();
    }

    void OnDestroy() {
        volumeMaster.sliderInitialValue = gameObject.GetComponent<Slider>().value;
    }
}
