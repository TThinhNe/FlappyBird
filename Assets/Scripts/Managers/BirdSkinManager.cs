using System;
using UnityEngine;

public class BirdSkinManager : Singleton<BirdSkinManager>
{
    [SerializeField] private BirdSkinDatabase database;
    private const string PrefKey = "SelectedBird";

    public event Action OnSkinChanged;
    public BirdSkinDatabase Database => database;

    public string GetSelected()
    {
        string def = database.birdSkinData.Length > 0 ? database.birdSkinData[0].birdName : "";
        return PlayerPrefs.GetString(PrefKey, def);
    }

    public bool IsSelected(string birdName) => GetSelected() == birdName;

    public void SelectBird(string birdName)
    {
        PlayerPrefs.SetString(PrefKey, birdName);
        PlayerPrefs.Save();

        OnSkinChanged?.Invoke();
    }

    public void ApplySkinTo(Bird bird)
    {
        BirdSkinData skin = database.GetBirdSkinDataByName(GetSelected());
        if (skin != null && skin.animatorOverrideController != null && bird.Animator != null)
            bird.Animator.runtimeAnimatorController = skin.animatorOverrideController;
    }
}