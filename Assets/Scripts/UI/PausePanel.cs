using UnityEngine;

public class PausePanel : Panel
{
    public void OnResumeButtonClicked()
    {
        GameManager.Instance.ResumeGame();
    }

    public void OnMenuButtonClicked()
    {
        GameManager.Instance.GoToMenu();
    }
}