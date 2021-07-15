using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _force;

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward * _force, ForceMode.Impulse);
        Destroy(gameObject, 1);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out TowerSegment towerSegment))
        {
            towerSegment.Break();
            Destroy(gameObject);
        }
    }
}
