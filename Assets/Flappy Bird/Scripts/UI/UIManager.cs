using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public const string MAX_PLAYER_SCORE = nameof(MAX_PLAYER_SCORE);
    [SerializeField] GameObject gameOverUI;
    [SerializeField] TMPro.TMP_Text ScoreText;
    [SerializeField] int score = 0;
    [SerializeField] string MainMenuName;
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

        if (PlayerPrefs.GetInt(MAX_PLAYER_SCORE) < score)
        {
            PlayerPrefs.SetInt(MAX_PLAYER_SCORE, score);
            Debug.Log("New High Score: " + score);
        }

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
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenuName);
    }

}
