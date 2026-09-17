using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
    [SerializeField] private Image skinImage;
    [SerializeField] private GameObject checkMark;
    [SerializeField] private Button button;

    private Action _onClick;

    private void Reset()
    {
        button = GetComponent<Button>();
        skinImage = transform.Find("SkinImage")?.GetComponent<Image>();
        checkMark = transform.Find("CheckMark")?.gameObject;
    }

    public void Setup(Sprite sprite, bool isSelected, Action onClick)
    {
        if (skinImage != null)
            skinImage.sprite = sprite;

        SetSelected(isSelected);

        _onClick = onClick;

        if (button != null)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => _onClick?.Invoke());
        }
    }

    public void SetSelected(bool isSelected)
    {
        if (checkMark != null)
            checkMark.SetActive(isSelected);
    }
}