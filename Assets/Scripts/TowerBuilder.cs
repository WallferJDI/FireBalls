using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private float _towerSize;
    [SerializeField] private float _towerHeightOffset;
    [SerializeField] private Transform _buildPoint;
    [SerializeField] private TowerSegment _towerSegment;
    [SerializeField] private Color[] _colors;
    
   
    private List<TowerSegment> _towerSegments;
    
   
    public List<TowerSegment> Build()
    {
        _towerSegments = new List<TowerSegment>();
        Transform currentPoint = _buildPoint;
        for (int i = 0; i < _towerSize; i++)
        {
            TowerSegment newTowerSegment = BuildTowerSegment(currentPoint);
            newTowerSegment.SetColor(_colors[Random.Range(0, _colors.Length)]);
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
        return new Vector3(_buildPoint.position.x, currentBuildPoint.position.y + _towerSegment.gameObject.transform.localScale.y/2f + _towerHeightOffset, _buildPoint.position.z);
    }
}
