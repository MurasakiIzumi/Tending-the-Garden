using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Lumin;

public class LevelUpSystem : MonoBehaviour
{
    public GameObject Skill1;
    public GameObject Skill2;
    public GameObject Skill3;
    public GameObject Skill4;
    public GameObject HpUp;

    public Vector3 LPos;
    public Vector3 RPos;

    public void ResetSystem()
    {
        Skill1.transform.localPosition = Vector3.zero;
        Skill1.SetActive(false);

        Skill2.transform.localPosition = Vector3.zero;
        Skill2.SetActive(false);

        Skill3.transform.localPosition = Vector3.zero;
        Skill3.SetActive(false);

        Skill4.transform.localPosition = Vector3.zero;
        Skill4.SetActive(false);

        HpUp.transform.localPosition = Vector3.zero;
        HpUp.SetActive(false);
    }

    public void RandomSkill(int playerlv, int skill1lv, int skill2lv, int skill3lv, int skill4lv)
    {
        if (playerlv >= 16)
        {
            SetPos(5);
            return;
        }

        int Lnum = Random.Range(1, 5);
        Debug.Log(Lnum);

        for (; ; )
        {
            if (Lnum == 1)
            {
                if (skill1lv == 4)
                {
                    Lnum++;
                    continue;
                }
                else
                {
                    break;
                }
            }
            else if (Lnum == 2)
            {
                if (skill2lv == 4)
                {
                    Lnum++;
                    continue;
                }
                else
                {
                    break;
                }
            }
            else if (Lnum == 3)
            {
                if (skill3lv == 4)
                {
                    Lnum++;
                    continue;
                }
                else
                {
                    break;
                }
            }
            else if (Lnum == 4)
            {
                if (skill4lv == 4)
                {
                    Lnum++;
                    continue;
                }
                else
                {
                    break;
                }
            }
            else if (Lnum == 5)
            {
                break;
            }
        }

        int Mnum = Random.Range(1, 6);
        if(Mnum==Lnum)
        {
            if (Lnum != 5)
            {
                Mnum++;
            }
        }
        Debug.Log(Mnum);

        for (; ; )
        {
            if (Mnum == 1)
            {
                if (skill1lv == 4)
                {
                    Mnum++;
                    continue;
                }
                else
                {
                    break;
                }
            }

            if (Mnum == 2)
            {
                if (skill2lv == 4)
                {
                    Mnum++;
                    continue;
                }
                else
                {
                    break;
                }
            }

            if (Mnum == 3)
            {
                if (skill3lv == 4)
                {
                    Mnum++;
                    continue;
                }
                else
                {
                    break;
                }
            }

            if (Mnum == 4)
            {
                if (skill4lv == 4)
                {
                    Mnum++;
                    continue;
                }
                else
                {
                    break;
                }
            }
            if (Mnum == 5)
            {
                break;
            }
        }

        int Rnum = Random.Range(1, 6);
        if ((Rnum == Lnum) || (Rnum == Mnum))
        {
            Rnum++;
            if (Rnum > 5)
            {
                Rnum = 1;
            }

            if ((Rnum == Lnum) || (Rnum == Mnum))
            {
                Rnum++;
                if (Rnum > 5)
                {
                    Rnum = 1;
                }
            }
        }
        Debug.Log(Rnum);

        for (; ; )
        {
            if (Rnum == 1)
            {
                if (skill1lv == 4)
                {
                    Rnum++;
                    continue;
                }
                else
                {
                    break;
                }
            }

            if (Rnum == 2)
            {
                if (skill2lv == 4)
                {
                    Rnum++;
                    continue;
                }
                else
                {
                    break;
                }
            }

            if (Rnum == 3)
            {
                if (skill3lv == 4)
                {
                    Rnum++;
                    continue;
                }
                else
                {
                    break;
                }
            }

            if (Rnum == 4)
            {
                if (skill4lv == 4)
                {
                    Rnum++;
                    continue;
                }
                else
                {
                    break;
                }
            }
            if (Rnum == 5)
            {
                break;
            }
        }

        SetPos(Lnum, Mnum, Rnum);
        Debug.Log(Lnum+" "+Mnum+" "+Rnum);
    }

