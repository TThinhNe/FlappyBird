using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class GameplayBackground : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        ApplySelectedBackground();
    }

    private void OnEnable()
    {
        if (BackgroundSkinManager.Instance != null)
            BackgroundSkinManager.Instance.OnSkinChanged += ApplySelectedBackground;
    }

    private void OnDisable()
    {
        if (BackgroundSkinManager.Instance != null)
            BackgroundSkinManager.Instance.OnSkinChanged -= ApplySelectedBackground;
    }

    private void ApplySelectedBackground()
    {
        if (BackgroundSkinManager.Instance == null) return;

        Sprite selectedSprite = BackgroundSkinManager.Instance.GetSelectedSprite();
        if (selectedSprite != null)
            _spriteRenderer.sprite = selectedSprite;
    }
}