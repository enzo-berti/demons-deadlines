using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScreenGameplay : MonoBehaviour
{
    [SerializeField] CinemachineCamera screenCamera;
    [SerializeField] CinemachineCamera deskCamera;
    [SerializeField] Phone phone;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] MouseLogic mouseLogic;

    public bool onScreen = false;

    public void Interact()
    {
        In();
    }

    private void In()
    {
        screenCamera.enabled = true;
        deskCamera.enabled = false;
        playerMovement.canInteract = false;
        mouseLogic.CanMove = true;

        onScreen = true;
    }

    private void Out()
    {
        screenCamera.enabled = false;
        deskCamera.enabled = true;
        playerMovement.canInteract = true;
        mouseLogic.CanMove = false;

        onScreen = false;
    }

    public void Update()
    {
        if (!onScreen)
        {
            return;
        }

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Out();
        }
    }
}
