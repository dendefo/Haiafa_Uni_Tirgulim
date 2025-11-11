using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverUI;
    [SerializeField] TMPro.TMP_Text ScoreText;
    [SerializeField] int score = 0;
    private void OnEnable()
    {
        PlayerController.OnPlayerDeath += HandlePlayerDeath;
        PlayerController.OnPointScored += ScorePoint;
    }


    private void OnDisable()
    {
        PlayerController.OnPlayerDeath -= HandlePlayerDeath;
        PlayerController.OnPointScored -= ScorePoint;
    }


    private void HandlePlayerDeath()
    {
        Debug.Log("Player has dieded. Show Game Over UI.");
        gameOverUI.SetActive(true);
    }
    private void ScorePoint()
    {
        score++;
        ScoreText.text = score.ToString();
        Debug.Log("Score: " + score);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
