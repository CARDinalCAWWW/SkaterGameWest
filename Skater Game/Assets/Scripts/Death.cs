using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Death : MonoBehaviour
{
    [SerializeField] GameObject retryButton;
    public bool isDead;
    void Start()
    {
        Time.timeScale = 1;

        retryButton.SetActive(false);

        isDead = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.CompareTag("Death"))
        {
            Debug.Log("DIE!");
            Time.timeScale = 0;

            retryButton.SetActive(true);

            isDead = true;
        }
    }
}
