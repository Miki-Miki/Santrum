using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWon : MonoBehaviour
{
    private GameObject winningScreen;
    private bool hasWon = false;

    public float timeOffset = 4;

    void Start()
    {
        winningScreen = GameObject.FindGameObjectWithTag("YOUWON");
        winningScreen.SetActive(false);
    }

    void Update() {
        if(hasWon == true) {
            StartCoroutine(EndGame());
        }
    }

    private void OnTriggerEnter2D(Collider2D coll) {
        if(coll.CompareTag("Player")) {
            winningScreen.SetActive(true);
            hasWon = true;
        }
    }

    IEnumerator EndGame() {
        yield return new WaitForSeconds(timeOffset);
        SceneManager.LoadScene(0);
    }

}
