using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditUI : MonoBehaviour
{
    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // ?????????? pause ???
        SceneManager.LoadScene("MainMenu");
    }
}