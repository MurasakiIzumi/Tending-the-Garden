using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetExp : MonoBehaviour
{
    public PlayerControl Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Exp.")
        {
            Player.GetExp(collision.GetComponent<ExpControl>().Exp);
            //Destroy(collision.gameObject);
            Debug.Log("111");
        }
    }
}
