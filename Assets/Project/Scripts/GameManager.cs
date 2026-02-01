using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public int Score { get; private set; } = 0;
    
    public void AddScore(int value)
    {
        Score += value;

        ScoreElementUGUI scoreElementUI = GameObject.FindAnyObjectByType<ScoreElementUGUI>();
        scoreElementUI?.SetScoreText(Score.ToString());
    }
}
