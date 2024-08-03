using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicControl : MonoBehaviour
{
    private GameObject Target;
    private float Speed;
    private int Damage;
    private float Range;

    private Vector3 StartPos;
    private Vector3 Dir;

    void Start()
    {
        StartPos=transform.position;
    }
    void Update()
    {
        MoveToTarget();
        DestroySelf();
    }

    private void ChangeDir()
    {
        if (Target == null)
        {
            Destroy(gameObject);
            return;
        }

        Dir = Target.transform.position - transform.position;
        Dir.Normalize();
    }

    private void MoveToTarget()
    {
        ChangeDir();
        Rotation();
        transform.position += Dir * Speed * Time.deltaTime;
    }

    private void Rotation()
    {
        float angle = Vector3.Angle(Vector3.right, Dir);

        if (Dir.y < 0)
        {
            angle *= -1f;
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void DestroySelf()
    {
        if (Vector3.Distance(transform.position, StartPos) >= Range)
        {
            Destroy(gameObject);
        }
    }

    public void SetInfo(GameObject target,float speed,int damage,float range)
    {
        Target = target;
        Speed = speed;
        Damage = damage;
        Range= range;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            EnemyControl Enemy = collision.GetComponent<EnemyControl>();
            Enemy.GetHurt(Damage);
            Destroy(gameObject);
        }
    }
}
