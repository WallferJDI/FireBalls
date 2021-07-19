using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer))]
public class TowerSegment : MonoBehaviour
{
    public event UnityAction<TowerSegment> BulletHit;
   [SerializeField] private MeshRenderer _meshRenderer;
    private void Awake()
    {
       // _meshRenderer = GetComponent<MeshRenderer>();

    }
    public void SetColor(Color color)
    {
        _meshRenderer.material.color = color;
    }
    public void Break()
    {
        BulletHit?.Invoke(this);
        Destroy(gameObject);
        
    }
}
