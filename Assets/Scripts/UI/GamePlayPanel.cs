using TMPro;
using UnityEngine;

public class GamePlayPanel : Panel
{
    [SerializeField] private TextMeshProUGUI _playScoreText;

    private void OnEnable()
    {
        ScoreManager.OnScoreChanged += UpdateScoreText;
    }

    private void OnDisable()
    {
        ScoreManager.OnScoreChanged -= UpdateScoreText;
    }

    private void UpdateScoreText(int score)
    {
        _playScoreText.text = score.ToString();
    }
    
    public void OnPauseButtonClick()
    {
        GameManager.Instance.PauseGame();
    }
}
