using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject : MonoBehaviour
{
    public float lifeTime = 1f;

    void Update()
    {
        Destroy(gameObject, lifeTime);
    }
}
