using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticle : MonoBehaviour
{
    public LayerMask cutifyable;

    private void OnParticleCollision(GameObject other)
    {
        if ((cutifyable & (1 << gameObject.layer)) != 0) return;
        other.GetComponent<CuteifyableObject>().Cuteify();
    }
}
