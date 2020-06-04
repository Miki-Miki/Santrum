using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private string facingDirection;
    private Rigidbody2D rb2d;

    [Header("Dash")]
    public float dashSpeed = 50.0f;
    public float dashDuration = 0.2f;
    public float timeBeforeNextDash;
    private float dashTimeBeforeNext;
    private float dashStartTime;

    [HideInInspector]
    public bool hasDash;

    [HideInInspector]
    public bool dashFull;

    [HideInInspector]
    public bool isDashing;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //    Dash
        // -----------
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            GetFacingDirection();
        }

        if(dashStartTime <= 0) 
        {   
            facingDirection = "";
            rb2d.velocity = Vector2.zero;
            dashStartTime = dashDuration;
        }
        else if (Input.GetButtonDown("Dash") && dashTimeBeforeNext == 0) {
            hasDash = true;
            isDashing = true;
            dashTimeBeforeNext = timeBeforeNextDash;
            StartCoroutine(StopDash(dashStartTime));
            PlayerDash(dashSpeed, facingDirection);
            StartCoroutine(DisableDashFor(dashTimeBeforeNext));
            
        }

        // Dash meter 
        if(dashTimeBeforeNext == 0) {
            dashFull = true;
        } else {
            dashFull = false;
        }
    }

    // Time before velocity reset
    IEnumerator StopDash(float time) {
        yield return new WaitForSeconds(time);
        dashStartTime = 0;
        isDashing = false;
    }

    // Time before next dash
    IEnumerator DisableDashFor(float time) {
        yield return new WaitForSeconds(time);
        dashTimeBeforeNext = 0;
        hasDash = false;
    }

    private string GetFacingDirection()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            facingDirection = "LEFT";
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            facingDirection = "RIGHT";
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            facingDirection = "DOWN";
        }

        return facingDirection;
    }

    private void PlayerDash(float playerDashSpeed, string playerDirection)
    {
        if (playerDirection == "RIGHT")
        {
            rb2d.velocity = Vector2.right * playerDashSpeed;
        }
        else if (playerDirection == "LEFT")
        {
            rb2d.velocity = Vector2.left * playerDashSpeed;
        }
        else if (playerDirection == "DOWN")
        {
            rb2d.velocity = Vector2.down * playerDashSpeed;
        }
    }
}
