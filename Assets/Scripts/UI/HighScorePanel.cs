using UnityEngine;
using TMPro;

public class HighscorePanel : Panel
{
    [SerializeField] private TextMeshProUGUI[] _scoreTexts;

    public override void Show()
    {
        base.Show();
        int[] topScores = ScoreManager.Instance.GetTopScores();

        for (int i = 0; i < _scoreTexts.Length && i < topScores.Length; i++)
        {
            _scoreTexts[i].text = topScores[i].ToString();
        }
    }
}