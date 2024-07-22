using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherControl : MonoBehaviour
{
    [Header("ê∞")] public GameObject SunShine;
    [Header("âJ")] public GameObject Rain;
    [Header("ñ∂")] public GameObject Fog;
    [Header("ñÈ")] public GameObject Night;

    public void SetWeather(int WeatherNum)
    {
        switch (WeatherNum)
        {
            case 1:
                SunShine.SetActive(true);
                break;
            case 2:
                Rain.SetActive(true);
                break;
            case 3:
                Fog.SetActive(true);
                break;
            case 4:
                Night.SetActive(true);
                break;
                default:
                break;
        }
    }
}
