using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TowerSegment : MonoBehaviour
{
    public event UnityAction<TowerSegment> BulletHit;
    public void Break()
    {
        BulletHit?.Invoke(this);
        Destroy(gameObject);
        
    }
}
