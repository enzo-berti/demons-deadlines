using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTheme : MonoBehaviour
{
    int indexClip = 0;
    [SerializeField] private List<AudioClip> themeClips;

    private bool readyToPlayNextOne = false;
    [SerializeField] private AudioSource themeSource;


    public void IncreaseVolume()
    {
        StopAllCoroutines();
        StartCoroutine(IncreaseVolumeCoroutine());
    }

    public void DecreaseVolume()
    {
        StopAllCoroutines();
        StartCoroutine(DecreaseVolumeCoroutine());
    }

    private IEnumerator IncreaseVolumeCoroutine()
    {
        while (themeSource.volume < 1)
        {
            themeSource.volume += 0.0003f;
            yield return null;
        }
    }

    private IEnumerator DecreaseVolumeCoroutine()
    {
        while (themeSource.volume > 0.15)
        {
            themeSource.volume -= 0.003f;
            yield return null;
        }
    }

    public void NextTheme()
    {
        readyToPlayNextOne = true;
        themeSource.loop = false;
    }

    private void Update()
    {
        if (readyToPlayNextOne && !themeSource.isPlaying)
        {
            themeSource.loop = true;
            themeSource.clip = themeClips[indexClip++];
            themeSource.Play();
        }
    }
}
