using System;
using UnityEngine;

public enum CaptchaType
{
    Clock,
    Car,
    Torus
}

public class CaptchaGame : MonoBehaviour
{

    [SerializeField] GameObject carGOs;
    [SerializeField] GameObject clockGOs;
    [SerializeField] GameObject torusGOs;

    [SerializeField] CaptchaWindow captchaWindow;

    public void Activate()
    {
        CaptchaType captchaType = (CaptchaType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(CaptchaType)).Length);

        switch (captchaType)
        {
            case CaptchaType.Clock:
                ActivateRandomCaptchaG0(clockGOs);
                break;
            case CaptchaType.Car:
                ActivateRandomCaptchaG0(carGOs);
                break;
            case CaptchaType.Torus:
                ActivateRandomCaptchaG0(torusGOs);
                break;
        }

        if (captchaWindow != null)
        {
            captchaWindow.Activate(captchaType);
        }
    }

    public void Deactivate()
    {
        carGOs.SetActive(false);
        foreach (Transform t in carGOs.transform)
        {
            t.gameObject.SetActive(false);
        }

        clockGOs.SetActive(false);
        foreach (Transform t in clockGOs.transform)
        {
            t.gameObject.SetActive(false);
        }

        torusGOs.SetActive(false);
        foreach (Transform t in torusGOs.transform)
        {
            t.gameObject.SetActive(false);
        }

        captchaWindow.Deactivate();
    }

    static private void ActivateRandomCaptchaG0(GameObject go)
    {
        go.SetActive(true);
        int randIndex = UnityEngine.Random.Range(0, go.transform.childCount);

        for (int i = 0; i < go.transform.childCount; i++)
        {
            go.transform.GetChild(i).gameObject.SetActive(i == randIndex);
        }
    }
}
