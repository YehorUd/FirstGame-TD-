using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon2 : MonoBehaviour
{
    public Transform BulletPrefab;
    public float FireDeley, Radius, Damage;
    public LayerMask EnemyLayer;

    //private static bool _gunLook = false;
    private float _fireTimer;
    private Transform _enemy, _gun, _firePoint;

    void Start()
    {
        _fireTimer = FireDeley;
        _gun = transform.GetChild(0);
        _firePoint = transform.GetChild(0).GetChild(0);
    }

    void Update()
    {
        _fireTimer -= Time.deltaTime;
        if (_enemy)
        {
            Vector3 lookAt = _enemy.position;
            lookAt.y = _gun.position.y;
            Vector3 newDirrection = Vector3.RotateTowards(_gun.forward, _gun.position - lookAt, _fireTimer,0);
            _gun.rotation = Quaternion.LookRotation(newDirrection);
                Fire();
          
            //_gun.rotation = Quaternion.Lerp(_gun.rotation - lookAt, _enemy.rotation, Time.time * _speedRotate);




            if (Vector3.Distance(transform.position, _enemy.position) > Radius)
            {
                _enemy = null;
                //_gun.transform.rotation = Quaternion.Lerp(_gun.transform.rotation, _enemy.rotation, Time.deltaTime * _speedRotate);

            }
        }
        else if (_enemy == null)
        {
            Collider[] colls = Physics.OverlapSphere(transform.position, Radius, EnemyLayer);
            if (colls.Length > 0)
                _enemy = colls[0].transform.GetChild(0);
        }
    }
    void Fire()
    {
        if (_fireTimer <= 0)
        {
            Transform bullet = Instantiate(BulletPrefab, _firePoint.position, Quaternion.identity);
            bullet.LookAt(_enemy);
            bullet.GetComponent<Bullet>().Damage = Damage;
            _fireTimer = FireDeley;
        }

    }
}
