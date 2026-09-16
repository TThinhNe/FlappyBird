using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverPanel : Panel
{
    [Header("Score Texts")]
    [SerializeField] private TextMeshProUGUI _resultScoreText;
    [SerializeField] private TextMeshProUGUI _bestScoreText;

    [Header("Medal")]
    [SerializeField] private Image _medalImage;
    [SerializeField] private Sprite _bronzeMedal;
    [SerializeField] private Sprite _silverMedal;
    [SerializeField] private Sprite _goldMedal;
    
    public override void Show()
    {
        base.Show();
        _resultScoreText.text = ScoreManager.Instance.GetScore().ToString();
        _bestScoreText.text = ScoreManager.Instance.GetBestScore().ToString();
        SetMedal(ScoreManager.Instance.GetScore());
    }
    
    public void OnPlayButtonClicked()
    {
        GameManager.Instance.RestartGame();
    }

    public void OnMenuButtonClicked()
    {
        GameManager.Instance.GoToMenu();
    }
    
    public void OnHighscoreButtonClicked()
    {
        UIManager.Instance.OpenPanel("HighscorePanel");
    }

    private void SetMedal(int score)
    {
        Sprite chosen = null;

        if (score >= 30) chosen = _goldMedal;
        else if (score >= 20) chosen = _silverMedal;
        else if (score >= 10) chosen = _bronzeMedal;

        _medalImage.sprite = chosen;
        _medalImage.gameObject.SetActive(chosen != null);
    }
}