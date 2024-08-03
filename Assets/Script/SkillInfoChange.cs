using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillInfoChange : MonoBehaviour
{
    public int skillnum;
    public PlayerControl player;

    private TextMeshProUGUI text;
    private int skilllv;

    void Start()
    {
        text=GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        ChangeInfoText();
    }

    private void ChangeInfoText()
    {
        switch (skillnum)
        {
            case 1:
                skilllv = player.ReturnSkillLv(1);

                switch (skilllv)
                {
                    case 2:
                        text.text = "+ Rotate Speed";
                        break;
                    case 3:
                        text.text = "+ Rotate Range";
                        break;
                    default:
                        break;
                }

                break;
            case 2:
                skilllv = player.ReturnSkillLv(2);

                switch (skilllv)
                {
                    case 1:
                        text.text = "Duster have\nDamage now";
                        break;
                    case 2:
                        text.text = "+ Duster x 3";
                        break;
                    case 3:
                        text.text = "+ Rotate Speed";
                        break;
                        default:
                        break;
                }
                break;
            case 3:
                skilllv = player.ReturnSkillLv(3);

                switch (skilllv)
                {
                    case 1:
                        text.text = "+ Damage";
                        break;
                    case 2:
                        text.text = "+ Doll x 1";
                        break;
                    case 3:
                        text.text = "+ Damage\n+ ShootSpeed";
                        break;
                    default:
                        break;
                }
                break;
            case 4:
                skilllv = player.ReturnSkillLv(4);

                switch (skilllv)
                {
                    case 1:
                        text.text = "+ Power\n+ Times";
                        break;
                    case 2:
                        text.text = "+ Teleport Distance";
                        break;
                    case 3:
                        text.text = "Explosion have\nDamage now\n+ Times";
                        break;
                    default:
                        break;
                }
                break;
        }
    }
}
