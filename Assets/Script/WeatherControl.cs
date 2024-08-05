using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherControl : MonoBehaviour
{
    [Header("ê∞")] public GameObject SunShine;
    [Header("ñÈ")] public GameObject Night;
    [Header("âJ")] public GameObject Rain;
    [Header("ñ∂")] public GameObject Fog;

    public void SetWeather(int WeatherNum)
    {
        switch (WeatherNum)
        {
            case 1:
                SunShine.SetActive(true);
                break;
            case 2:
                Night.SetActive(true);
                break;
            case 3:
                Rain.SetActive(true);
                break;
            case 4:
                Fog.SetActive(true);
                break;
                default:
                SunShine.SetActive(true);
                break;
        }
    }
}
