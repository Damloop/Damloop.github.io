using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject gameOverUI;
    public GameObject winUI;

    // Loads a specific scene by index
    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    // Restarts the current level
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Shows the Game Over screen
    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }

    // Shows the Win screen
    public void Win()
    {
        Time.timeScale = 0f;
        winUI.SetActive(true);
    }
}
