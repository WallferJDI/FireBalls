using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private float _towerSize;
    [SerializeField] private Transform _buildPoint;
    [SerializeField] private TowerSegment _towerSegment;

    private List<TowerSegment> _towerSegments;


    private void Start()
    {
        Build();
    }

    private List<TowerSegment> Build()
    {
        _towerSegments = new List<TowerSegment>();
        Transform currentPoint = _buildPoint;
        for (int i = 0; i < _towerSize; i++)
        {
            TowerSegment newTowerSegment = BuildTowerSegment(currentPoint);
            _towerSegments.Add(newTowerSegment);
            currentPoint = newTowerSegment.transform;
        }
        return _towerSegments;
    }
    private TowerSegment BuildTowerSegment(Transform currentBuildPoint)
    {
       return Instantiate(_towerSegment, GetBuildPoint(currentBuildPoint),Quaternion.identity,_buildPoint);
    }

    private Vector3 GetBuildPoint(Transform currentBuildPoint)
    {
        return new Vector3(_buildPoint.position.x, currentBuildPoint.position.y + currentBuildPoint.localScale.y/2f, _buildPoint.position.z);
    }
}
