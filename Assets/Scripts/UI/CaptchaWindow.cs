using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptchaWindow : MonoBehaviour
{
    [SerializeField] Sprite[] fakeIconsSprites;
    [SerializeField] Sprite[] IconsSprites;

    [SerializeField] Image[] fakeIconGos;
    [SerializeField] Image iconGo;

    private void Awake()
    {
        ChooseFakeIcons();
    }

    private void ChooseFakeIcons()
    {
        int disableIndex = Random.Range(0, 3);

        fakeIconGos[disableIndex].enabled = false;

        for (int i = 0; i < fakeIconGos.Length; i++)
        {
            if (disableIndex == i || fakeIconGos[i] == null)
            {
                continue;
            }

            fakeIconGos[i].sprite = fakeIconGos[Random.Range(0, fakeIconGos.Length)].sprite;
        }
    }

    public void Activate()
    {

    }

    public void Deactivate()
    {

    }
}
