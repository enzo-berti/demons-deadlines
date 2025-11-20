using UnityEngine;
using UnityEngine.InputSystem;

public class Phone : MonoBehaviour
{
    [SerializeField] private GameObject playerPhone;
    [SerializeField] private GameObject cosmeticPhone;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PhoneText phoneText;

    [SerializeField] private AudioClip hangClip;
    [SerializeField] private AudioClip ringingClip;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private MainTheme mainTheme;

    private bool peekedUp = false;
    private bool ringing = false;

    public void Awake()
    {
        Ring();
    }

    private void Update()
    {
        if (peekedUp && Mouse.current.leftButton.wasPressedThisFrame && phoneText.IsTextFinished())
        {
            HangUp();
        }
    }

    public void Ring()
    {
        audioSource.clip = ringingClip;
        audioSource.loop = true;
        audioSource.Play();

        ringing = true;
    }

    public void Interact()
    {
        PeekUp();
    }

    private void PeekUp()
    {
        peekedUp = true;

        mainTheme.DecreaseVolume();

        audioSource.clip = hangClip;
        audioSource.loop = false;
        audioSource.Play();

        if (ringing) // no phone call
        {
            phoneText.StartPhoneCall();
            mainTheme.NextTheme(); // we need to switch theme when the player summon the demon not when the call start

            ringing = false;
        }

        playerPhone.SetActive(true);
        cosmeticPhone.SetActive(false);

        playerMovement.canInteract = false;
    }

    private void HangUp()
    {
        peekedUp = false;

        mainTheme.IncreaseVolume();

        audioSource.loop = false;
        audioSource.clip = hangClip;
        audioSource.Play();

        phoneText.StopPhoneCall();

        playerPhone.SetActive(false);
        cosmeticPhone.SetActive(true);

        playerMovement.canInteract = true;
    }
}
