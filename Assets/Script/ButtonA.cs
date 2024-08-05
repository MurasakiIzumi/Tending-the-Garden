using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonA : MonoBehaviour
{
    [Header("BGMPlayer")] public AudioSource BGMplayer;
    [Header("‘Ò‚ÂŽžŠÔ")] public float Second = 1f;

    private AudioSource audioSource;

    public void LordScene(int Index)
    {
        PlaySE();
        GetComponent<Button>().enabled = false;
        StartCoroutine("LordWait", Index);

    }

    public void ExitGame()
    {
        PlaySE();
        gameObject.GetComponent<Button>().enabled = false;
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
        if (!BGMplayer)
        {
            return;
        }

        BGMplayer.Stop();
        audioSource=GetComponent<AudioSource>();
        audioSource.Play();
        Second += audioSource.clip.length;
    }
}
