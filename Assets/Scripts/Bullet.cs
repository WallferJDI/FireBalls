using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _force;
    private Rigidbody _rb;
    private Vector3 _moveDirection;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _moveDirection = Vector3.forward;
        Destroy(gameObject, 2);

    }


    private void Update()
    {
        transform.Translate(_moveDirection * _force * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out TowerSegment towerSegment))
        {
            towerSegment.Break();
            Destroy(gameObject);
        }
        if(collision.gameObject.TryGetComponent(out Barrier barrier))
        {
            Bounce();
        }
    }

    private void Bounce()
    {
        _moveDirection = Vector3.back + Vector3.up;
        _rb.AddExplosionForce(100, transform.position + new Vector3(0, -1, 1), 100);
    }
}
