using System;
using UnityEngine;

public class BackgroundSkinManager : Singleton<BackgroundSkinManager>
{
    [SerializeField] private BackgroundSkinDatabase database;
    private const string PrefKey = "SelectedBackground";

    public event Action OnSkinChanged;
    public BackgroundSkinDatabase Database => database;

    public string GetSelected()
    {
        string def = database.backgroundSkinData.Length > 0 ? database.backgroundSkinData[0].backgroundName : "";
        return PlayerPrefs.GetString(PrefKey, def);
    }

    public bool IsSelected(string bgName) => GetSelected() == bgName;

    public void SelectBackground(string bgName)
    {
        PlayerPrefs.SetString(PrefKey, bgName);
        PlayerPrefs.Save();
        OnSkinChanged?.Invoke();
    }

    public Sprite GetSelectedSprite()
    {
        BackgroundSkinData skin = database.GetBackgroundSkinDataByName(GetSelected());
        return skin?.backgroundSprite;
    }
}