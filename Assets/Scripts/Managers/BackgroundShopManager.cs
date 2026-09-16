using System.Collections.Generic;
using UnityEngine;

public class BackgroundShopManager : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private ShopItemUI itemPrefab;

    private readonly List<ShopItemUI> _spawnedItems = new List<ShopItemUI>();

    private void OnEnable()
    {
        PopulateList();

        if (BackgroundSkinManager.Instance != null)
            BackgroundSkinManager.Instance.OnSkinChanged += RefreshSelection;
    }

    private void OnDisable()
    {
        if (BackgroundSkinManager.Instance != null)
            BackgroundSkinManager.Instance.OnSkinChanged -= RefreshSelection;
    }

    private void PopulateList()
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }
        _spawnedItems.Clear();

        if (BackgroundSkinManager.Instance == null || BackgroundSkinManager.Instance.Database == null)
            return;

        BackgroundSkinData[] allSkins = BackgroundSkinManager.Instance.Database.backgroundSkinData;

        foreach (BackgroundSkinData skin in allSkins)
        {
            ShopItemUI item = Instantiate(itemPrefab, content);
            bool isSelected = BackgroundSkinManager.Instance.IsSelected(skin.backgroundName);

            item.Setup(skin.backgroundSprite, isSelected, () => OnItemClicked(skin.backgroundName));
            _spawnedItems.Add(item);
        }
    }

    private void OnItemClicked(string backgroundName)
    {
        BackgroundSkinManager.Instance.SelectBackground(backgroundName);
        RefreshSelection();
    }

    private void RefreshSelection()
    {
        if (BackgroundSkinManager.Instance == null || BackgroundSkinManager.Instance.Database == null)
            return;

        BackgroundSkinData[] allSkins = BackgroundSkinManager.Instance.Database.backgroundSkinData;

        for (int i = 0; i < _spawnedItems.Count && i < allSkins.Length; i++)
        {
            bool isSelected = BackgroundSkinManager.Instance.IsSelected(allSkins[i].backgroundName);
            _spawnedItems[i].SetSelected(isSelected);
        }
    }
}