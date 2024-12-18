using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectControl : MonoBehaviour
{
    [Header("上昇するか")] public bool isMoveUp;
    [Header("上昇速度")] public float speed = 1f;
    
    private Animator animator;
    private float realspeed;
    void Start()
    {
        animator = GetComponent<Animator>();
        realspeed = speed / 10;
    }

    void Update()
    {
        MoveUp();
        DestroySelf();
    }

    private void MoveUp()
    {
        if(!isMoveUp)
        {
            return;
        }

        realspeed += speed * Time.deltaTime;
        realspeed = Mathf.Min(realspeed, speed);
        transform.position += Vector3.up * realspeed * Time.deltaTime;
    }

    private void DestroySelf()
    {
        var state = animator.GetCurrentAnimatorStateInfo(0);

        if (state.normalizedTime >= state.length)
        {
            Destroy(gameObject);
        }
    }
}
