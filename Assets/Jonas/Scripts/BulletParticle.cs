using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BulletParticle : MonoBehaviour
{
    public LayerMask cutifyable;

    private void OnParticleCollision(GameObject other)
    {
        if ((cutifyable.value & (1 << other.layer)) == 0) return;
        if (other.TryGetComponent(out CuteifyableObject cute))
            cute.Cuteify();
    }
}
