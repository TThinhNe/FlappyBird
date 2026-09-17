using UnityEngine;

public class MainMenuPanel : Panel
{
    public void OnPlayButtonClicked()
    {
        GameManager.Instance.ShowTutorial();
    }

    public void OnShopButtonClicked()
    {
        UIManager.Instance.OpenPanel("ShopPanel");
    }
}