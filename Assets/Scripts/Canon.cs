using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _firePoint;

    private void OnMouseDown()
    {
        Fire();
    }
    private void Fire()
    {
      Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
    }
}
