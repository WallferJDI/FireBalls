using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public  class Canon : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _delayBetweenShoots;
    [SerializeField] private float _recoilDistance;
    private float _timeAfterShoot;

    
    private void Update()
    {
        _timeAfterShoot += Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            if(_timeAfterShoot > _delayBetweenShoots)
            {
                Fire();

                _timeAfterShoot = 0;
            }
        }
    }
    private void Fire()
    {
      Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
    }

    private void Recoil() 
    {
        transform.DOMoveZ(transform.position.z - _recoilDistance, _delayBetweenShoots / 2f).SetLoops(2, LoopType.Yoyo);
    }
}
