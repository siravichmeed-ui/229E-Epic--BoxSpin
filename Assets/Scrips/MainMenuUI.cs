using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level Select"); // ชื่อด่านแรก
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit Game"); // ใช้ดูใน Editor
    }
    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        Debug.Log("Reset Save แล้ว!");
    }
}