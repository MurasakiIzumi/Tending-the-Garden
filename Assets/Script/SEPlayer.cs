using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SEPlayer : MonoBehaviour
{
    public AudioSource BGMPlayer;
    public AudioClip SE1;
    public AudioClip SE2;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = SE1;
        audioSource.Play();
    }

    void Update()
    {
        if ((audioSource.clip == SE1) && (!audioSource.isPlaying))
        {
            StartCoroutine("SEWait", 1f);
        }
    }

    IEnumerator SEWait(float sec)
    {
        yield return new WaitForSecondsRealtime(sec);

        audioSource.clip = SE2;
        audioSource.Play();
    }
}
