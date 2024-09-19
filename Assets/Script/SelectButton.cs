using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SelectButton : MonoBehaviour
{
    [Header("�R���g���[��")] public SelectSystem selectSystem;
    [Header("�Z���N�g�{�C�X")] public AudioClip SelectVoice;

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
