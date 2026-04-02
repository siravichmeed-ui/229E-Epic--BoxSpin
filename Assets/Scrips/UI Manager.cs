using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject gameOverPanel;

    public void ShowWinUI()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f; // หยุดเกม
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;

        if (SceneManager.GetActiveScene().name == "Level5")
        {
            SceneManager.LoadScene("Credit");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void SelectLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level Select"); // ตั้งชื่อ scene เอง
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void ShowGameOverUI()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    // เล่นใหม่ (ด่านเดิม)
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        Debug.Log("Reset Save แล้ว!");
    }
}
