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
    }

    void Update()
    {
        anim.SetBool("hasDashed", dashManager.hasDash);
        anim.SetFloat("RechargeTime", 1/dashManager.timeBeforeNextDash);
        anim.SetBool("IsDashMeterFull", dashManager.dashFull);
    }
}
