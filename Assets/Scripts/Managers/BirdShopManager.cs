using System.Collections.Generic;
using UnityEngine;

public class BirdShopManager : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private ShopItemUI itemPrefab;

    private readonly List<ShopItemUI> _spawnedItems = new List<ShopItemUI>();

    private void OnEnable()
    {
        PopulateList();

        if (BirdSkinManager.Instance != null)
            BirdSkinManager.Instance.OnSkinChanged += RefreshSelection;
    }

    private void OnDisable()
    {
        if (BirdSkinManager.Instance != null)
            BirdSkinManager.Instance.OnSkinChanged -= RefreshSelection;
    }

    private void PopulateList()
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }
        _spawnedItems.Clear();

        if (BirdSkinManager.Instance == null || BirdSkinManager.Instance.Database == null)
            return;

        BirdSkinData[] allSkins = BirdSkinManager.Instance.Database.birdSkinData;

        foreach (BirdSkinData skin in allSkins)
        {
            ShopItemUI item = Instantiate(itemPrefab, content);
            bool isSelected = BirdSkinManager.Instance.IsSelected(skin.birdName);

            item.Setup(skin.birdSprite, isSelected, () => OnItemClicked(skin.birdName));
            _spawnedItems.Add(item);
        }
    }

    private void OnItemClicked(string birdName)
    {
        BirdSkinManager.Instance.SelectBird(birdName);
        RefreshSelection();
    }

    private void RefreshSelection()
    {
        if (BirdSkinManager.Instance == null || BirdSkinManager.Instance.Database == null)
            return;

        BirdSkinData[] allSkins = BirdSkinManager.Instance.Database.birdSkinData;

        for (int i = 0; i < _spawnedItems.Count && i < allSkins.Length; i++)
        {
            bool isSelected = BirdSkinManager.Instance.IsSelected(allSkins[i].birdName);
            _spawnedItems[i].SetSelected(isSelected);
        }
    }
}