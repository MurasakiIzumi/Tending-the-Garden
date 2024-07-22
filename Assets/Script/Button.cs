using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [Header("BGMPlayer")] public AudioSource BGMplayer;
    [Header("‘Ò‚ÂŽžŠÔ")] public float Second = 1f;

    private AudioSource audioSource;

    public void LordScene(int Index)
    {
        PlaySE();
        StartCoroutine("LordWait", Index);
    }

    public void ExitGame()
    {
        PlaySE();
        StartCoroutine("ExitWait");
    }

    IEnumerator LordWait(int Index)
    {
        yield return new WaitForSecondsRealtime(Second);

        SceneManager.LoadScene(Index);
    }

    IEnumerator ExitWait()
    {
        yield return new WaitForSecondsRealtime(Second);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void PlaySE()
    {
        BGMplayer.Stop();
        audioSource=GetComponent<AudioSource>();
        audioSource.Play();
        Second += audioSource.clip.length;
    }
}
