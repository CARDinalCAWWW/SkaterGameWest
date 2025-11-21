using UnityEngine;
using System.Collections;

public class RailSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] rails;

    [SerializeField] float timeToWaitRails = 5;
    [SerializeField] int maxHeight = 1;
    [SerializeField] int minHeight = -1;
    [SerializeField] float timeToDestroy = 10;


    [SerializeField] Transform spawnPosition;

    void Start()
    {
        GameObject firstRail = Instantiate(rails[1], new Vector2(spawnPosition.position.x, -1), Quaternion.identity);
        Destroy(firstRail, timeToDestroy);

        StartCoroutine("SpawnRails");

    }

    IEnumerator SpawnRails()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToWaitRails);

            int railHeight = Random.Range(maxHeight, minHeight);
            GameObject newRail = Instantiate(rails[Random.Range(0, 2)], new Vector2(spawnPosition.position.x, railHeight), Quaternion.identity);
            Destroy(newRail, timeToDestroy);
        }
    }
}