    private void SetPos(int Lnum, int Mnum, int Rnum)
    {
        GameObject Skill_L;
        GameObject Skill_M;
        GameObject Skill_R;

        switch (Lnum)
        {
            case 1:
                Skill_L = Instantiate(Skill1, gameObject.transform);
                Skill_L.transform.localPosition = LPos;
                Skill_L.SetActive(true);
                break;
            case 2:
                Skill_L = Instantiate(Skill2, gameObject.transform);
                Skill_L.transform.localPosition = LPos;
                Skill_L.SetActive(true);
                break;
            case 3:
                Skill_L = Instantiate(Skill3, gameObject.transform);
                Skill_L.transform.localPosition = LPos;
                Skill_L.SetActive(true);
                break;
            case 4:
                Skill_L = Instantiate(Skill4, gameObject.transform);
                Skill_L.transform.localPosition = LPos;
                Skill_L.SetActive(true);
                break;
            case 5:
                Skill_L = Instantiate(HpUp, gameObject.transform);
                Skill_L.transform.localPosition = LPos;
                Skill_L.SetActive(true);
                break;
        }

        switch (Mnum)
        {
            case 1:
                Skill_M = Instantiate(Skill1, gameObject.transform);
                Skill_M.transform.localPosition = Vector3.zero;
                Skill_M.SetActive(true);
                break;
            case 2:
                Skill_M = Instantiate(Skill2, gameObject.transform);
                Skill_M.transform.localPosition = Vector3.zero;
                Skill_M.SetActive(true);
                break;
            case 3:
                Skill_M = Instantiate(Skill3, gameObject.transform);
                Skill_M.transform.localPosition = Vector3.zero;
                Skill_M.SetActive(true);
                break;
            case 4:
                Skill_M = Instantiate(Skill4, gameObject.transform);
                Skill_M.transform.localPosition = Vector3.zero;
                Skill_M.SetActive(true);
                break;
            case 5:
                Skill_M = Instantiate(HpUp, gameObject.transform);
                Skill_M.transform.localPosition = Vector3.zero;
                Skill_M.SetActive(true);
                break;
        }

        switch (Rnum)
        {
            case 1:
                Skill_R = Instantiate(Skill1, gameObject.transform);
                Skill_R.transform.localPosition = RPos;
                Skill_R.SetActive(true);
                break;
            case 2:
                Skill_R = Instantiate(Skill2, gameObject.transform);
                Skill_R.transform.localPosition = RPos;
                Skill_R.SetActive(true);
                break;
            case 3:
                Skill_R = Instantiate(Skill3, gameObject.transform);
                Skill_R.transform.localPosition = RPos;
                Skill_R.SetActive(true);
                break;
            case 4:
                Skill_R = Instantiate(Skill4, gameObject.transform);
                Skill_R.transform.localPosition = RPos;
                Skill_R.SetActive(true);
                break;
            case 5:
                Skill_R = Instantiate(HpUp, gameObject.transform);
                Skill_R.transform.localPosition = RPos;
                Skill_R.SetActive(true);
                break;
        }
    }

    private void SetPos(int Mnum)
    {
        switch (Mnum)
        {
            case 1:
                Skill1.transform.localPosition = Vector3.zero;
                Skill1.SetActive(true);
                break;
            case 2:
                Skill2.transform.localPosition = Vector3.zero;
                Skill2.SetActive(true);
                break;
            case 3:
                Skill3.transform.localPosition = Vector3.zero;
                Skill3.SetActive(true);
                break;
            case 4:
                Skill4.transform.localPosition = Vector3.zero;
                Skill4.SetActive(true);
                break;
            case 5:
                HpUp.transform.localPosition = Vector3.zero;
                HpUp.SetActive(true);
                break;
        }
    }
}
