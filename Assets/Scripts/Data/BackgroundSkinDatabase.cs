using UnityEngine;

[CreateAssetMenu(fileName = "BackgroundSkinDatabase", menuName = "Shop/Background Skin Database")]
public class BackgroundSkinDatabase : ScriptableObject
{
    public BackgroundSkinData[] backgroundSkinData;

    public BackgroundSkinData GetBackgroundSkinDataByName(string backgroundName)
    {
        foreach (BackgroundSkinData skin in backgroundSkinData)
        {
            if (string.Equals(skin.backgroundName, backgroundName))
            {
                return skin;
            }
        }
        
        return null;
    }
}