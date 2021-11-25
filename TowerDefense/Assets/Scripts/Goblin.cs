using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    public event System.Action OnDeath;

    public float Speed;
    public float RotationSpeed;
    public Transform[] Points;
    public float StartHP;
    public float delay = 0f;

    private Resources _res;
    private float _hp;
    private Animator MyAnimator;
    private Transform _currentPoint;
    private int _index;
    private Vector3 _dirrection;
    void Start()
    {
        _index = 0;
        _currentPoint = Points[_index];
        MyAnimator = GetComponent<Animator>();
        _hp = StartHP;
        _res = FindObjectOfType<Resources>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            _hp -= collision.gameObject.GetComponent<Bullet>().Damage;

            if (IsDead)
            {
                if (OnDeath != null)
                {
                    OnDeath();
                }
                MyAnimator.Play("Die01");
                Destroy(gameObject,this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
                    _res.EnemyKill();
            }
        }
    }
    public bool IsDead{
    get{
            return _hp <= 0;
    }
    }
    void Update()
    {
        _dirrection = _currentPoint.position - transform.position;
        Vector3 newDirrection = Vector3.RotateTowards(transform.forward, _dirrection, Time.deltaTime * RotationSpeed, 10);

        transform.rotation = Quaternion.LookRotation(newDirrection);
        transform.position = Vector3.MoveTowards(
        transform.position,
        _currentPoint.position,
        Time.deltaTime * Speed);

        if (transform.position == _currentPoint.position)
        {
            _index++;
            MyAnimator.Play("Move01");
            if (_index >= Points.Length)
            {
                if (OnDeath != null)
                {
                    OnDeath();
                }
                Destroy(gameObject);
                _res.MissEnemy();
            }
            else
            {
                _currentPoint = Points[_index];
            }

        }

    }
}
