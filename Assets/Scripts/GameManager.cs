using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private float gameSpeed = 5f;
    [SerializeField] private float speedIncrease = 0.15f;
    [SerializeField] private TextMeshProUGUI scoreText;
    private float score = 0;
    [SerializeField] private GameObject gameStartMess;
    [SerializeField] private GameObject gameOverMess;
    [SerializeField] private GameObject scoreTextObject;
    private bool gameOver = false;

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
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        HandleStartGame();
        if (!gameOver)
        {
            UpdateGameSpeed();
            UpdateScore();
        }

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

    private void StartGame()
    {
        Time.timeScale = 0;
        scoreTextObject.SetActive(false);
        gameStartMess.SetActive(true);
        gameOverMess.SetActive(false);
    }

    private void HandleStartGame()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1;
            scoreTextObject.SetActive(true);
            gameStartMess.SetActive(false);
            gameOverMess.SetActive(false);
        }
    }

    public void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0;
        gameOverMess.SetActive(true);
        StartCoroutine(ReloadScene());
    }

    private System.Collections.IEnumerator ReloadScene()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
