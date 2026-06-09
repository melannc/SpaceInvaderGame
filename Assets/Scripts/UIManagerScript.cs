using UnityEngine;
using TMPro;
using System.Collections;

public class UIManagerScript : MonoBehaviour
{
    [Header("Panels")]
    public GameObject MenuUI;
    public GameObject GameUI;
    public GameObject GameOverUI;
    public GameObject WinUI;
    public GameObject ingameobjects;

    [Header("UI Text")]
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;

    [Header("References")]
    public PlayerHealth playerHealth;
    public GameObject player;
    public EnemySpawner enemySpawner;

    private int lives = 3;
    private int score = 0;
    private Vector3 playerStartPosition;

    void Start()
    {
        // Save player starting position
        playerStartPosition = player.transform.position;

        // Show only menu at start
        MenuUI.SetActive(true);
        GameUI.SetActive(false);
        GameOverUI.SetActive(false);
        WinUI.SetActive(false);
        ingameobjects.SetActive(false);
    }

    // =====================
    // GAME STATE MANAGEMENT
    // =====================

    public void StartGame()
    {
        // Reset stats
        lives = 3;
        score = 0;

        // Reset UI text
        UpdateLivesUI();
        UpdateScoreUI();

        // Switch panels
        MenuUI.SetActive(false);
        GameOverUI.SetActive(false);
        WinUI.SetActive(false);
        GameUI.SetActive(true);
        ingameobjects.SetActive(true);

        // Reset player
        playerHealth.resetHealth();
        player.SetActive(true);
        player.transform.position = playerStartPosition;

        // Respawn enemies
        RespawnEnemies();

        // Restart BGM
        AudioManager.Instance.PlayBGM();
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        AudioManager.Instance.PlayGameOver();

        GameUI.SetActive(false);
        ingameobjects.SetActive(false);
        GameOverUI.SetActive(true);
    }

    void Win()
    {
        Debug.Log("You Win!");
        AudioManager.Instance.StopBGM();

        GameUI.SetActive(false);
        ingameobjects.SetActive(false);
        WinUI.SetActive(true);
    }

    // =====================
    // LIVES & SCORE
    // =====================

    public void DecreaseLives()
    {
        lives--;
        Debug.Log("Lives remaining: " + lives);
        UpdateLivesUI();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    void UpdateLivesUI()
    {
        if (livesText != null)
            livesText.text = "LIVES: " + lives;
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "SCORE: " + score;
    }

    // =====================
    // WIN CONDITION
    // =====================

    public IEnumerator WaitAndCheckWin()
    {
        yield return null; // wait one frame for Destroy to complete

        EnemyHealth[] remainingEnemies = FindObjectsByType<EnemyHealth>(FindObjectsSortMode.None);
        Debug.Log("Enemies remaining: " + remainingEnemies.Length);

        if (remainingEnemies.Length == 0)
        {
            Win();
        }
    }

    // =====================
    // ENEMY SPAWNING
    // =====================

    void RespawnEnemies()
    {
        if (enemySpawner != null)
        {
            enemySpawner.SpawnEnemies();
        }
        else
        {
            Debug.LogWarning("No EnemySpawner assigned in UIManagerScript!");
        }
    }
}