using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MouseUI : MonoBehaviour
{
    [SerializeField] private Sprite clicSprite;
    [SerializeField] private Sprite normalSprite;

    private Image mouseImage;
    private RectTransform mouseRectTransform;

    [field: SerializeField] public bool CanMove { get; set; } = true;


    private void Awake()
    {
        mouseImage = GetComponent<Image>();
#if !UNITY_EDITOR
        Cursor.visible = false; // because I don't know how to hide it by default in the game :clown:
#endif
        mouseRectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            mouseImage.sprite = clicSprite;
        }
        else
        {
            mouseImage.sprite = normalSprite;
        }

        if (CanMove && MouseExtension.GetUIMousePos(gameObject, Input.mousePosition, out Vector3 worldPos))
        {
            mouseRectTransform.position = worldPos;
        }
    }
}
