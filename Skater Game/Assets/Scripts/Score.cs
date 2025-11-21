using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] float addAmount = 1f;
    [SerializeField] TextMeshProUGUI scoreText;

    private float score;

    void Start()
    {
        if (scoreText == null)
        {
            scoreText = GetComponent<TextMeshProUGUI>();
        }

        score = 0;
    }

    void Update()
    {
        AddScore();
    }

    void AddScore()
    {
        score += addAmount * Time.deltaTime * 2;
        scoreText.text = ("Score: " + Mathf.FloorToInt(score).ToString());
    }
}