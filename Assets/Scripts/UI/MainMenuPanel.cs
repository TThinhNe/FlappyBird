using UnityEngine;

public class MainMenuPanel : Panel
{
    public void OnPlayButtonClicked()
    {
        GameManager.Instance.ShowTutorial();
    }
}