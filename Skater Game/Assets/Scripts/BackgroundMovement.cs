using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
    }
}
