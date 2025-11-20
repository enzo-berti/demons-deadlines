using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private string outlineLayerName = "Interactable";
    private int outlineLayer;

    private Interactable lastInteractable = null;

    public bool canInteract = true;

    private void Awake()
    {
        outlineLayer = LayerMask.NameToLayer(outlineLayerName);
    }

    void Update()
    {
        if (canInteract && RaycastCheck() && Mouse.current.leftButton.wasPressedThisFrame)
        {
            lastInteractable.Play();

            lastInteractable.gameObject.layer = lastInteractable.DefaultLayer;
            lastInteractable = null;
        }
    }

    private bool RaycastCheck()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width * 0.5f, Screen.height * 0.5f));

        if (!Physics.Raycast(ray, out RaycastHit hit) || !hit.collider.TryGetComponent(out Interactable interactable))
        {
            if (lastInteractable != null)
            {
                lastInteractable.gameObject.layer = lastInteractable.DefaultLayer;
                lastInteractable = null;
            }

            return false;
        }

        if (lastInteractable == interactable)
        {
            return true;
        }

        if (lastInteractable != null)
        {
            lastInteractable.gameObject.layer = lastInteractable.DefaultLayer;
        }

        interactable.gameObject.layer = outlineLayer;
        lastInteractable = interactable;

        return true;
    }
}
