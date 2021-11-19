using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event System.Action OnDeath;

    public float Speed;
    public float RotationSpeed;
    public Transform[] Points;
    private Animator MyAnimator;
    private Transform _currentPoint;
    private int _index;
    private Vector3 _dirrection;
    void Start()
    {
        _index = 0;
        _currentPoint = Points[_index];
        MyAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        _dirrection = _currentPoint.position - transform.position;
        Vector3 newDirrection = Vector3.RotateTowards(transform.forward, _dirrection, Time.deltaTime * RotationSpeed, 0);
        transform.rotation = Quaternion.LookRotation(newDirrection);
        transform.position = Vector3.MoveTowards(transform.position, _currentPoint.position, Time.deltaTime * Speed);
        
        if (transform.position == _currentPoint.position)
        {
            _index++;
            MyAnimator.Play("Walk");
            if (_index >= Points.Length)
            {
            if(OnDeath != null)
            {
                    OnDeath();
            }
                Destroy(gameObject);
            }
            else
            {
                _currentPoint = Points[_index];
            }

        }

    }
}
