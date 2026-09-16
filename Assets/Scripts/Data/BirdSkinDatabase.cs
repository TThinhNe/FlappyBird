using UnityEngine;

[CreateAssetMenu(fileName = "BirdSkinDatabase", menuName = "Shop/Bird Skin Database")]
public class BirdSkinDatabase : ScriptableObject
{
    public BirdSkinData[] birdSkinData;

    public BirdSkinData GetBirdSkinDataByName(string birdName)
    {
        foreach (BirdSkinData skin in birdSkinData)
        {
            if (string.Equals(skin.birdName, birdName))
            {
                return skin;
            }
        }
        
        return null;
    }
}