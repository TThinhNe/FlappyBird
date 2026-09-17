using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private static bool _autoStartOnLoad;

    public bool IsPlaying { get; private set; }
    public bool IsGameOver { get; private set; }
    public bool IsPaused { get; private set; }
    public bool IsTutorial { get; private set; }

    public bool IsRunning => IsPlaying && !IsPaused;
    public bool IsGroundRunning => (IsTutorial || IsPlaying) && !IsPaused;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (_autoStartOnLoad)
        {
            _autoStartOnLoad = false;
            BeginGameplay();
        }
        else
        {
            IsTutorial = false;
            UIManager.Instance.OpenPanel("MainMenuPanel");
        }
    }

    public void ShowTutorial()
    {
        IsTutorial = true;
        UIManager.Instance.CloseAllPanel();
        UIManager.Instance.OpenPanel("TutorialPanel");
    }

    public void BeginGameplay()
    {
        IsTutorial = false;
        IsPlaying = true;
        IsGameOver = false;
        IsPaused = false;

        ScoreManager.Instance.ResetScore();
        UIManager.Instance.CloseAllPanel();
        UIManager.Instance.OpenPanel("GamePlayPanel");
    }

    public void PauseGame()
    {
        if (!IsPlaying || IsGameOver) return;

        IsPaused = true;
        UIManager.Instance.CloseAllPanel();
        UIManager.Instance.OpenPanel("PausePanel");
    }

    public void ResumeGame()
    {
        if (!IsPlaying || IsGameOver) return;

        IsPaused = false;
        UIManager.Instance.CloseAllPanel();
        UIManager.Instance.OpenPanel("GamePlayPanel");
    }

    public void GameOver()
    {
        if (IsGameOver) return;

        IsGameOver = true;
        IsPlaying = false;

        ScoreManager.Instance.SaveScoreResult();
        UIManager.Instance.CloseAllPanel();
        UIManager.Instance.OpenPanel("GameOverPanel");
    }

    public void RestartGame()
    {
        _autoStartOnLoad = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        _autoStartOnLoad = false;
        IsPlaying = false;
        IsGameOver = false;
        IsPaused = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}