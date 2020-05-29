using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public int sceneIndex;

    private void OnTriggerEnter2D(Collider2D coll) {
        if(coll.CompareTag("Player")) {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
