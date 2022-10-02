using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public PlayerController playerController;
    public GameObject gameText;
    public Button startButton;
    public float score;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        playerController.gameOver = true;
        gameText.SetActive(false);
    }

    void Update()
    {
        scoreText.text = "Score : " + score;
    }
    public void StartGame()
    {
        playerController.gameOver = false;
        gameText.SetActive(true);
        startButton.gameObject.SetActive(false);
    }
    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
