using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    [Header("Player")] public GameObject Player;
    [Header("“V‹C")] public GameObject Weather;
    [Header("UI")] public GameObject UI;

    private GameObject dataMessager;

    private PlayerControl player;
    private UIControl ui;

    void Start()
    {
        player=Player.GetComponent<PlayerControl>();
        ui=UI.GetComponent<UIControl>();
    }

    void Update()
    {
        UIUpdate();
    }

    private void UIUpdate()
    {
        ui.SetHp(player.ReturnHp());
        ui.SetLevel(player.ReturnLevel());
        ui.SetExp(player.ReturnExp(),player.ReturnMaxExp());
    }
}
