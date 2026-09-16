using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialPanel : Panel
{

    void Update()
    {
        if (!gameObject.activeSelf) return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Hide();
            GameManager.Instance.BeginGameplay();
        }
    }
    
}