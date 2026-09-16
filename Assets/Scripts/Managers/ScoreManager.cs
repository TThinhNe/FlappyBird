using System;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    
    public static event Action<int> OnScoreChanged;

    private int _score;
    private const string HighScoreKeyPrefix = "HighScore_";
    private const int TopCount = 3;

    private int[] _topScoresCache = new int[TopCount];

    public void AddPoint()
    {
        _score++;
        OnScoreChanged?.Invoke(_score);
    }

    public void ResetScore()
    {
        _score = 0;
        OnScoreChanged?.Invoke(_score);
    }

    public int GetScore()
    {
        return _score;
    }

    public int GetBestScore()
    {
        return GetTopScores()[0];
    }

    public int[] GetTopScores()
    {
        for (int i = 0; i < TopCount; i++)
        {
            _topScoresCache[i] = PlayerPrefs.GetInt(HighScoreKeyPrefix + i, 0);
        }

        return _topScoresCache;
    }

    public void SaveScoreResult()
    {
        int[] scores = GetTopScores();

        for (int i = 0; i < TopCount; i++)
        {
            if (_score > scores[i])
            {
                for (int j = TopCount - 1; j > i; j--)
                {
                    scores[j] = scores[j - 1];
                }

                scores[i] = _score;
                break;
            }
        }

        for (int i = 0; i < TopCount; i++)
        {
            PlayerPrefs.SetInt(HighScoreKeyPrefix + i, scores[i]);
        }
    }
}