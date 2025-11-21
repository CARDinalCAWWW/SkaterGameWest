using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    Vector3 startPos;
    float repeatWidth = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
