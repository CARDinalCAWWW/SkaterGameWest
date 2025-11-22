using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject carneyButton;
    [SerializeField] GameObject playButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginGame()
    {
        SceneManager.LoadScene("Game");
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
}
