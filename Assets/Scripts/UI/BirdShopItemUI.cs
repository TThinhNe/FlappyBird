using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BirdShopItemUI : MonoBehaviour
{
    [SerializeField] private Image skinImage;
    [SerializeField] private TMP_Text skinNameText;
    [SerializeField] private GameObject checkmark;
    [SerializeField] private Button button;

    private string _birdName;
    private BirdSkinManager _manager;

    public void Setup(BirdSkinData data, BirdSkinManager manager)
    {
        _birdName = data.birdName;
        _manager = manager;

        skinImage.sprite = data.birdSprite;
        skinNameText.text = data.birdName;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => _manager.SelectBird(_birdName));

        RefreshSelected();
    }

    public void RefreshSelected()
    {
        checkmark.SetActive(_manager.IsSelected(_birdName));
    }
}