using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private float gameSpeed = 5f;
    [SerializeField] private float speedIncrease = 0.15f;
    [SerializeField] private TextMeshProUGUI scoreText;
    private float score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    public float GetGameSpeed()
    {
        return gameSpeed;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateGameSpeed();
        UpdateScore();
    }

    private void UpdateGameSpeed()
    {
        gameSpeed += speedIncrease * Time.deltaTime;
    }

    private void UpdateScore()
    {
        score += Time.deltaTime * 10;// Increment score based on time
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString(); // Update the score text
    }
}
