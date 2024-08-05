using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SelectButton : MonoBehaviour
{
    [Header("ƒRƒ“ƒgƒ[ƒ‹")] public SelectSystem selectSystem;

    public void SelectCharacter(int index)
    {
        selectSystem.SetPlayer(index);
    }

    public void SelectorWeather(int index)
    {
        selectSystem.SetWeather(index);
    }
}
