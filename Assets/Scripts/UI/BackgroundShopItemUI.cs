using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BackgroundShopItemUI : MonoBehaviour
{
    [SerializeField] private Image skinImage;
    [SerializeField] private TMP_Text skinNameText;
    [SerializeField] private GameObject checkmark;
    [SerializeField] private Button button;

    private string _bgName;
    private BackgroundSkinManager _manager;

    public void Setup(BackgroundSkinData data, BackgroundSkinManager manager)
    {
        _bgName = data.backgroundName;
        _manager = manager;

        skinImage.sprite = data.backgroundSprite;
        skinNameText.text = data.backgroundName;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => _manager.SelectBackground(_bgName));

        RefreshSelected();
    }

    public void RefreshSelected()
    {
        checkmark.SetActive(_manager.IsSelected(_bgName));
    }
}