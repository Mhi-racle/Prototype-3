using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    GameManager gameManager;
    PlayerController playerController;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (!playerController.gameOver)
        {
            if (other.CompareTag("Player"))
            {
                gameManager.score += 0.05f;
            }
        }

    }
}
