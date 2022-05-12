
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    [SerializeField] GameObject gameOverUI;
    WaveSpawner waveSpawner;
    CameraController cameraController;
    PlayerStats playerStats;
    bool gameEnded = false;
    public bool GameEnded { get { return gameEnded; } private set { } }
    void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
        waveSpawner = GetComponent<WaveSpawner>();
        cameraController = FindObjectOfType<CameraController>();
        Instance = this;
    }
    void Update()
    {
        if (gameEnded)
            return;
        if (playerStats.Lives <= 0)
            EndGame();
    }
    void EndGame()
    {
        gameEnded = true;
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
    }
}