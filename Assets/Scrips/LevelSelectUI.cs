using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectUI : MonoBehaviour
{
    public Button[] levelButtons;
    public GameObject[] lockIcons;

    void Start()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            // i = 0 → Level1
            if (i + 1 <= unlockedLevel)
            {
                levelButtons[i].interactable = true;
                lockIcons[i].SetActive(false);
            }
            else
            {
                levelButtons[i].interactable = false;
                lockIcons[i].SetActive(true);
            }
        }
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene("Level" + levelIndex);
    }
}