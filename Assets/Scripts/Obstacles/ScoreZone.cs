using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    private bool _hasScored;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_hasScored) return;

        if (other.CompareTag("Bird"))
        {
            _hasScored = true;
            ScoreManager.Instance.AddPoint();
        }
    }

    public void ResetScoreState()
    {
        _hasScored = false;
    }
}