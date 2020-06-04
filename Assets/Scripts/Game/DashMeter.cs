using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMeter : MonoBehaviour
{
    private Dash dashManager;
    private Animator anim;

    void Start()
    {
        dashManager = GameObject.FindGameObjectWithTag("Player").GetComponent<Dash>();
        anim = gameObject.GetComponent<Animator>();
        Debug.developerConsoleVisible = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)) {
            Debug.LogError("hasDashed: " + dashManager.hasDash);
            Debug.LogError("RechargeTime: " + 1/dashManager.timeBeforeNextDash);
            Debug.LogError("IsDashMeterFull: " + dashManager.dashFull);
        }

        anim.SetBool("hasDashed", dashManager.hasDash);
        anim.SetFloat("RechargeTime", 1/dashManager.timeBeforeNextDash);
        anim.SetBool("IsDashMeterFull", dashManager.dashFull);
    }
}
