using UnityEngine;

public class BirdBehavior : MonoBehaviour
{
    private bool shouldMove = false;

    public float horizontalSpeed = -2f;
    public float verticalSpeed = -3f;

    private Score scoreScript;


    private void Start()
    {
        scoreScript = FindFirstObjectByType<Score>();

    }

    void Update()
    {
        if (shouldMove)
        {
            // Move the bird manually (downward arc)
            transform.position += new Vector3(horizontalSpeed, verticalSpeed, 0) * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Bounce");
            shouldMove = true;
            GetComponent<Collider2D>().enabled = false;
            scoreScript.BirdAddScore();
        }
    }
}
