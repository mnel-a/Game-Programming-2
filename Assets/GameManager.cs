using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour 
{ 
    public static GameManager Instance { get; private set; }

    public TMP_Text scoreText;

    private int score = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI();

    }

    public void DeductScore(int value)
    {
        score -= value;
        UpdateScoreUI();

    }

    public int GetScore()
    {
        return score;
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}