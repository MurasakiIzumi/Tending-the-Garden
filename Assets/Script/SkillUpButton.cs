using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUpButton : MonoBehaviour
{
    public Director director;
    public GameObject levelUpSystem;

    public void SkillUp(int index)
    {
        director.SetSkillLv(index);

        Time.timeScale = 1;
        levelUpSystem.SetActive(false);
    }
}
