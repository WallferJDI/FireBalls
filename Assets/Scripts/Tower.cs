using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    private TowerBuilder _towerBuilder;
    private List<TowerSegment> _towerSegments;
    private void Start()
    {
        _towerBuilder = GetComponent<TowerBuilder>();
        _towerSegments= _towerBuilder.Build();

        foreach (var segmnet in _towerSegments)
        {
            segmnet.BulletHit += OnBulletHit;
        }
    }


    private void OnBulletHit(TowerSegment HitedTowetSegment)
    {

        HitedTowetSegment.BulletHit -= OnBulletHit;
        _towerSegments.Remove(HitedTowetSegment);

        foreach (var segment in _towerSegments)
        {
            segment.transform.position = new Vector3(segment.transform.position.x, segment.transform.position.y - segment.transform.localScale.y/2f, segment.transform.position.z);
        }
    }
}
