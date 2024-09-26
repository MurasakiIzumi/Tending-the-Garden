using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicControl : MonoBehaviour
{
    [Header("”š”­")] public GameObject Explosion;
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
        OutRange();
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

    private void OutRange()
    {
        if (Vector3.Distance(transform.position, StartPos) >= Range)
        {
            DestroySelf();
        }
    }

    private void DestroySelf()
    {
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
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
            if (Vector3.Distance(transform.position, collision.gameObject.transform.position) <= 2f)
            {
                EnemyControl Enemy = collision.GetComponent<EnemyControl>();
                Enemy.GetHurt(Damage);
                DestroySelf();
            }
        }
    }
}
