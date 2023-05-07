using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticle : MonoBehaviour
{
    public LayerMask cutifyable;

    private void OnParticleCollision(GameObject other)
    {
        if (other.layer != cutifyable) return;
        other.GetComponent<CuteifyableObject>().Cuteify();
    }
}
