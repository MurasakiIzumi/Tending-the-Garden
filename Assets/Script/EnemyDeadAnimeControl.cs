using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadAnimeControl : MonoBehaviour
{
    [Header("åoå±íl")] public GameObject Exp;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();   
    }

    void Update()
    {
        var state = animator.GetCurrentAnimatorStateInfo(0);

        if (state.normalizedTime >= state.length)
        {
            Instantiate(Exp, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
