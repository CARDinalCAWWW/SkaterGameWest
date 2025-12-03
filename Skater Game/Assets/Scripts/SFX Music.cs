using UnityEngine;

public class SFXMusic : MonoBehaviour
{
    [SerializeField] GameObject[] objs;

    void Awake()
    {

        if (FindObjectsOfType<SFXMusic>().Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
