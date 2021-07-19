using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    [SerializeField] private float _towerHeightOffset;
    private TowerBuilder _towerBuilder;
    private List<TowerSegment> _towerSegments;

    public event UnityAction<int> SizeUpdated;
    private void Start()
    {
        _towerBuilder = GetComponent<TowerBuilder>();
        _towerSegments= _towerBuilder.Build();

        foreach (var segmnet in _towerSegments)
        {
            segmnet.BulletHit += OnBulletHit;
        }

        SizeUpdated?.Invoke(_towerSegments.Count);
    }


    private void OnBulletHit(TowerSegment HitedTowetSegment)
    {

        HitedTowetSegment.BulletHit -= OnBulletHit;
        _towerSegments.Remove(HitedTowetSegment);

        foreach (var segment in _towerSegments)
        {
            segment.transform.position = new Vector3(segment.transform.position.x, segment.transform.position.y - segment.transform.localScale.y/2f - _towerHeightOffset, segment.transform.position.z);
        }
        SizeUpdated?.Invoke(_towerSegments.Count);
    }
}
