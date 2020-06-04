using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMeter : MonoBehaviour
{
    private PlayerMovement playerManager;
    private Animator anim;

    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        anim = gameObject.GetComponent<Animator>();
        Debug.developerConsoleVisible = true;
    }

    void Update()
    {
        anim.SetBool("hasDashed", playerManager.hasDash);
        anim.SetFloat("RechargeTime", 1/playerManager.timeBeforeNextDash);
        anim.SetBool("IsDashMeterFull", playerManager.dashFull);

        if(Input.GetKeyDown(KeyCode.LeftShift)) {
            Debug.LogError("hasDashed: " + playerManager.hasDash);
            Debug.LogError("RechargeTime: " + 1/playerManager.timeBeforeNextDash);
            Debug.LogError("IsDashMeterFull: " + playerManager.dashFull);
        }
    }
}
