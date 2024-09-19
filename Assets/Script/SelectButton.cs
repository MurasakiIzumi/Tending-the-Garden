using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SelectButton : MonoBehaviour
{
    [Header("コントロール")] public SelectSystem selectSystem;
    [Header("セレクトボイス")] public AudioClip SelectVoice;

    public void SelectCharacter(int index)
    {
        selectSystem.SetPlayer(index);

        if (SelectVoice)
        {
            AudioSource SE = gameObject.AddComponent<AudioSource>();
            SE.clip = SelectVoice;
            SE.loop = false;
            //SE.volume = 0.75f;
            SE.Play();
        }
    }

    public void SelectorWeather(int index)
    {
        selectSystem.SetWeather(index);
    }


}
