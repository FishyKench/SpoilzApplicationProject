using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathPanel;
    public TextMeshProUGUI survivalTimeText;

    private void Start()
    {
        deathPanel.SetActive(false);
    }

    public void ShowDeathScreen(string time)
    {
        deathPanel.SetActive(true);
        survivalTimeText.text = "You survived for " + time;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}