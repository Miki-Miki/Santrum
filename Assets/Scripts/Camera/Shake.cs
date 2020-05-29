using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public Animator animator;

    public void camShake() {
        animator.SetTrigger("shake");
    }
}
