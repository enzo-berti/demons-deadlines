using UnityEngine;
using UnityEngine.UI;

public class CaptchaWindow : MonoBehaviour
{
    [SerializeField] Sprite[] fakeIconsSprites;
    [SerializeField] Sprite[] IconsSprites;

    [SerializeField] Image[] fakeIconGos;
    [SerializeField] Image iconGo;

    [SerializeField] CaptchaGame captchaGame;

    [SerializeField] RectTransform[] possiblePos;

    [SerializeField] float timeToChangePos = 5f;
    private float timerChangePos = 0f;

    private void ChooseEvilIcon(CaptchaType captchaType)
    {
        iconGo.sprite = IconsSprites[(int)captchaType];
    }

    private void ChooseFakeIcons()
    {
        // disable one of the four icons
        int disableIndex = Random.Range(0, fakeIconGos.Length);
        fakeIconGos[disableIndex].enabled = false;

        for (int i = 0; i < fakeIconGos.Length; i++)
        {
            if (disableIndex == i || fakeIconGos[i] == null)
            {
                continue;
            }

            fakeIconGos[i].enabled = true;
            fakeIconGos[i].sprite = fakeIconsSprites[Random.Range(0, fakeIconsSprites.Length)];
        }
    }

    private void Awake()
    {
        timerChangePos = timeToChangePos;
    }

    private void Update()
    {
        timerChangePos -= Time.deltaTime;
        if (timerChangePos <= 0f)
        {
            timerChangePos += timeToChangePos;

            int placeIndex = Random.Range(0, possiblePos.Length);
            GetComponent<RectTransform>().anchoredPosition = possiblePos[placeIndex].anchoredPosition;
        }
    }

    public void Activate(CaptchaType captchaType)
    {
        gameObject.SetActive(true);
        ChooseEvilIcon(captchaType);
        ChooseFakeIcons();
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
