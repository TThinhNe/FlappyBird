using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : Panel
{
    private const string PanelName = "ShopPanel";

    [Header("Tabs")]
    [SerializeField] private GameObject birdShopPanel;
    [SerializeField] private GameObject backgroundShopPanel;

    [Header("Buttons")]
    [SerializeField] private Button birdShopButton;  
    [SerializeField] private Button backgroundShopButton;  
    [SerializeField] private Button closeButton;  

    private void Awake()
    {
        birdShopButton.onClick.AddListener(ShowBirdTab);
        backgroundShopButton.onClick.AddListener(ShowBackgroundTab);
        closeButton.onClick.AddListener(OnCloseClicked);
    }

    public override void Show()
    {
        base.Show();
        ShowBirdTab();
    }

    private void ShowBirdTab()
    {
        birdShopPanel.SetActive(true);
        backgroundShopPanel.SetActive(false);
    }

    private void ShowBackgroundTab()
    {
        birdShopPanel.SetActive(false);
        backgroundShopPanel.SetActive(true);
    }

    private void OnCloseClicked()
    {
        UIManager.Instance.ClosePanel(PanelName);
    }
}