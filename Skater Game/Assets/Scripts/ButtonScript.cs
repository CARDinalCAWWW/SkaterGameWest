using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] GameObject carneyButton;
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject unpauseButton;
    [SerializeField] GameObject menuButton;

    private Death deathScript;

    private void Start()
    {
        deathScript = FindFirstObjectByType<Death>();

        carneyButton.SetActive(false);
        restartButton.SetActive(false);
        unpauseButton.SetActive(false);
        menuButton.SetActive(false);

        pauseButton.SetActive(true);
    }

    private void Update()
    {
        if (deathScript.isDead)
        {
            pauseButton.SetActive(false);
        }
    }

    public void QuitGame()
    {
        if (Application.isEditor)
        {
            // Inside Unity Editor
            Debug.Log("Would quit the game if it were a build.");
        }
        else
        {
            // In a build
            Application.Quit();
        }
    }

    public void ReloadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentSceneName);
    }

    public void PauseGame()
    {
        carneyButton.SetActive(true);
        restartButton.SetActive(true);
        unpauseButton.SetActive(true);
        menuButton.SetActive(true);

        pauseButton.SetActive(false);

        Time.timeScale = 0;
    }

    public void UnpuaseGame()
    {
        carneyButton.SetActive(false);
        restartButton.SetActive(false);
        unpauseButton.SetActive(false);
        menuButton.SetActive(false);

        pauseButton.SetActive(true);

        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}