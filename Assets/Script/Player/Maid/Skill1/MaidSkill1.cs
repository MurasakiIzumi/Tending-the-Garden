using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaidSkill1 : MonoBehaviour
{
    public GameObject Player;
    [Header("‰ñ“]‘¬“x")] public float rotatespeed = 10f;
    [Header("UŒ‚—Í")] public int damage = 20;
    [Header("‚Ù‚¤‚«")]
    public GameObject Houki;

    [SerializeField] public int skillLv;
    private int realskillLv;
    private int realdamage;
    private Vector3 CenterPos;

    private bool toStart;

    void Start()
    {
        realskillLv = -999;
        realdamage = 0;
        toStart = false;

        Houki.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StartCheck();
    }

    private void StartCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("!!!");
        }
    }
}
