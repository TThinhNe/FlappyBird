using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Background : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        ApplySelectedBackground();

        if (BackgroundSkinManager.Instance != null)
        {
            BackgroundSkinManager.Instance.OnSkinChanged -= ApplySelectedBackground;
            BackgroundSkinManager.Instance.OnSkinChanged += ApplySelectedBackground;
        }
    }

    private void OnEnable()
    {
        if (_spriteRenderer == null)
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    private void OnDisable()
    {
        if (BackgroundSkinManager.Instance != null)
        {
            BackgroundSkinManager.Instance.OnSkinChanged -= ApplySelectedBackground;
        }
    }

    private void ApplySelectedBackground()
    {
        if (_spriteRenderer == null)
            return;

        if (BackgroundSkinManager.Instance == null)
            return;

        Sprite selectedSprite =
            BackgroundSkinManager.Instance.GetSelectedSprite();

        if (selectedSprite != null)
        {
            _spriteRenderer.sprite = selectedSprite;
        }
    }
}